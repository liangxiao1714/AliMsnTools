using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.Text;
using System.Data;
using System.Linq.Expressions;
using System.Threading;
using ServiceStack.OrmLite.MySql;

namespace AliMsnTools.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.Write("Hello World");

            var dbFactory = new OrmLiteConnectionFactory("", MySqlDialectProvider.Instance);

            using (var db = dbFactory.Open())
            {
                if (db.CreateTableIfNotExists<Poco>())
                {
                    db.Insert(new Poco { Id = 1, Name = "Seed Data" });

                    var aaa= db.Select<Poco>(p => p.Id == 1);
                }

            }
        }
    }

    class Poco
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
