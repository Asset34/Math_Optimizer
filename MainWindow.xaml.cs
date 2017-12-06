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
            try
            {
                // Reset
                txtVariables.Clear();

                TakeConstants();

                // Parse
                string[] variables = FunctionContainer.Parser(txtExp.Text);
                VariableLog(variables);

                Log("The function was successfully parsed");
            }
            catch (Exception exc)
            {
                StringBuilder text = new StringBuilder();

                text.Append(String.Format("{0}: {1}\n", exc.Source, exc.Message));

                foreach (object obj in exc.Data.Keys)
                {
                    text.Append(String.Format("---> Token: {0}\n", exc.Data[obj]));
                }

                Log(text.ToString());
            }
        }
        private void btnEvaluate_Clicked(object sender, RoutedEventArgs e)
        {
            double result = FunctionContainer.Evaluate(TakeVector());

            Log("Result: " + result.ToString());
        }
        private void btnOptimize_Clicked(object sender, RoutedEventArgs e)
        {
            Vector result = FunctionContainer.Optimize(TakeVector());

            Log("Result: " + result.ToString());
        }

        private void Log(string text)
        {
            txtLog.AppendText(DateTime.Now + " : " + text + "\n");
        }
        private void VariableLog(string[] variables)
        {
            for (int i = 0; i < variables.Length - 1; i++)
            {
                txtVariables.AppendText(variables[i] + "= ;\n");
            }

            txtVariables.AppendText(variables[variables.Length - 1] + "=");
        }
        private void TakeConstants()
        {
            try
            {
                if (!String.IsNullOrEmpty(txtConstants.Text))
                {
                    string constString = txtConstants.Text;
                    constString = constString.Replace(" ", String.Empty);
                    string[] constants = constString.Split(';');

                    foreach (string constant in constants)
                    {
                        string[] values = constant.Split('=');
                        FunctionContainer.AddConstant(values[0], double.Parse(values[1]));
                    }
                }
                
            }
            catch (Exception exp)
            {
                Log("Incorrect format of constant string");
            } 
        }
        private Vector TakeVector()
        {
            double[] values = new double[0];

            try
            {
                
                if (!String.IsNullOrEmpty(txtVariables.Text))
                {
                    string varString = txtVariables.Text;
                    varString = varString.Replace(" ", String.Empty);
                    varString = varString.Replace("/n", String.Empty);
                    string[] variables = varString.Split(';');

                    values = new double[variables.Length];

                    for (int i = 0; i < variables.Length; i++)
                    {
                        values[i] = double.Parse(variables[i].Split('=')[1]);
                    }
                }
            }
            catch (Exception exp)
            {
                Log("Incorrect format of variables strings");
            }

            return new Vector(values);
        }
    }
}
