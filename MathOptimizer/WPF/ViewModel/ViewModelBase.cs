using System.ComponentModel;

namespace MathOptimizer.WPF.ViewModel
{
    //
    // Summary:
    //     Represents a base class for classes which notifies the View
    class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
