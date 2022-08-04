using System;
using Example.Scripts.Characters;

namespace Example.Scripts.Environment
{
    public interface ITree : IInteractable
    {
        event Action CutDown;
    }
}