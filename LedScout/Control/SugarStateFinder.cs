using LedScout.Model;

namespace LedScout.Control
{
    public static class SugarStateFinder
    {
        private const decimal VeryLow = 3.0m;
        private const decimal Low = 4.5m;
        private const decimal High = 9.0m;
        private const decimal VeryHigh = 16m;

        public static BloodSugarState Get (BloodSugarEvent current)
        {
            if (current.BloodSugarLevel <= VeryLow) 
                return BloodSugarState.VeryLow;
            if (current.BloodSugarLevel <= Low) 
                return BloodSugarState.Low;
            // above low, below high. yay
            if (current.BloodSugarLevel < High) 
                return BloodSugarState.InRange;
            if (current.BloodSugarLevel <= VeryHigh) 
                return BloodSugarState.High;

            return BloodSugarState.VeryHigh;
        }
    }
}
