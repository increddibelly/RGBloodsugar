using LedScout.Model;
using System;

namespace LedScout.Control
{
    public interface ILedController : IDisposable
    {
        void Init();
        void SetColor(Color color);
        void Alert(BloodSugarDirection Direction);
    }
}
