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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TodoLibrary;

namespace Sticker__
{
    /// <summary>
    /// TodoListControl.xaml 的交互逻辑
    /// </summary>
    
    public partial class TodoListControl : UserControl
    {
        private int thisTodoTag;
        TodoModel p = new TodoModel();
        private int nowinPublicTodoListModule;
        public TodoListControl()
        {
            InitializeComponent();
            Init();
        }
        private void Init()
        {
            if (PublicTodoListModule.ending == false)
            {
                thisTodoTag = p.Tag;
                p.Tag = PublicTodoListModule.passTodoInformation.Tag;
                p.isChecked = PublicTodoListModule.passTodoInformation.isChecked;
                p.Priority = PublicTodoListModule.passTodoInformation.Priority;
                p.TodoText = PublicTodoListModule.passTodoInformation.TodoText;
                p.Color = PublicTodoListModule.passTodoInformation.Color;
            }
            else
            {
                thisTodoTag = p.Tag;
                p.Tag = PublicTodoListModule.TodoTag;
                p.isChecked = 0;
                p.Priority = 0;
                p.TodoText = TodoThing.Text;
                p.Color = "Default";
                SqliteDataAccess.SaveTodo(p);
                PublicTodoListModule.TodoList.Add(p);
                nowinPublicTodoListModule = PublicTodoListModule.TodoList.Count();
            }

            
        }

        private void TodoThing_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            p.TodoText = TodoThing.Text;
            SqliteDataAccess.ModifyItem(p);
            PublicTodoListModule.TodoList[nowinPublicTodoListModule - 1] = p;
        }
    }
}
