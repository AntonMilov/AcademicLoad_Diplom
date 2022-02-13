using Prism.Mvvm;

namespace AcademicLoadModule.ViewModels
{
    public class TeachersViewModel : BindableBase
    {
        private string _message;
        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }

        public TeachersViewModel()
        {
            Message = "View A from your Prism Module";
        }
    }
}
