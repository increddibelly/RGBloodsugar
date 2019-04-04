using NightscoutClient;
using LogitechLedController;
using LedScout;
using System.Linq;

namespace LogitechLedScout
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.FirstOrDefault()?.StartsWith("http") != true)
            {
                throw new System.Exception("Nightscout URL must be specified as the first command line parameter.");
            }
            var uri = args[0];

            var nightscout = new NightscoutBloodSugarProvider(uri);
            var leds = new LogitechGSeriesLedController();

            var thing = new RGBloodsugar(nightscout, leds);
            thing.Init();
            thing.Start();
        }
    }
}
