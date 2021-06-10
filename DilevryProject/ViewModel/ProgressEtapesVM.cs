using Syncfusion.XForms.ProgressBar;
using System.Windows.Input;
using Xamarin.Forms;

namespace DilevryProject.ViewModel
{
    public enum StepViews
    {
        NotStarted, InProgress, Completed
    }
    class ProgressEtapesVM:BaseVM
    {

        private StepStatus _UserInfo;
        public StepStatus UserInfo { get => _UserInfo; set => SetValue(ref _UserInfo, value); }
        private StepStatus _DilevryInfo;
        public StepStatus DilevryInfo { get => _DilevryInfo; set => SetValue(ref _DilevryInfo, value); }
        private StepStatus _End;
        public StepStatus End { get => _End; set => SetValue(ref _End, value); }
        public ProgressEtapesVM()
        {

            UserInfo = StepStatus.InProgress ;
            DilevryInfo = StepStatus.NotStarted;
            End = StepStatus.NotStarted;


        }
        public ICommand Test
        {

            get => new Command(() =>
             {
                 if(UserInfo == StepStatus.InProgress)
                 {
                     UserInfo = StepStatus.Completed;
                     DilevryInfo = StepStatus.InProgress;
                     End = StepStatus.NotStarted;
                 }else if(DilevryInfo== StepStatus.InProgress)
                 {
                     End = StepStatus.InProgress;
                     DilevryInfo = StepStatus.Completed;
                    
                 }else if (End == StepStatus.InProgress)
                 {  
                     End = StepStatus.Completed;
                 }
             });
        }

    }
}
