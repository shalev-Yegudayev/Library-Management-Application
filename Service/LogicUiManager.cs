using Logic;

namespace OOCProject
{
    public class LogicUiManager
    {
        public static Manager Manager { get; set; }

        public LogicUiManager(Manager manager) => Manager = manager;
    }
}
