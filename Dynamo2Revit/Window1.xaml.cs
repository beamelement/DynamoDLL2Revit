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

using System.Windows.Forms;

namespace Dynamo2Revit
{
    /// <summary>
    /// Window1.xaml 的交互逻辑
    /// </summary>
    public partial class Window1 : Window
    {

        public bool Done;
        public bool selected;
        public string fileName;

        public Window1()
        {
            InitializeComponent();
        }


        private void selection(object sender, RoutedEventArgs e)
        {
            selected = true;
            this.window.Hide();


            //打开一个对话框，选取某种类型文件并获取其路径
            OpenFileDialog d = new OpenFileDialog();

            d.InitialDirectory = @"C:\Users\zyx\Desktop\"; //默认路径
            d.Filter = "dynamo文件(*.dyn)|*.dyn";//要选择的文件
            //d.Filter = "所有文件(*.*)|*.*";

            if (d.ShowDialog()== System.Windows.Forms.DialogResult.OK)
            {
                this.fileName = d.FileName;
            }

        }

        private void DoneClick(object sender, RoutedEventArgs e)
        {
            Done = true;
            DialogResult = true;
        }






    }
}
