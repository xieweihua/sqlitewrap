#include "sqlite3.h"
#include <sstream>
#include <vector>
#include "string"
#include "stdarg.h"
#include "SQLiteConnection.h"

using namespace std;

SQLiteConnection::SQLiteConnection()
{
    result.clear();
    state = CLOSED;
    currentRow = 0;
    rowRount=0;
}
SQLiteConnection::~SQLiteConnection()
{
    vector<SQLiteRowData*>::iterator iter = result.begin();
    for(;iter != result.end();iter++)
    {
        (*iter)->row.clear();
        delete(*iter);
    }
}

/***********************************************************
* name: resetRowData
* arguments: 
* returns/side-effects: void
* description:
* 重置结果集合
***********************************************************/
void SQLiteConnection::resetRowData()
{
     vector<SQLiteRowData*>::iterator iter = result.begin();
    for(;iter != result.end();iter++)
    {
        (*iter)->row.clear();
        delete(*iter);
    }
    result.clear();
    rowRount = 0;
}

/***********************************************************
* name: string2int
* arguments: 
* returns/side-effects: int
* description:
* 字符串转换为整形
*todo:此功能与本类无关，可考虑移除到其他类中
***********************************************************/
int SQLiteConnection::string2int(string s_value)
{
    stringstream ss;
    ss<<s_value;

    int i_value;
    ss>>i_value;
    return i_value;
}

/***********************************************************
* name: string2int
* arguments: 
* returns/side-effects: int
* description:
* 整形转换为字符串
*todo:此功能与本类无关，可考虑移除到其他类中
***********************************************************/
string SQLiteConnection::int2string(int i_value)
{
    stringstream ss;
    string s_value;
    ss<<i_value;
    ss>>s_value;
    return s_value;
}

/***********************************************************
* name: log
* arguments: 
* returns/side-effects: void
* description:
* 日志接口
***********************************************************/
void SQLiteConnection::log(char* format, ...)  
{
    va_list arglist;
    va_start(arglist, format);
    //printf(format,arglist);
    va_end(arglist);
}

/***********************************************************
* name: open
* arguments: db
* returns/side-effects: bool
* description:
* 打开指定数据库文件(如指定文件不存在则新建数据库文件)
***********************************************************/
bool SQLiteConnection::open(const char *db )  
{  
    //打开一个数据库，如果该数据库不存在，则创建一个数据库文件  
    if(state == CONNECTED)
    {
        log( "open failed, a database have been opened" );  
        return false;
    }
    errCode = sqlite3_open(db, &pDB);  
    if( errCode != SQLITE_OK )  
    {
        log( "open failed, error code:%d ，reason:%s\n" , errCode, errMsg );  
        return false;
    }
    state = CONNECTED;
    return true;
}  
  
/***********************************************************
* name: tableIsExist
* arguments: table_name
* returns/side-effects: bool
* description:
* 通过表名判断，该表是否存在
***********************************************************/
bool SQLiteConnection::tableIsExist( string table_name )  
{  
    if(state != CONNECTED)
    {
        log( "Please open database first!"  );  
        return false;
    }
    if (pDB!=NULL)  
    {  
        //判断表是否存在  
        state = EXECUTING;
        op = IS_EXIST;
        string sqlstr = "select count(type) from sqlite_master where type='table' and name ='"+table_name+"'";  
        resetRowData();
        errCode =sqlite3_exec(pDB,sqlstr.c_str(),SQLiteConnection::loadRecord,this,&errMsg);  
        return rowRount == 0 ? false:true;  
    }  
    return false;  
}  

/***********************************************************
* name: exec
* arguments: sql
* returns/side-effects: void
* description:
* 执行指定sql语句
***********************************************************/
void SQLiteConnection::exec( string sql )  
{  
    if(state != CONNECTED)
    {
        log( "Please open database first!"  );  
        return;
    }
    resetRowData();
    op = SELECT;
    errCode = sqlite3_exec(pDB,sql.c_str(),loadRecord,this,&errMsg);  
    if( errCode != SQLITE_OK )  
        log( "execute failed, error code:%d ，reason:%s\n" , errCode, errMsg );     
}  
  
