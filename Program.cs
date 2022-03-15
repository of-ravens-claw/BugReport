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
#pragma warning disable CS0219
#pragma warning disable CS0665
        private static StringBuilder retString = new StringBuilder();

        /* Planned Launch Args:
        * --nobttfv (Skips logging for settings.ini)
        * --openiv (Logs OpenIV.LOG)
        * --poolmanager (Logs files made by PoolManager)
        * --notree (Disables the 'tree' inspired file view.)
        * --skipgta (Disables the check for GTA5.exe.) Why would anyone do this?
        * --help (Lists the options above)
        */

        private static void Main(string[] args)
        {
            //bool nobttfv = false;
            //bool openiv = false;
            //bool poolmanager = false;
            //bool notree = false;
            //bool skipgta = false;

            /*try
            {
                File.SetLastAccessTime("GTA5.exe", DateTime.Now);
            }
            catch (FileNotFoundException)
            {
                //Console.WriteLine("\nPlease place this .exe file in your Grand Theft Auto V directory, then try again.");
                MessageBox.Show("Please place this .exe file in your Grand Theft Auto V directory, then try again.", "GTA5.exe not found", MessageBoxButtons.OK, MessageBoxIcon.Error); //Somehow our users are stupid enough to not understand the first one to begin with.
            }*/

            //var command = args[0];

            //switch (command)
            //{
            //    case "nobttfv":
            //        nobttfv = true;
            //        break;

            //    case "openiv":
            //        openiv = true;
            //        break;

            //    case "poolmanager":
            //        poolmanager = true;
            //        break;

            //    case "notree":
            //        notree = true;
            //        break;

            //    case "skipgta":
            //        skipgta = true;
            //        break;

            //    case "--help":
            //        Console.WriteLine("\nAs of currently, only one arg is supported.\n\nnobttfv (Skips logging for BTTFV specific things, in this case, settings.inî)\n\nopeniv (Enables logging for OpenIV.log)\n\npoolmanager (Enables logging for files made by PoolManager)\n\nnotree (Disables the 'tree' inspired file view in the log)\n\nskipgta (Disables the check for GTA5.exe)\n");
            //        break;

            //    default:
            //        Console.WriteLine("Invalid arg");
            //        break;
            //}

            //if (skipgta = false) // If it's set to false, then it runs, otherwise it doesn't.
            //{
                if (!File.Exists("GTA5.exe"))
                {
                    MessageBox.Show("Please place this .exe file in your Grand Theft Auto V directory, then try again.", "GTA5.exe not found", MessageBoxButtons.OK, MessageBoxIcon.Error); //Somehow our users are stupid enough to not understand simple instructions.
                Environment.Exit(0); //Application.Exit doesn't work for some reason.
                }
            //}

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

            //if (nobttfv = true)
            //{
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
            //}

            //if (openiv = false)
            //{
                //try
                //{
                //    Program.retString.AppendLine("———— OpenIV.log ————");
                //    Program.retString.AppendLine(File.ReadAllText("OpenIV.log"));
                //}
                //catch (FileNotFoundException)
                //{
                //    Program.retString.AppendLine("FILE NOT FOUND: OpenIV.log");
                //}
                //finally
                //{
                //    Program.retString.AppendLine();
                //}
            //}

            //if (poolmanager = false) // Only runs if it's set to false?
            //{
            //    try
            //    {
            //        Program.retString.AppendLine("———— PoolManager_Crash.log ————");
            //        Program.retString.AppendLine(File.ReadAllText("PoolManager_Crash.log"));
            //    }
            //    catch (FileNotFoundException)
            //    {
            //        Program.retString.AppendLine("FILE NOT FOUND: PoolManager_Crash.log" +
            //            "\nThis is probably fine, GTA just didn't crash due to the gameconfig.");
            //    }
            //    finally
            //    {
            //        Program.retString.AppendLine();
            //    }
            //}

            //if (notree = true) // Only runs if it's set to true
            //{ 
                Program.retString.AppendLine("———— FILES ————");

                foreach (string file in Directory.GetFiles(".\\", "*", SearchOption.AllDirectories))

                Program.retString.AppendLine(file.Replace(".\\", ""));

                Program.retString.AppendLine();
            //}
            File.WriteAllText(string.Format(".\\BUGREPORT_{0:yyyy-MM-dd_HH-mm-ss}.txt", (object)DateTime.Now), Program.retString.ToString());
        }
    }
}
