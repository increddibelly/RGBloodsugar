using System;

namespace LedScout.Model
{
    public class BloodSugarEvent
    {
        public DateTime Timestamp {get;set;}
        public decimal BloodSugarLevel { get; set; }
        public BloodSugarDirection Direction { get; set; }
    }
}
