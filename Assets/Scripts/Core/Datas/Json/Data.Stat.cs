using System;
using System.Collections.Generic;
using UnityEngine;

namespace Data.Stats
{
    [Serializable]
    public class Stat
    {
        public int level;
        public int maxhp;
        public int attack;
        public int totalExp;
    }

    [Serializable]
    public class InstallStat : Stat
    {
        public int price;
    }
}