using LedScout.Control;
using LedScout.Model;
using System;
using System.Diagnostics;
using System.Threading;

namespace LedScout
{
    public class RGBloodsugar
    {
        public const int TimeBetweenEvents = 5 * 60 * 1000; // 5 minutes

        private readonly IBloodSugarProvider _bloodSugarProvider;
        private readonly ILedController _ledController;
        private bool _stopRequested;
        private BloodSugarEvent _lastEvent;

        public RGBloodsugar(
            IBloodSugarProvider bloodSugarProvider,
            ILedController ledController)
        {
            _bloodSugarProvider = bloodSugarProvider;
            _ledController = ledController;
        }

        public void Init()
        {
            try 
            {
                _bloodSugarProvider.Init();
                _ledController.Init();

            }
#pragma warning disable CS0168 // Variable is declared but never used
#pragma warning disable IDE0059 // Value assigned to symbol is never used
            catch (Exception ex)
            {
                Debugger.Break();
                throw; // if we can't start we shouldn't. This is pretty much the only place we want to inform the user
            }
#pragma warning restore IDE0059 // Value assigned to symbol is never used
#pragma warning restore CS0168 // Variable is declared but never used

            // set an initial result
            _lastEvent = new BloodSugarEvent 
            { 
                Timestamp = DateTime.Now.AddYears(-1) 
            };
        }

        public void Start()
        {
            _ledController.SetColor(LedScoutColors.InitialColor);

            do
            {
                try 
                {
                    var current = _bloodSugarProvider.Get();
                    // only report do we have more recent data?
                    if (current?.Timestamp > _lastEvent?.Timestamp)
                    {
                        HandleEvent(current);
                        _lastEvent = current;
                    }

                    WaitForNextEvent();
                }
#pragma warning disable CS0168 // Variable is declared but never used
#pragma warning disable IDE0059 // Value assigned to symbol is never used
                catch (Exception ex)
                {
                    // we don't want to pass any errors to the user. this process is just not important enough.
                    Debugger.Break();
                }  
#pragma warning restore IDE0059 // Value assigned to symbol is never used
#pragma warning restore CS0168 // Variable is declared but never used
            } while (!_stopRequested);
        }

        public void Stop()
        {
            _stopRequested = true;
        }

        private void WaitForNextEvent()
        {
            // wait for a set time before requesting new blood sugar. 
            // This prevents hammering the API for non-updated data.
            Thread.Sleep(TimeBetweenEvents);
        }

        private void HandleEvent(BloodSugarEvent current)
        {
            _ledController.Alert(current.Direction);

            var color = ConvertToRGBColor(current);
            _ledController.SetColor(color);

        }

        private Color ConvertToRGBColor(BloodSugarEvent current)
        {
            var state = SugarStateFinder.Get(current);
            return LedScoutColors.StateColors[state];
        }
    }
}
