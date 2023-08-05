using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using PSamples.Services;
using PSamples.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace PSamples.ViewModels
{
    public class ViewAViewModel : BindableBase, INavigationAware
    {
        private string _myLabel = String.Empty;
        private IDialogService _dialogService;
        private IMessageService _messageService;
        public string MyLabel
        {
            get { return _myLabel; }
            set { SetProperty(ref _myLabel, value); }
        }

        public ViewAViewModel(IDialogService dialogService) : this(dialogService, new MessageService())
        {

        }

        public ViewAViewModel(IDialogService dialogService, IMessageService messageService)
        {
            _dialogService = dialogService;
            _messageService = messageService;
            OKButton = new DelegateCommand(OKButtonExecute);
            OKButton2 = new DelegateCommand(OKButton2Execute);
        }

        public DelegateCommand OKButton { get; }
        public DelegateCommand OKButton2 { get; }

        private void OKButtonExecute ()
        {
            //MessageBox.Show("Save");
            var p = new DialogParameters();
            p.Add(nameof(ViewBViewModel.ViewBTextBox), "Save");
            _dialogService.ShowDialog(nameof(ViewB), p, null);
        }
        private void OKButton2Execute()
        {
            //MessageBox.Show("Save");
            if (_messageService.Question("Saveしますか？") == MessageBoxResult.OK)
            {
                _messageService.ShowDialog("Saveしました");
            }
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            MyLabel = navigationContext.Parameters.GetValue<string>(nameof(MyLabel));
        }

        /// <summary>
        /// インスタンスを使いまわすかどうか
        /// </summary>
        /// <param name="navigationContext"></param>
        /// <returns></returns>
        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return false;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }
    }
}
