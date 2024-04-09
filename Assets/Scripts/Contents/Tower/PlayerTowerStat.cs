using System.Collections.Generic;
using Data;
using Data.Stats;
using UnityEngine;

public abstract class PlayerTowerStat : TowerStat
{
    [SerializeField] protected int _exp;

	public int Exp 
	{ 
		get { return _exp; } 
		set 
		{ 
			_exp = value;

			int level = 1;
			while (true)
			{
				Stat stat;
				if (Managers.Data.StatDict.TryGetValue(level + 1, out stat) == false)
					break;
				if (_exp < stat.totalExp)
					break;
				level++;
			}

			if (level != Level)
			{
				Debug.Log("Level Up!");
				Level = level;
				SetStat(Level);
			}
		}
	}

	protected virtual void Start()
	{
		_level = 1;
		_exp = 0;
		_defence = 0;

		SetStat(_level);
	}

	public void SetStat(int level)
	{
		Dictionary<int, Stat> dict = Managers.Data.StatDict;
		Stat stat = dict[level];
		_hp = stat.maxhp;
		_maxHp = stat.maxhp;
		_attack = stat.attack;
	}

	protected override void OnDead(TowerStat attacker)
	{
		Debug.Log("Player Dead");
	}
}