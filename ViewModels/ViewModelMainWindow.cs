using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace MathOptimizer.MVVM
{
    class ViewModel : ViewModelBase
    {
        public ViewModel()
        {
            // Build commands
            ParseCommand = new RelayCommand((obj) => ParseMethod(), null);
            EvaluateCommand = new RelayCommand((obj) => EvaluateMethod(), null);
            OptimizeCommand = new RelayCommand((obj) => OptimizeMethod(), null);

            Log = new ObservableCollection<string>();
        }

        /* Binded properties */
        public string Expression
        {
            get { return expression; }
            set
            {
                expression = value;
                OnPropertyChanged("Expression");
            }
        }
        public string ConstExpression
        {
            get { return constExpression; }
            set
            {
                constExpression = value;
                OnPropertyChanged("ConstExpression");
            }
        }
        public string VarExpression
        {
            get { return varExpression; }
            set
            {
                varExpression = value;
                OnPropertyChanged("VarExpression");
            }
        }
        public ObservableCollection<string> Log { get; }

        /* Commands */
        public RelayCommand ParseCommand    { get; }
        public RelayCommand EvaluateCommand { get; }
        public RelayCommand OptimizeCommand { get; }
        
        private void ParseMethod()
        {
            if (!String.IsNullOrEmpty(Expression))
            {
                try
                {
                    model.ParseExp(Expression, ConstExpression);
                    VarExpression = convertVariables(model.Variables);

                    AddLog("The function was successfully parsed");
                }
                catch (Exception exc)
                {
                    AddLog(CreateLogRecord(exc));
                }
            }
        }
        private void EvaluateMethod()
        {
            try
            {
                model.Evaluate(VarExpression);
                AddLog(String.Format("Evaluate result:\n---> Point({0})", model.EvaluateResult));
            }
            catch (Exception exc)
            {
                AddLog(CreateLogRecord(exc));
            }
        }
        private void OptimizeMethod()
        {
            try
            {
                model.Optimize(VarExpression);
                AddLog(String.Format("Optimize result:\n---> Point({0})\n---> Iterations({1})", model.OptimizeResult_point, model.OptimizeResult_iterations));
            }
            catch (Exception exc)
            {
                AddLog(CreateLogRecord(exc));
            }
        }

        private string convertVariables(string[] variables)
        {
            StringBuilder convertedString = new StringBuilder();

            foreach (string var in variables)
            {
                convertedString.Append(String.Format("{0} = ;\n", var));
            }

            return convertedString.ToString();
        }
        private string CreateLogRecord(Exception exc)
        {
            StringBuilder errorMsg = new StringBuilder();

            errorMsg.Append(String.Format("*Error* {0} - {1}", exc.Source, exc.Message));

            foreach (object obj in exc.Data.Keys)
            {
                errorMsg.Append(String.Format("\n--->{0}: \"{1}\"", exc.Data[obj], obj));
            }

            /*TEST*/
            //errorMsg.Append(exc.StackTrace);

            return errorMsg.ToString();
        }
        private void AddLog(string text)
        {
            Log.Add(String.Format("\n{0}:  {1}", System.DateTime.Now, text));
        }

        private string expression;
        private string constExpression;
        private string varExpression;
        private ObservableCollection<string> log = new ObservableCollection<string>();

        /* Model */
        private readonly MathOptimizerModel model = new MathOptimizerModel();
    }
}
