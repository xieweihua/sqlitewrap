
- ʹ��˵��

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
    
    //�����ݿ�
    if(db->open(fullDBPath.c_str()) != true)
    {
      cout<<"init failed!"<<endl;
      return 0;
    }
   
    string table = "test";
    //�ж����ݱ��Ƿ����
    bool b = db->tableIsExist(table);
    cout<<table+":"<<b<<endl;
    if(b == false)
    {
      //ִ��sql���
      db->exec(create);
    }
    db->exec(insert);
    db->exec(insert2);
    db->exec(insert3);
    //ָ������������
    cout<<table+":"<<db->getDataCount(table)<<endl;
    
    db->exec(select);
    //���select���ķ�������
    cout<<table+":"<<db->getDataCount()<<endl;
    
    //ͨ��������ȡ����
    cout<<db->read("id")<<" ";
    cout<<db->read("value")<<endl;
    //�ж��Ƿ������һ������
    while(db->next())
    {
        //ͨ����������ȡ����
        cout<<db->read(0)<<" ";
        cout<<db->read(1)<<endl;
    }

    db->close();
    delete db;
    return 0;
}
```