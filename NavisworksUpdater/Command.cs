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
using System.Timers;
using Microsoft.Win32;
using Timer = System.Windows.Forms.Timer;
using static System.Net.Mime.MediaTypeNames;
using System.Threading;
using System.Windows.Input;

namespace NavisworksUpdater
{

    // plugin attribute require Name , DeveloperID and optional parameters
    [PluginAttribute("Navisworks Updater", "7AB4B097-3425-49B6-8C0B-F28E739DD0AF", DisplayName = "Navisworks Updater", ToolTip = "Display Navisworks Updater")]

    public class Command : AddInPlugin
    {
        //"%NAVISWORKS_INTALLATION_FOLDER%\Roamer.exe" -NoGui -ExecuteAddInPlugin PluginName.PluginGUID %Parameters_if_needed% to run without guid 
        MainWindowViewModel _mainWindowViewModel = null;
        
        
        public override int Execute(params string[] parameters)
        {
            //application.ExecutePlugin("BasicPlugIn.ABasicPlugin.ADSK");
            AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(AssemblyResolve);
             _mainWindowViewModel = new MainWindowViewModel();
            var  mw =  MainWindow.CreateInstance(_mainWindowViewModel);
            mw.Show();


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
            if (dialog.ShowDialog() == DialogResult.OK)
                return dialog.SelectedPath;
            return null;
        }
    }

}
