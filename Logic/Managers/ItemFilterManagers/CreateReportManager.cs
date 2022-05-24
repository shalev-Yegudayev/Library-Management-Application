using Logic.DataMembers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace Logic.Managers
{
    internal class CreateReportManager
    {
        internal static void CreateReport(INotify notify,List<AbstractItem> list)
        {
            string fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Report.txt");
            try
            {
                // Check if file already exists. If yes, delete it.     
                if (File.Exists(fileName)) File.Delete(fileName);

                // Create a new file     
                using (StreamWriter sw = File.CreateText(fileName))
                {
                    AddToTextFile(list, sw);
                }
                Process.Start("notepad.exe", fileName);
            }
            catch (NullReferenceException)
            {
                notify.IsError("List is empty!");
            }
            catch (Exception Ex)
            {
                notify.IsError(Ex.ToString());
            }
        }

        private static void AddToTextFile(List<AbstractItem> list, StreamWriter sw)
        {
            sw.WriteLine("Your Report:\n");
            foreach (var item in list)
            {
                sw.WriteLine($"{item.ShowItemDetails()}\n\n");
            }
        }
    }
}
