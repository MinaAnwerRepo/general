using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.IO;
using SQLite;

namespace APPwithSqlLite
{
    class SqlLitedbCreator
    {
         public string dbPath { get; set; } 

        public SqlLitedbCreator(string _dbPath)
        {
             dbPath = _dbPath;
            if (!File.Exists(dbPath))
            {
                var db = new SQLiteConnection(dbPath);
                db.CreateTable<Departments>();
               
            }
        }

       
    }
    [Table("Departments")]
    public class Departments
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
        [MaxLength(8)]
        public string FullName { get; set; }
    }

}