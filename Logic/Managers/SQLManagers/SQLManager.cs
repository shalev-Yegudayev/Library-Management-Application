using Logic.Managers.SQLManagers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows;

namespace Logic.Managers
{
    internal class SQLManager
    {
        internal static List<int> CreateIdArrayFromSql(string table)
        {
            List<int> vs = new List<int>();

            SqlDataReader reader = ExecuteCommands.ExecuteSelect($"SELECT id FROM {table}");
            while (reader.Read())
            {
                int.TryParse(reader.GetValue(0).ToString(), out int id);
                vs.Add(id);
            }
            reader.Close();
            return vs;
        }


        internal static string GetEmployeeName(string idToCheck, string table)
        {
            string name = "";

            SqlDataReader reader = ExecuteCommands.ExecuteSelect($"SELECT id, firstname,lastname FROM {table}");
            while (reader.Read())
            {
                if (reader.GetValue(0).ToString() == idToCheck)
                {
                    name = $"{reader.GetValue(1)} {reader.GetValue(2)}";
                    break;
                }
            }
            reader.Close();
            return name;

        }

        internal static void InsertNewEmployee(string firstName, string LastName, bool[] ranks)
        {
            try
            {
                string table = GetRank(ranks);
                ExecuteCommands.ExecuteInsert($"INSERT INTO {table} VALUES ('{firstName}','{LastName}')");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
     
        private static string GetRank(bool[] ranks)
        {
            if (ranks[0]) return "Workers";

            if (ranks[1]) return "Managers";
            return "";
        }
    }
}
