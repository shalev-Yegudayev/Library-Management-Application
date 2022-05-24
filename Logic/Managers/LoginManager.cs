namespace Logic.Managers
{
    internal class LoginManager
    {
        internal static int Login(INotify notify, int pinToCheck, out string employeeName)
        {
            employeeName = null;
            foreach (var item in SQLManager.CreateIdArrayFromSql("Managers"))
            {
                if (pinToCheck == item)
                {
                    employeeName = SQLManager.GetEmployeeName(pinToCheck.ToString(),"Managers");
                    return 1;
                }
            }
            foreach (var item in SQLManager.CreateIdArrayFromSql("Workers"))
            {
                if (pinToCheck == item)
                {
                    employeeName = SQLManager.GetEmployeeName(pinToCheck.ToString(), "Workers");
                    return 0;
                }
            }
            notify.IsError("PIN Not Found");
            return -1;
        }
    }
}
