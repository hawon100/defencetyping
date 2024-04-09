using Data.Stats;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Data
{
    [Serializable]
    public class StatData : ILoader<int, Stat>
    {
        public List<Stat> stats = new List<Stat>();

        public Dictionary<int, Stat> MakeDict()
        {
            Dictionary<int, Stat> dict = new Dictionary<int, Stat>();
            foreach (Stat stat in stats)
            {
                dict.Add(stat.level, stat);
            }
            return dict;
        }
    }

    [Serializable]
    public class InstallStatData : ILoader<int, InstallStat>
    {
        public List<InstallStat> stats = new List<InstallStat>();

        public Dictionary<int, InstallStat> MakeDict()
        {
            Dictionary<int, InstallStat> dict = new Dictionary<int, InstallStat>();
            foreach (InstallStat stat in stats)
            {
                dict.Add(stat.level, stat);
            }
            return dict;
        }
    }
}