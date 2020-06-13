using System;
using MvvmCross.Commands;
using MvvmCross.ViewModels;

namespace Pokedex.Core.ViewModels
{
    public class TestViewModel : MvxViewModel
    {
        private string _description;

        public string Description
        {
            get => _description;
            set => SetProperty(ref _description, value);
        }

        public MvxCommand ClearCommand { get; private set; }

        public TestViewModel()
        {
            ClearCommand = new MvxCommand(OnClearCommand);
        }

        private void OnClearCommand()
        {
            Description = string.Empty;
        }
    }
}
