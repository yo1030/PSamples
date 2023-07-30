using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using PSamples.Views;

namespace PSamples.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private IRegionManager _regionManager;
        private string _title = "Prism Application Sample";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public MainWindowViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
            SystemDateUpdateBtn = new DelegateCommand(SystemDateUpdateBtnExecute);
            ShowViewABtn = new DelegateCommand(ShowViewABtnExecute);
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

        private void ShowViewABtnExecute()
        {
            _regionManager.RequestNavigate("ContentRegion", nameof(ViewA));
        }
    }
}
