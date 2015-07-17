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

        public DataTable ReadFormula(string tableName, string name_list)
        {
            command.CommandText = "SELECT name,price FROM " + tableName + " where name in " + name_list;
            SQLiteDataAdapter da = new SQLiteDataAdapter(command);
            DataTable dt = new DataTable(tableName);
            da.Fill(dt);
            return dt;
        }
        //读取数据表记录
        public DataTable ReadTable(string tableName)
        {
            command.CommandText = "SELECT id,name,price,desc FROM " + tableName;
            SQLiteDataAdapter da = new SQLiteDataAdapter(command);
            DataTable dt = new DataTable(tableName);
            da.Fill(dt);
            return dt;
        }
        //读取数据表记录
        public DataTable ReadTableByName(string tableName, string key)
        {
            command.CommandText = "SELECT id FROM " + tableName + " where name='" + key + "'";
            SQLiteDataAdapter da = new SQLiteDataAdapter(command);
            DataTable dt = new DataTable(tableName);
            da.Fill(dt);
            return dt;
        }

        //读取数据表记录
        public DataTable ReadTableByNameFuzzy(string tableName, string key)
        {
            command.CommandText = "SELECT id,name,price,desc  FROM " + tableName + " where name like '%" + key + "%'";
            SQLiteDataAdapter da = new SQLiteDataAdapter(command);
            DataTable dt = new DataTable(tableName);
            da.Fill(dt);
            return dt;
        }
        //修改数据表记录
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

