﻿using Game.Class;
using Game.Enum;

namespace Game.Class
{
    public class Heroes : Mob
    {

        public Heroes(string sName, int iHp, int iMana, float fDamage, float fResistance, int iSpeed, Types cTypes) : base(sName, iHp, iMana, fDamage, fResistance, iSpeed, cTypes)
        {

        }

    }
}
