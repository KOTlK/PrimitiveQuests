using System;

namespace PrimitiveQuests.TestQuests
{
    public interface IMouseInput
    {
        event Action LMBClicked;
        event Action DoubleLMBClick;
        event Action TripleLMBClick;
    }
}