using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using Dapper;

namespace TodoLibrary
{
    public class SqliteDataAccess
    {
        public static List<TodoModel> LoadTodo()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<TodoModel>("select * from Todo", new DynamicParameters());
                return output.ToList();
            }
        }
        public static void SaveTodo(TodoModel Todo)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("insert into Todo(Tag, Color, Priority, TodoText, IsChecked) values(@Tag, @Color, @Priority, @TodoText, @isChecked)", Todo);
            }
        }
        public static void ModifyItem(TodoModel Todo)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("update Todo set Color = @Color, Priority = @Priority , TodoText = @TodoText, IsChecked = @IsChecked WHERE Tag=@Tag", Todo);
            }
        }
        private static string LoadConnectionString(string tag="Todo")
        {
            return ConfigurationManager.ConnectionStrings[tag].ConnectionString;
        }
    }
}
