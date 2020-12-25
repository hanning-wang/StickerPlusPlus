using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoLibrary;
namespace Sticker__
{
    public class PublicTodoListModule
    {

        public static List<TodoModel> TodoList = new List<TodoModel>();

        public static int exsistTodo;
        public static int TodoTag;
        public static TodoModel passTodoInformation;//传TodoInformation到TodoListControl
        public static bool ending = false;//判断Todo List是否传完
    }
}
