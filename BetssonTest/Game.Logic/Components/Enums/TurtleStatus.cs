using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Library.Components.Enums
{
    public enum State
    {
        IsDead,
        Normal,
        IsOutOfBounds,
        IsExit,
        IsDanger,
        Success,
        MineHit, 
        StillInDanger
    }
}
