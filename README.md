
- 使用说明

```c
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
    
    //打开数据库
    if(db->open(fullDBPath.c_str()) != true)
    {
      cout<<"init failed!"<<endl;
      return 0;
    }
   
    string table = "test";
    //判断数据表是否存在
    bool b = db->tableIsExist(table);
    cout<<table+":"<<b<<endl;
    if(b == false)
    {
      //执行sql语句
      db->exec(create);
    }
    db->exec(insert);
    db->exec(insert2);
    db->exec(insert3);
    //指定表数据行数
    cout<<table+":"<<db->getDataCount(table)<<endl;
    
    db->exec(select);
    //获得select语句的返回行数
    cout<<table+":"<<db->getDataCount()<<endl;
    
    //通过列名读取数据
    cout<<db->read("id")<<" ";
    cout<<db->read("value")<<endl;
    //判断是否存在下一条数据
    while(db->next())
    {
        //通过列索引读取数据
        cout<<db->read(0)<<" ";
        cout<<db->read(1)<<endl;
    }

    db->close();
    delete db;
    return 0;
}
```