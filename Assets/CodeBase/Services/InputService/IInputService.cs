using System;

namespace CodeBase.Services.InputService
{
    public interface IInputService
    {
        event Action<float> OnDrag;
        void Update();
    }
}