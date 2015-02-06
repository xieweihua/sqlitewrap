#include "string"
#include <iostream>
#include "SQLiteConnection.h"
using namespace std;

int main()
{
  /* Test Database*/  
    string fullDBPath = "save.db";  
    SQLiteConnection* db = new SQLiteConnection();
    string create = "create table test (id int,value varchar(255))";
    string insert = "insert into test(id,value) values(1,'test data')";
    string insert2 = "insert into test(id,value) values(2,'my')";
    string insert3 = "insert into test(id,value) values(3,'game')";
    string select = "select * from test";

    if(db->open(fullDBPath.c_str()) != true)
    {
      cout<<"init failed!"<<endl;
      return 0;
    }
   
    string table = "test";
    bool b = db->tableIsExist(table);
    cout<<table+":"<<b<<endl;
    if(b == false)
    {
      db->exec(create);
    }
    cout<<table+":"<<db->tableIsExist(table)<<endl;
    cout<<table+":"<<db->getDataCount(table)<<endl;
    db->exec(insert);
    db->exec(insert2);
    db->exec(insert3);
    db->exec(select);
    cout<<table+":"<<db->getDataCount()<<endl;
    cout<<db->read("id")<<" ";
    cout<<db->read("value")<<endl;
    while(db->next())
    {
        cout<<db->read(0)<<" ";
        cout<<db->read(1)<<endl;
    }

    db->close();
    delete db;
    return 0;
}