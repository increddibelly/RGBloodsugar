namespace LedScout.Model
{
    public enum BloodSugarDirection : short
    {
        DroppingFast = -2,
        Dropping = -1,
        Flat = 0,
        Rising = 1,
        RisingFast = 2
    }

    public enum BloodSugarState : short
    {
        VeryLow = -2,
        Low = -1,
        InRange = 0,
        High = 1,
        VeryHigh = 2
    }

    public enum LedEffect : byte
    {
        None = 0,
        Dropping = 1,
        DroppingFast = 2,
        Rising = 3,
        RisingFast = 4
    }
}
