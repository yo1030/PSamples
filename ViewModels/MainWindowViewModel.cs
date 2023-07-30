using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using PSamples.Views;

namespace PSamples.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private IRegionManager _regionManager;
        private IDialogService _dialogService;
        private string _title = "Prism Application Sample";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public MainWindowViewModel(IRegionManager regionManager, IDialogService dialogService)
        {
            _regionManager = regionManager;
            _dialogService = dialogService;
            SystemDateUpdateBtn = new DelegateCommand(SystemDateUpdateBtnExecute);
            ShowViewABtn = new DelegateCommand(ShowViewABtnExecute);
            ShowViewPBtn = new DelegateCommand(ShowViewPBtnExecute);
            ShowViewBBtn = new DelegateCommand(ShowViewBBtnExecute);
        }

        //SystemDateLabel
        private string _systemDateLabel = System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
        public string SystemDateLabel
        {
            get { return _systemDateLabel; }
            set { SetProperty(ref _systemDateLabel, value); }
        }

        //SystemDateUpdateBtn
        public DelegateCommand SystemDateUpdateBtn { get; }

        private void SystemDateUpdateBtnExecute()
        {
            SystemDateLabel = System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
        }
        public DelegateCommand ShowViewABtn { get; }
        public DelegateCommand ShowViewPBtn { get; }
        public DelegateCommand ShowViewBBtn { get; }

        private void ShowViewABtnExecute()
        {
            _regionManager.RequestNavigate("ContentRegion", nameof(ViewA));
        }
        private void ShowViewPBtnExecute()
        {
            var p = new NavigationParameters();
            p.Add(nameof(ViewAViewModel.MyLabel), SystemDateLabel);
            _regionManager.RequestNavigate("ContentRegion", nameof(ViewA), p);
        }
        private void ShowViewBBtnExecute()
        {
            var p = new DialogParameters();
            p.Add(nameof(ViewBViewModel.ViewBTextBox), SystemDateLabel);
            _dialogService.ShowDialog(nameof(ViewB), p, null);
        }
    }
}
