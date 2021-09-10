namespace Metrohm_Unit.ViewModel
{

    public enum UnitType
    {
        MiliSecond,
        Second,
        Minute
    }
    public class Unit
    {
        public UnitType Type { get; set; }
        public string Title { get; set; }

        public Unit(UnitType type, string title)
        {
            this.Type = type;
            this.Title = title;
        }
    }
}