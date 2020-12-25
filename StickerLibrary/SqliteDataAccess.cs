using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using Dapper;

namespace StickerLibrary
{
    public class SqliteDataAccess
    {
        public static List<StickerModel> LoadTodo()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<StickerModel>("select * from Sticker", new DynamicParameters());
                return output.ToList();
            }
        }
        public static void SaveTodo(StickerModel Todo)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("insert into Todo(Tag, Title, Text) values(@Tag, @Title, @Text)", Todo);
            }
        }
        private static string LoadConnectionString(string tag = "Sticker")
        {
            return ConfigurationManager.ConnectionStrings[tag].ConnectionString;
        }
    }
}
