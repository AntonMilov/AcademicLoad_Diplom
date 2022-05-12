using NavigationModule;
using Prism.Mvvm;

namespace Shell.ViewModels
{
    /// <inheritdoc/>
    public class MainWindowViewModel : BindableBase
    {
        private Navigator a;
        private string _title = Properties.Resources.Title;

        
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        /// <inheritdoc/>
        public MainWindowViewModel( Navigator navigator)
        {
            a = navigator;
        }
    }
}