/***********************************************************
* name: getDataCount
* arguments: table_name
* returns/side-effects: int
* description:
* 获取指定表中数据行数
***********************************************************/
int SQLiteConnection::getDataCount( string table_name )  
{  
    if(state != CONNECTED)
    {
        log( "Please open database first!"  );  
        return 0;
    }
    op = GET_COUNT;
    string sqlstr =  "select count(*) from " + table_name;  
    resetRowData();
    sqlite3_exec( pDB, sqlstr.c_str() , SQLiteConnection::loadRecord, this, &errMsg );  
    return rowRount;  
}  

/***********************************************************
* name: loadRecord
* arguments: 
* returns/side-effects: int
* description:
* exec的回调函数
***********************************************************/
int SQLiteConnection::loadRecord( void * para, int n_column, char ** column_value, char ** column_name )  
{  
    SQLiteConnection::log("n_column:%d",n_column);  
    SQLiteConnection* pCon= (SQLiteConnection*)para;

    pCon->colRount = n_column;
    if(pCon->op != SELECT)
    {
        pCon->rowRount = string2int(column_value[0]);
        pCon->state = CONNECTED;
        return 0;
    }

    SQLiteRowData* pRow = new SQLiteRowData();
    for(int i=0;i<n_column;i++)
    {        
        pRow->row .insert(map<string,   string>::value_type(column_name[i],column_value[i]));        
    }
    pCon->result.push_back(pRow);
    pCon->rowRount++;
    return 0;  
}  

/***********************************************************
* name: read
* arguments: index
* returns/side-effects: string
* description:
* 读取当前行，指定列的数据(index为列编号)
***********************************************************/
string SQLiteConnection::read(int index)  
{  
    if(state != CONNECTED)
    {
        log( "Please open database first!"  );  
        return string("\0");
    }
    if(rowRount == 0)
    {
        return string("\0");
    }
    if(index > colRount)
    {
        log( "index overflow!"  );  
        return string("\0");
    }
    map<string,string>::iterator iter = result[currentRow]->row.begin();
    while(index--)
    {
        iter++;
    }

    return (*iter).second;
}  

/***********************************************************
* name: read
* arguments: index
* returns/side-effects: string
* description:
* 读取当前行，指定列的数据(col_name为列名)
***********************************************************/
string SQLiteConnection::read(string col_name)  
{  
    if(state != CONNECTED)
    {
        log( "Please open database first!"  );  
        return string("\0");
    }
    if(rowRount == 0)
    {
        return string("\0");
    }
    return result[currentRow]->row[col_name];
}  

/***********************************************************
* name: getAllData
* arguments: 
* returns/side-effects: string
* description:
* 返回所有数据
***********************************************************/
vector<SQLiteRowData*> SQLiteConnection::getAllData()  
{  
    return result;
}    

/***********************************************************
* name: next
* arguments: 
* returns/side-effects: bool
* description:
* 判断是否还存在下一条记录
***********************************************************/
bool SQLiteConnection::next()
{
    bool b = currentRow >= rowRount-1 ? false:true;
    if(b == false)
    {
        currentRow = 0;
    }
    else
    {
        currentRow++;
    }
    return b;
}

/***********************************************************
* name: getDataCount
* arguments: 
* returns/side-effects: int
* description:
* 获取数据行数
***********************************************************/
int SQLiteConnection::getDataCount()
{
    return rowRount;
}

/***********************************************************
* name: close
* arguments: 
* returns/side-effects: bool
* description:
* 关闭数据库
***********************************************************/
void SQLiteConnection::close()  
{  
    state = CLOSED;
    rowRount = 0;
    sqlite3_close(pDB);  
}  