using System;
using System.Windows;
using System.Diagnostics;
using System.IO;
using Microsoft.Win32;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;


namespace wawawawa
{
    public partial class MainWindow : Window
    {
        List<string> macros = new List<string>();
        string path = "%appdata%\\CGSS";
        string username = "%username%";
        public MainWindow()
        {
            InitializeComponent();
            ExecuteCommand("md %appdata%\\CGSS", 0, false);
            try
            {
                rcdate.Text = "Recycle Bin modified date: " + File.GetLastWriteTime(@"C:\$Recycle.Bin").ToString("dd/MM/yyyy HH:mm:ss");
            }
            catch
            {
                MessageBox.Show("Can't get recycle bin date");
            }
        }

        public void Installer(string installer)
        {
            ProcessStartInfo Info = new ProcessStartInfo();
            Info.FileName = installer;
            Process.Start(Info);
        }

        public void CommandP(string command, bool close)
        {
            if (close)
            {
                Process.Start("cmd.exe", "/C " + command);
            }
            else
            {
                Process.Start("cmd.exe", "/K " + command);
            }
        }

        public void ExecuteCommand(string command, int outputn, bool window)
        {
            try
            {
                var processS = new ProcessStartInfo("cmd.exe", "/c " + command);
                if (window)
                {
                    processS.CreateNoWindow = false;
                }
                else
                {
                    processS.CreateNoWindow = true;
                }
                processS.UseShellExecute = false;
                process.WaitForExit();
                process.Close();
            }
            catch
            {
                MessageBox.Show("Ocurrio un error, seguramente tiene relación con el OS");
            }
        }

        public void RegeditPath(string path)
        {
            try
            {
                Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Applets\Regedit", "LastKey", path);
                Process.Start("regedit.exe");
            }
            catch
            {
                MessageBox.Show("que, no existe o estoy bug o estás bug o su pc está bug o su windows está raro");
            }
        }
        private void svcoff_Click_1(object sender, RoutedEventArgs e)
        {
            ExecuteCommand("sc query type= service state= inactive > " + path + "\\svoff.txt", 0, false);
            ExecuteCommand("explorer %appdata%\\CGSS\\svoff.txt", 0, false);
        }

