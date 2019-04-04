using System;
using System.Threading;
using LedCSharp;
using LedScout.Control;
using LedScout.Model;

namespace LogitechLedController
{
    public class LogitechGSeriesLedController : ILedController
    {
        public void Init()
        {
            var initialized = LogitechGSDK.LogiLedInitWithName("Nightscout To Logitech Led Controller");

            if (!initialized)
            {
                throw new ApplicationException("Could not initialize Logitech G-Series LED Device");
            }
            LogitechGSDK.LogiLedSetTargetDevice(LogitechGSDK.LOGI_DEVICETYPE_RGB);
        }

        public void SetColor(Color color)
        {
            LogitechGSDK.LogiLedSetLighting(color.Red.ToPct(), color.Green.ToPct(), color.Blue.ToPct());
        }

        public void Alert(BloodSugarDirection Direction)
        {
            switch (Direction)
            {
                case BloodSugarDirection.DroppingFast:
                    SetEffect(LedEffect.DroppingFast); break;

                case BloodSugarDirection.Dropping:
                    SetEffect(LedEffect.Dropping); break;

                case BloodSugarDirection.Flat:
                    SetEffect(LedEffect.None); break;

                case BloodSugarDirection.Rising:
                    SetEffect(LedEffect.Rising); break;

                case BloodSugarDirection.RisingFast:
                    SetEffect(LedEffect.RisingFast); break;
            }
        }

        private void SetEffect(LedEffect effect)
        {
            var color = LedScoutColors.InitialColor;
            var interval = 0;

            switch (effect)
            {
                case LedEffect.None: break;

                case LedEffect.DroppingFast:
                    interval = 100;
                    color = LedScoutColors.StateColors[BloodSugarState.VeryLow]; break;

                case LedEffect.Dropping:
                    interval = 250;
                    color = LedScoutColors.StateColors[BloodSugarState.Low]; break;

                case LedEffect.Rising:
                    interval = 250;
                    color = LedScoutColors.StateColors[BloodSugarState.High]; break;

                case LedEffect.RisingFast:
                    interval = 100;
                    color = LedScoutColors.StateColors[BloodSugarState.VeryHigh]; break;
            }

            if (interval > 0)
            {
                LogitechGSDK.LogiLedFlashLighting(
                    color.Red.ToPct(), color.Green.ToPct(), color.Blue.ToPct(),
                    3000, interval);
                Thread.Sleep(3100);
            }
        }

        public void Dispose()
        {
            LogitechGSDK.LogiLedShutdown();
        }
    }
}
