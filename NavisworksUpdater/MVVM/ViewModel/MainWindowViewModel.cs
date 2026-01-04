
using Autodesk.Navisworks.Api;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media.Media3D;
using Application = Autodesk.Navisworks.Api.Application;
using Timer = System.Windows.Forms.Timer;


namespace NavisworksUpdater.MVVM.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        public ICommand StartTimerCommand { get; }
        public ICommand StopTimerCommand { get; }
        public ICommand CloseCommand { get; }
        public Timer Timer { get; set; } = new Timer();
        private string remainingTime = DateTime.Now.Second.ToString();
        public TimePickerViewModel TimePickerVM { get; set; } = new TimePickerViewModel();
        public string RemainingTime
        {
            get { return remainingTime; }
            set { remainingTime = value; OnPropertyChanged(nameof(RemainingTime)); }

        }
        private string folderPath;

        public string FolderPath
        {
            get { return folderPath; }
            set { folderPath = value; OnPropertyChanged(nameof(FolderPath)); }
        }


        private TimeSpan targetTime ; // 3:00 PM

        public TimeSpan TargetTime
        {
            get { return targetTime; }
            set { targetTime = value; OnPropertyChanged(nameof(TargetTime)); }
        }

        public MainWindowViewModel()
        {
            StartTimerCommand = new RelayCommand(A => StartTimer(A));
            StopTimerCommand = new RelayCommand(Z=>StopTimer(Z));
            CloseCommand = new RelayCommand(C => StopTimer(C));
        }

       
        public void NavisworksUpdater(object sender, EventArgs e)
        {
            targetTime = new TimeSpan(TimePickerVM.SelectedTime.Hour, TimePickerVM.SelectedTime.Minute, 0);
            var now = DateTime.Now;
            var todayTarget = now.Date + TargetTime;

            if (now > todayTarget)
            { todayTarget = todayTarget.AddDays(1); }// next day




            var timeLeft = todayTarget - now;
            var flag = timeLeft.TotalSeconds <1;
            if (flag)
                SaveNwdFiles();
            RemainingTime = timeLeft.ToString(@"hh\:mm\:ss");


        }
        private void StartTimer(object parameter)
        {
            var timer = Timer;
            timer.Interval = 1000;
            timer.Tick += NavisworksUpdater;
            timer.Start();
        }
        private void StopTimer(object parameter) => Timer.Stop();
        
        public void SaveNwdFiles()
        {

            // get document from application
            Document document = Application.ActiveDocument;
            // info message - current file path with appended files
            var message = "Select Bim Folder Path";


            // prompt to select folder path 
            //var folderPath = "W:\\Projects\\Abu Qir\\01 BIM\\01_BIM_Models";
            //var folderPath = @"C:\Users\DELL\Downloads\240708-SEC ROOM (PMC Submission)";
            var folderPath = FolderPath;
            //var folderPath = PromptForFolderPath(message);


            if (string.IsNullOrEmpty(folderPath)) return;



            try
            {
                //get all nwf files 
                var nwfFiles = Directory.GetFiles(folderPath, "*.nwf", searchOption: SearchOption.AllDirectories);
                if (nwfFiles.Length > 0)
                    foreach (var file in nwfFiles)
                    {
                        var doc = Application.ActiveDocument;
                       
                       var isOpened =  doc.TryOpenFile(file);
                       
                        doc.UpdateFiles();
                        string nwfFolderPath = Path.GetDirectoryName(file);
                        var nwdFolderPath = Directory.GetDirectories
                           (Path.GetDirectoryName(nwfFolderPath)).FirstOrDefault(X => X.ToLower().Contains("nwd"));
                        var nwcFolderPath = Directory.GetDirectories
                            (Path.GetDirectoryName(nwfFolderPath)).FirstOrDefault(X => X.ToLower().Contains("nwc"));
                        var nwcFiles = Directory.GetFiles(nwcFolderPath, "*.nwc", searchOption: SearchOption.AllDirectories);
                        var modelItems = Application.ActiveDocument.Models;
                        var targetfiles = new List<string>();    
                        foreach( var nwcFile in nwcFiles)
                        {
                            var isInNWF = modelItems.FirstOrDefault(X => X.FileName == nwcFile);
                            if (isInNWF == null)
                                targetfiles.Add(nwcFile);
                        }
                       
                        var isAppended = doc.TryAppendFiles(targetfiles);
                        doc.SaveFile(file);
                        string targetFolderPath = Path.Combine(nwdFolderPath, Path.GetFileNameWithoutExtension(file) + ".nwd");
                        doc.SaveFile(targetFolderPath);
                    }
            }
            catch (Exception ex)
            {


            }
        }

    }
}