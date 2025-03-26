using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Application = Autodesk.Navisworks.Api.Application;
using wf = System.Windows.Forms;

// Navisworks API References
using Autodesk.Navisworks.Api;
using Autodesk.Navisworks.Api.Plugins;
using Autodesk.Navisworks.Api.DocumentParts;
using NavisworksUpdater.MVVM.ViewModel;
using NavisworksUpdater.MVVM.View;
using System.Reflection;
using System.IO;
using System.Windows.Forms;

namespace NavisworksUpdater
{

    // plugin attribute require Name , DeveloperID and optional parameters
    [PluginAttribute("Navisworks Updater", "NavisworksUpdater", DisplayName = "Navisworks Updater", ToolTip = "Display Navisworks Updater")]

    public class Command : AddInPlugin
    {
        //"%NAVISWORKS_INTALLATION_FOLDER%\Roamer.exe" -NoGui -ExecuteAddInPlugin PluginName.PluginGUID %Parameters_if_needed% to run without guid 

        public override int Execute(params string[] parameters)
        {
            AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(AssemblyResolve);
            // get document from application
            Document document = Application.ActiveDocument;
            // info message - current file path with appended files

            //MainWindowViewModel mainWindowViewModel = new MainWindowViewModel();

            //var mainWindow = MainWindow.CreateInstance(mainWindowViewModel);
            //mainWindow.ShowDialog();

            // prompt to select folder path 
            var folderPath = "W:\\Projects\\Abu Qir\\01 BIM\\01_BIM_Models";
            if (string.IsNullOrEmpty(folderPath))  return -1;

            //get all nwf files 
            var nwfFiles = Directory.GetFiles(folderPath,"*.nwf",searchOption: SearchOption.AllDirectories);
            foreach (var file in nwfFiles)
            {
                var doc = Application.ActiveDocument;
                doc.OpenFile(file);
                doc.TryCloseFileHandles();
                doc.UpdateFiles();
                string targetFilePath = Path.Combine(folderPath, Path.GetFileNameWithoutExtension(file) + ".nwd");
                doc.SaveFile(targetFilePath);
            }
            // int return
            return 0;
        }
        private Assembly AssemblyResolve(object sender, ResolveEventArgs args)
        {
            int position = args.Name.IndexOf(",");
            if (position > -1)
            {
                try
                {
                    string assemblyName = args.Name.Substring(0, position);
                    string assemblyFullPath = string.Empty;

                    //look in main folder
                    assemblyFullPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\" + assemblyName + ".dll";
                    if (File.Exists(assemblyFullPath))
                        return Assembly.LoadFrom(assemblyFullPath);
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                }
            }
            return null;
        }


        private string PromptForFolderPath(string message)
        {
          FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = message;
           if(dialog.ShowDialog() == DialogResult.OK)
                return dialog.SelectedPath;
           return null;
        }
    }

}
