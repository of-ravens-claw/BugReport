using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace BugReport
{
    internal class Program
    {
        private static StringBuilder retString = new StringBuilder();
        private static void Main(string[] args)
        {

            if (!File.Exists("GTA5.exe"))
            {
                MessageBox.Show("Please place this .exe file in your Grand Theft Auto V directory, then try again.", "GTA5.exe not found", MessageBoxButtons.OK, MessageBoxIcon.Error); //Somehow our users are stupid enough to not understand simple instructions.
                Environment.Exit(0); //Application.Exit doesn't work for some reason.
            }

            try
            {
                Program.retString.AppendLine("———— ScriptHookVDotNet.log ————");
                Program.retString.AppendLine(File.ReadAllText("ScriptHookVDotNet.log"));
            }
            catch (FileNotFoundException)
            {
                Program.retString.AppendLine("FILE NOT FOUND: ScriptHookVDotNet.log");
            }
            finally
            {
                Program.retString.AppendLine();
            }

            try
            {
                Program.retString.AppendLine("———— ScriptHookV.log ————");
                Program.retString.AppendLine(File.ReadAllText("ScriptHookV.log"));
            }
            catch (FileNotFoundException)
            {
                Program.retString.AppendLine("FILE NOT FOUND: ScriptHookV.log");
            }
            finally
            {
                Program.retString.AppendLine();
            }

            try
            {
                Program.retString.AppendLine("———— SETTINGS.INI ————");
                Program.retString.AppendLine(File.ReadAllText("Scripts\\BackToTheFutureV\\settings.ini"));
            }
            catch (DirectoryNotFoundException)
            {
                Program.retString.AppendLine(@"FOLDER NOT FOUND: Scripts\BackToTheFutureV");
                Console.WriteLine("Is the mod even installed?");
            }
            catch (FileNotFoundException)
            {
                Program.retString.AppendLine("FILE NOT FOUND: settings.ini");
            }

            finally
            {
                Program.retString.AppendLine();
            }

            Program.retString.AppendLine("———— FILES ————");
            foreach (string file in Directory.GetFiles(".\\", "*", SearchOption.AllDirectories))
            Program.retString.AppendLine(file.Replace(".\\", ""));
            Program.retString.AppendLine();
            File.WriteAllText(string.Format(".\\BUGREPORT_{0:yyyy-MM-dd_HH-mm-ss}.txt", (object)DateTime.Now), Program.retString.ToString());
        }
    }
}
