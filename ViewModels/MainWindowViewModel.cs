﻿using Prism.Mvvm;

namespace Shell.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = Properties.Resources.Title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public MainWindowViewModel()
        {

        }
    }
}
