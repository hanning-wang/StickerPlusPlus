using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TodoLibrary;

namespace Sticker__
{
    /// <summary>
    /// Minimize.xaml 的交互逻辑
    /// </summary>
    public partial class Minimize : Window
    {
        public Minimize()
        {
            InitializeComponent();
            LoadExsistTodoList();
            LoadExsistStickerList();
        }
        private void LoadExsistTodoList()
        {
            //Load Data From SQLite
            PublicTodoListModule.TodoList = SqliteDataAccess.LoadTodo();
            WireUpTodoList();
        }
        private void LoadExsistStickerList()
        {
            //Load Data From SQLite
            PublicTodoListModule.TodoList = SqliteDataAccess.LoadTodo();
            WireUpTodoList();
        }
        private void WireUpTodoList()
        {
            //Insert Todo List From SQLite
            int k = PublicTodoListModule.TodoList.Count();
            TodoModel temp = new TodoModel();
            temp = PublicTodoListModule.TodoList[k - 1];
            PublicTodoListModule.TodoTag = temp.Tag + 1;
            PublicTodoListModule.exsistTodo = k;
            for (int i = 0; i < k; i++)
            {
                PublicTodoListModule.passTodoInformation = PublicTodoListModule.TodoList[i];
                if (i == k - 1)
                {
                    PublicTodoListModule.ending = true;
                }
                TodoListControl Todo = new TodoListControl();
                WrapPanel1.Children.Add(Todo);
            }
        }
    }
}
