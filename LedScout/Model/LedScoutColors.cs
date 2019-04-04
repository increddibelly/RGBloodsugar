using System.Collections.Generic;

namespace LedScout.Model
{
    public static class LedScoutColors
    {
        private static readonly Color VeryLow = new Color ("0000FF");
        private static readonly Color Low = new Color ("00AAFF");
        private static readonly Color InRange = new Color ("00FF00");
        private static readonly Color High = new Color ("FFAA00");
        private static readonly Color VeryHigh = new Color ("FF0000");
        public static readonly Color InitialColor = new Color("7F7F7F");


        public static Dictionary<BloodSugarState, Color> StateColors = 
            new Dictionary<BloodSugarState, Color>
            {
                { BloodSugarState.VeryLow, VeryLow },
                { BloodSugarState.Low, Low },
                { BloodSugarState.InRange, InRange },
                { BloodSugarState.High, High },
                { BloodSugarState.VeryHigh, VeryHigh }
            };
    }
}