        private void Store_Click(object sender, RoutedEventArgs e)
        {
            RegeditPath(@"HKEY_CURRENT_USER\Software\Microsoft\Windows NT\CurrentVersion\AppCompatFlags\Compatibility Assistant\Store");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RegeditPath(@"Equipo\HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\bam\State\UserSettings\HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\bam\");
        }

        private void MUICACHE_Click(object sender, RoutedEventArgs e)
        {
            RegeditPath(@"Equipo\HKEY_CLASSES_ROOT\Local Settings\Software\Microsoft\Windows\Shell\MuiCache");
        }

        private void Macros_Click(object sender, RoutedEventArgs e)
        {
            macros.Add(@"C:\Users\" + username + @"\AppData\Local\LGHUB");
            macros.Add(@"C:\ProgramData\Razer\Synapse3\Log");
            macros.Add(@"C:\Users\" + username + @"\AppData\Local\Razer\Synapse\log\macros");
            macros.Add(@"%Systemdrive%/other.txt");

            foreach (string macro in macros)
            {
                if (Directory.Exists(macro))
                {
                    MacroResults.Items.Add(macro);
                }
            }

            MacroResults.Visibility = Visibility.Visible;
        }

// tapense los ojos!!
        private void dipslay_dns(object sender, RoutedEventArgs e)
        {
            CommandP("ipconfig /displaydns > " + path + "\\dnscache.txt", true);
            ExecuteCommand("explorer %appdata%\\CGSS\\dnscache.txt", 0, false);
        }

        private void winprefetchview(object sender, RoutedEventArgs e)
        {
            Installer("https://www.nirsoft.net/utils/winprefetchview-x64.zip");
        }

        private void USBTool_Click(object sender, RoutedEventArgs e)
        {
            Installer("https://cdn.discordapp.com/attachments/1014632218183860334/1015006494082748467/usb-tool.exe");
        }

        private void System_Informer_Click(object sender, RoutedEventArgs e)
        {
            Installer("https://github.com/winsiderss/si-builds/releases/download/3.0.5553/systeminformer-3.0.5553-bin.zip ");
        }

        private void JournalTrace_Click(object sender, RoutedEventArgs e)
        {
            Installer("https://github.com/ponei/JournalTrace/releases/download/1.0/JournalTrace.exe");
        }

        private void Everything_Click(object sender, RoutedEventArgs e)
        {
            Installer("https://www.voidtools.com/Everything-1.4.1.1017.x64.zip");
        }

        private void UserAssistTool_Click(object sender, RoutedEventArgs e)
        {
            Installer("https://cdn.discordapp.com/attachments/1014632218183860334/1014637785384226856/userassist-tool.exe ");
        }

        private void Journal_Tool_Click(object sender, RoutedEventArgs e)
        {
            Installer("https://cdn.discordapp.com/attachments/1014632218183860334/1014637785694621706/journal-tool.exe");
        }

        private void SGRM_Click(object sender, RoutedEventArgs e)
        {
            Installer("https://cdn.discordapp.com/attachments/1014632218183860334/1014637785061277766/sgrm-tool.exe ");
        }

        private void PSTools_Click(object sender, RoutedEventArgs e)
        {
            Installer("https://download.sysinternals.com/files/PSTools.zip");
        }

        private void ShellBagsView_Click(object sender, RoutedEventArgs e)
        {
            Installer("https://www.nirsoft.net/utils/shellbagsview.zip");
        }

        private void Strings_Click(object sender, RoutedEventArgs e)
        {
            Installer("https://download.sysinternals.com/files/Strings.zip");
        }

        private void WinLiveInfo_Click(object sender, RoutedEventArgs e)
        {
            Installer("https://github.com/kacos2000/Win10LiveInfo/releases/download/v.1.0.23.0/WinLiveInfo.exe");
        }

        private void Rifiuti2_Click(object sender, RoutedEventArgs e)
        {
            Installer("https://github.com/abelcheung/rifiuti2/releases/tag/0.7.0");
        }

        private void PH3_Click(object sender, RoutedEventArgs e)
        {
            Installer("https://github.com/ProcessHackerRepoTool/nightly-builds-mirror/releases/download/v3.0.4600/processhacker-3.0.4600-setup.exe");
        }

        private void OSForensics_Click(object sender, RoutedEventArgs e)
        {
            Installer("https://www.osforensics.com/download.html");
        }

        private void PreviousFileRecovery_Click(object sender, RoutedEventArgs e)
        {
            Installer("https://cdn.discordapp.com/attachments/1031576950722007070/1059489114111627294/previousfilesrecovery-x64_1.zip");
        }

        private void PcasvcExplorer_Click(object sender, RoutedEventArgs e)
        {
            Installer("https://github.com/Zack-src/Service-Execution/releases/download/1.0/PcaSvc.FileExplorer.exe");
        }

        private void NTFSJournal_Click(object sender, RoutedEventArgs e)
        {
            Installer("https://cdn.discordapp.com/attachments/1038883146009153547/1059489569478819960/NTFS-Journal-Viewer.zip");
        }

        private void Registry_Explorer_Click(object sender, RoutedEventArgs e)
        {
            Installer("https://f001.backblazeb2.com/file/EricZimmermanTools/RegistryExplorer.zip");
        }

        private void Razer_Log_Collector_Click(object sender, RoutedEventArgs e)
        {
            Installer("https://cdn.discordapp.com/attachments/1031576950722007070/1059489485534003340/Razer_Log_Collector_V3.8.4_1.zip");
        }

        private void WindowsTimeline_Click(object sender, RoutedEventArgs e)
        {
            Installer("https://github.com/kacos2000/WindowsTimeline/releases/download/v.2.0.82.0/WindowsTimeline.exe");
        }

        private void Recuva_Click(object sender, RoutedEventArgs e)
        {
            Installer("https://recuva.uptodown.com/windows");
        }

        private void Redline_Click(object sender, RoutedEventArgs e)
        {
            Installer("https://cdn.discordapp.com/attachments/1031576950722007070/1056946279663546368/sdl-redline.zip");
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            Installer("https://sourceforge.net/projects/processhacker/files/processhacker2/processhacker-2.39-bin.zip/download");
        }
        
        private void control_folders_Click(object sender, RoutedEventArgs e)
        {
            CommandP("control folders", true);
        }
    }
}
