using LedScout.Model;
using System;

namespace LedScout.Control
{
    public interface IBloodSugarProvider : IDisposable
    {
        void Init();
        BloodSugarEvent Get();
    }
}
