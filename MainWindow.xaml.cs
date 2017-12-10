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

using MathOptimizer.Parser;
using MathOptimizer;

namespace MathOptimizer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnParse_Clicked(object sender, RoutedEventArgs e)
        {
            
        }
        private void btnEvaluate_Clicked(object sender, RoutedEventArgs e)
        {

            //Function f = MathExpressionParser.Parse(txtExp.Text);

            //try
            //{
            //    Vector vec = MathExpressionParser.ParseVariables(f, txtVariables.Text);

            //    Log(vec.ToString());
            //}
            //catch (Exception exc)
            //{
            //    StringBuilder text = new StringBuilder();

            //    text.Append(String.Format("Error *{0}*: {1}", exc.Source, exc.Message));

            //    foreach (object obj in exc.Data.Keys)
            //    {
            //        text.Append(String.Format("\n---> {0}: \"{1}\"", exc.Data[obj], obj));
            //    }

            //    Log(text.ToString());
            //}
        }
        private void btnOptimize_Clicked(object sender, RoutedEventArgs e)
        {

        }

        private void Log(string text)
        {
        }
    }
}
