using System;
using System.Windows;
using System.Windows.Input;
using System.Collections.Generic;
using System.Windows.Controls;

namespace task_12._1.Windows
{
    /// <summary>
    /// Interaction logic for AddNewUserWindow.xaml
    /// </summary>
    public partial class AddNewUserWindow : Window
    {
        MainViewModel vm;
        public ICommand AddCommand { get; private set; }
        public AddNewUserWindow(MainViewModel vm)
        {
            InitializeComponent();
            AddCommand = new DelegateCommand(AddNewClient, CanBeAdded);
            this.vm = vm;
        }

        private bool CanBeAdded(object arg)
        {
            throw new NotImplementedException();
        }

        private void AddNewClient(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
