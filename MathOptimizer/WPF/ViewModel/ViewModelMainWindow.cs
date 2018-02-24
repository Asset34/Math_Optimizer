using System;
using System.Text;
using System.Windows.Input;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using MathOptimizer.Methods.Params;
using MathOptimizer.WPF.Model;
using MathOptimizer.WPF.Commands;

namespace MathOptimizer.WPF.ViewModel
{
    class ViewModelMainWindow : ViewModelBase
    {
        /* Linked properties */
        public string Expression
        {
            get { return m_expression; }
            set { m_expression = value; OnPropertyChanged("Expression"); }
        }
        public string Constants
        {
            get { return m_constants; }
            set { m_constants = value;  OnPropertyChanged("Constants"); }
        }
        public string Variables
        {
            get { return m_variables; }
            set { m_variables = value;  OnPropertyChanged("Variables"); }
        }
        public bool IsParsed
        {
            get { return m_isparsed; }
            set { m_isparsed = value; OnPropertyChanged("IsParsed"); }
        }
        public ObservableCollection<string> Log
        {
            get { return m_log; }
            set { m_log = value; OnPropertyChanged("Log"); }
        }

        /* Commands */
        public ICommand ParseCommand { get; set; }
        public ICommand EvaluateCommand { get; set; }
        public ICommand OptimizeCommand { get; set; }
        public ICommand ClearLogCommand { get; set; }

        public ViewModelMainWindow()
        {
            Log = new ObservableCollection<string>();
            IsParsed = false;

            ParseCommand = new RelayCommand(arg => ParseMethod());
            EvaluateCommand = new RelayCommand(arg => EvaluateMethod());
            OptimizeCommand = new RelayCommand(arg => OptimizeMethod());
            ClearLogCommand = new RelayCommand(arg => ClearLogMethod());
        }

        /* Command handlers */
        private void ParseMethod()
        {
            try
            {
                List<string> vars = m_model.Parse(Expression, Constants);

                // Build variables string
                StringBuilder sb = new StringBuilder();
                foreach (string var in vars)
                {
                    sb.Append(string.Format("{0} = ; ", var));
                }
                Variables = sb.ToString();

                IsParsed = true;
                AddLog("The parsing was successful");
            }
            catch (Exception ex)
            {
                IsParsed = false;
                AddExceptionLog(ex);
            }
        }
        private void EvaluateMethod()
        {
            try
            {
                double result = m_model.Evaluate(Variables);
                AddLog(string.Format("Evaluation result: {0}", result));
            }
            catch (Exception ex)
            {
                AddExceptionLog(ex);
            }
        }
        private void OptimizeMethod()
        {
            try
            {
                OutputParameters output = m_model.Optimize(Variables);

                StringBuilder sb = new StringBuilder();
                sb.Append("Optimization result:");
                sb.Append(string.Format("\n--> Min: {0}", output.ResultVecPoint));
                sb.Append(string.Format("\n--> Iterations: {0}",  output.Iterations));

                AddLog(sb.ToString());
            }
            catch (Exception ex)
            {
                AddExceptionLog(ex);
            }
        }
        private void ClearLogMethod()
        {
            Log.Clear();
        }

        /* Additional methods */
        private void AddLog(string msg)
        {
            Log.Add(string.Format("\n{0}   {1}", DateTime.Now, msg));
        }
        private void AddExceptionLog(Exception ex)
        {
            StringBuilder msg = new StringBuilder();
            msg.Append(string.Format("#Error from '{0}': {1}", ex.Source, ex.Message));

            if (ex.Data.Contains("Errors"))
            {
                List<KeyValuePair<string, string>> errors = (List<KeyValuePair<string, string>>)ex.Data["Errors"];

                foreach (KeyValuePair<string, string> pair in errors)
                {
                    msg.Append(string.Format("\n--> {0} : {1}", pair.Key, pair.Value));
                }
            }
            

            AddLog(msg.ToString());
        }

        private string m_expression;
        private string m_constants;
        private string m_variables;
        private bool m_isparsed;
        private ObservableCollection<string> m_log;

        private readonly ExpHandler m_model = new ExpHandler();
    }
}
