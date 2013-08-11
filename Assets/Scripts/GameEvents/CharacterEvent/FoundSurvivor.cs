﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.GameEvents.CharacterEvent
{
    public class FoundSurvivor : GameEvent
    {
        public override string Title
        {
            get { return "Found a Survivor!"; }
        }

        public override string Description
        {
            get { return "A survivor has found your camp!"; }
        }

        public override GameEventType GameEventType
        {
            get { return GameEventType.CharacterEvent; }
        }
    }
}
