using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;


namespace SQLiteView
{
    class DataAccess
    {
        SQLiteConnection con ;
        SQLiteCommand command;
        public DataAccess()
        {
            con = new SQLiteConnection("Data Source=test.db3");
            command = con.CreateCommand();
        }
        //��ȡ���ݱ���¼
        public DataTable ReadTable(string tableName)
        {
            command.CommandText = "SELECT * FROM " + tableName;
            SQLiteDataAdapter da = new SQLiteDataAdapter(command);
            DataTable dt = new DataTable(tableName);
            da.Fill(dt);
            return dt;
        }

        //��ȡ���ݱ���¼
        public DataTable ReadTableByName(string tableName, String key)
        {
            command.CommandText = "SELECT * FROM " + tableName + " where name like '%" + key + "%'";
            SQLiteDataAdapter da = new SQLiteDataAdapter(command);
            DataTable dt = new DataTable(tableName);
            da.Fill(dt);
            return dt;
        }
        //�޸����ݱ���¼
        public bool UpdateTable(DataTable srcTable, string tableName)
        {
            bool isok = false;
            try
            {
                command.CommandText = "SELECT * FROM " + tableName;
                SQLiteDataAdapter oda = new SQLiteDataAdapter(command);
                SQLiteCommandBuilder ocb = new SQLiteCommandBuilder(oda);
                oda.InsertCommand = ocb.GetInsertCommand();
                oda.DeleteCommand = ocb.GetDeleteCommand();
                oda.UpdateCommand = ocb.GetUpdateCommand();
                oda.Update(srcTable);
                isok = true;
            }
            catch (Exception ex)
            {}
            return isok;
        }
    }
}
