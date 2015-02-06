#pragma once
#include "string"
#include   <map> 
#include <vector>
#include "sqlite3.h"

using namespace std;

enum operation_type
{
    GET_COUNT,
    IS_EXIST,
    SELECT
};

enum CONNECT_STATE 
{
    CLOSED,
    EXECUTING,
    CONNECTED
};

class SQLiteRowData
{
public:
    SQLiteRowData(){}
    ~SQLiteRowData(){}

    map<string,string> row;
};

class SQLiteConnection
{  
public:  
    /************************************************************ 
            ·â×° sqlite3²Ù×÷ 
     ************************************************************/  
    SQLiteConnection();
    ~SQLiteConnection();

    bool open(const char *db);     
    bool tableIsExist(string table_name);  
    int getDataCount(string table_name); 
    int getDataCount();  
    void getColInfo(){};
    void exec(string sql);
    bool next();
    void close();  
    void resetRowData();
    static int string2int(string s_value);
    static string int2string(int i_value);

    string read(int index);
    string read(string name);
    vector<SQLiteRowData*> getAllData();
    vector<SQLiteRowData*> result;
    CONNECT_STATE state;
private:
    static void log(char* format, ...);
    static int loadRecord( void * para, int n_column, char ** column_value, char ** column_name );     

    int errCode;
    char * errMsg;
    sqlite3 *pDB;   
    int currentRow;
    int rowRount;
    int colRount;
    operation_type op;
};  