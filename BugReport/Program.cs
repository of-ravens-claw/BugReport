using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Globalization;
using System.Linq;

namespace BugReport
{
    internal class Program
    {
        private static readonly StringBuilder retString = new StringBuilder();
        private static void Main(string[] args)
        {
            if (!File.Exists("GTA5.exe"))
            {
                MessageBox.Show("Please place this .exe file in your Grand Theft Auto V directory, then try again.", "GTA5.exe not found", MessageBoxButtons.OK, MessageBoxIcon.Error); //Somehow our users are stupid enough to not understand simple instructions.
                return;
            }

            var verInfo = FileVersionInfo.GetVersionInfo(Path.Combine(Environment.CurrentDirectory, "GTA5.exe"));

            //retString.AppendLine($"———— GTA 5 EXE Data ————\n{verInfo}");
            //retString.AppendLine();

            try
            {
                retString.AppendLine("———— ScriptHookVDotNet.log ————");
                retString.AppendLine(File.ReadAllText("ScriptHookVDotNet.log"));
            }
            catch (FileNotFoundException)
            {
                retString.AppendLine("FILE NOT FOUND: ScriptHookVDotNet.log");
            }
            finally
            {
                retString.AppendLine();
            }

            try
            {
                retString.AppendLine("———— ScriptHookV.log ————");
                retString.AppendLine(File.ReadAllText("ScriptHookV.log"));
            }
            catch (FileNotFoundException)
            {
                retString.AppendLine("FILE NOT FOUND: ScriptHookV.log");
            }
            finally
            {
                retString.AppendLine();
            }

            try
            {
                retString.AppendLine("———— SETTINGS.INI ————");
                retString.AppendLine(File.ReadAllText("Scripts\\BackToTheFutureV\\settings.ini"));
            }
            catch (DirectoryNotFoundException)
            {
                retString.AppendLine(@"FOLDER NOT FOUND: Scripts\BackToTheFutureV");
                Console.WriteLine("Is the mod even installed?");
            }
            catch (FileNotFoundException)
            {
                retString.AppendLine("FILE NOT FOUND: settings.ini");
            }

            finally
            {
                retString.AppendLine();
            }

            retString.AppendLine("———— FILES ————");
            foreach (string file in Directory.GetFiles(".\\", "*", SearchOption.AllDirectories).Where(s => !(s.Contains("\\Redistributables\\") || s.Contains("\\ReadMe\\") || s.Contains("\\_Installer\\") || s.Contains("\\CommonRedist\\") || s.Contains("\\.egstore\\"))))
            retString.AppendLine(file.Replace(".\\", ""));
            retString.AppendLine();
            File.WriteAllText(string.Format(".\\BUGREPORT_{0:yyyy-MM-dd_HH-mm-ss}.txt", DateTime.Now), retString.ToString());
        }
    }
}
