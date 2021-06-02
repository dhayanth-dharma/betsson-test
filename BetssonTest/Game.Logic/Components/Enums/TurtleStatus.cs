using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Library.Components.Enums
{
    public enum TurtleStatus
    {
        IsDead,
        Normal,
        OutOfGrid,
        IsExit,
        IsDanger,
        NearToMine,
        Success,
        MineHit, 
        StillInDanger
    }
}
