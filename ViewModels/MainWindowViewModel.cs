using Prism.Commands;
using Prism.Mvvm;

namespace PSamples.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "Prism Application Sample";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public MainWindowViewModel()
        {
            SystemDateUpdateBtn = new DelegateCommand(SystemDateUpdateBtnExecute);
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
    }
}
