using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using PSamples.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace PSamples.ViewModels
{
    public class ViewCViewModel : BindableBase, IConfirmNavigationRequest
    {
        private IMessageService _messageService;

        public ViewCViewModel(): this(new MessageService())
        {

        }
        public ViewCViewModel(IMessageService messageService)
        {
            _messageService = messageService;
            MyListBox.Add("AAAAA");
            MyListBox.Add("SSSSS");
            MyListBox.Add("DDDDD");
        }

        //MyListBox
        private ObservableCollection<string> _myListBox = new ObservableCollection<string>();
        public ObservableCollection<string> MyListBox
        {
            get { return _myListBox; }
            set { SetProperty(ref _myListBox, value); }
        }


        public void ConfirmNavigationRequest(NavigationContext navigationContext, Action<bool> continuationCallback)
        {
            if (_messageService.Question("閉じますか？") == System.Windows.MessageBoxResult.OK)
            {
                continuationCallback(true);
            }
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return false;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
        }
    }
}
