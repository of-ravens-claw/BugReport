// TO DO: Convert this to a diagostic app that can give simple information, and provide a zip file with GTA files inside.
// And yeah, I know that most of my comments are useless.

using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace BTTFVBugReport
{
    internal class Program
    {
        private static StringBuilder retString = new StringBuilder();

        /* Planned Launch Args:
        * -nobttfv (Skips logging for settings.ini)
        * -openiv (Logs OpenIV.LOG)
        * -poolmanager (Logs files made by PoolManager)
        * -console (Runs the App in console mode, which is intended for debug purposes; implies -debug)
        * -debug (Logs extra things, such as: OS Version, Game EXE version, Path 'BugReport.exe' is located at, CPU, GPU, RAM, MOBO. Some of this stuff is 'useless', but I beg to differ. Besides, you're not going to use this unless being told to.
        * -help (Lists the options above)
        */

        private static void Main(string[] args)
        {

            /*try
            {
                File.SetLastAccessTime("GTA5.exe", DateTime.Now);
            }
            catch (FileNotFoundException)
            {
                //Console.WriteLine("\nPlease place this .exe file in your Grand Theft Auto V directory, then try again.");
                MessageBox.Show("Please place this .exe file in your Grand Theft Auto V directory, then try again.", "GTA5.exe not found", MessageBoxButtons.OK, MessageBoxIcon.Error); //Somehow our users are stupid enough to not understand the first one to begin with.
            }*/

            if (!File.Exists("GTA5.exe"))
            {
                MessageBox.Show("Please place this .exe file in your Grand Theft Auto V directory, then try again.", "GTA5.exe not found", MessageBoxButtons.OK, MessageBoxIcon.Error); //Somehow our users are stupid enough to not understand simple instructions.
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

            bool chivo = false;
            if (chivo = true)
            {
                try
                {
                    Program.retString.AppendLine("———— OpenIV.log ————");
                    Program.retString.AppendLine(File.ReadAllText("OpenIV.log"));
                }
                catch (FileNotFoundException)
                {
                    Program.retString.AppendLine("FILE NOT FOUND: OpenIV.log");
                }
                finally
                {
                    Program.retString.AppendLine();
                }
            }

            Program.retString.AppendLine("---- FILES ----");
            foreach (string file in Directory.GetFiles(".\\", "*", SearchOption.AllDirectories))
                Program.retString.AppendLine(file.Replace(".\\", ""));
            Program.retString.AppendLine();
            File.WriteAllText(string.Format(".\\BUGREPORT_{0:yyyy-MM-dd_HH-mm-ss}.txt", (object)DateTime.Now), Program.retString.ToString());
        }
    }
}
