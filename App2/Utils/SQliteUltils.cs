using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLitePCL;

namespace App2.Utils
{
    class SQliteUltils
    {
        private static SQliteUltils _instance;
        public SQLiteConnection Connection { get; }
        public static SQliteUltils GetIntances()
        {
            if (_instance == null)
            {
                _instance = new SQliteUltils();
            }
            return _instance;
        }
        private SQliteUltils()
        {
            Connection = new SQLiteConnection("ok.db");
            CreateTables();
        }
        private void CreateTables()
        {
            string sql = @"CREATE TABLE IF NOT EXISTS Note (Id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,Name VARCHAR( 140 ),PhoneNumber VARCHAR( 140 );";
            using (var statement = Connection.Prepare(sql))
            {
                statement.Step();
            }
        }
    }
}
