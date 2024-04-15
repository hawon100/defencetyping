using System.Collections.Generic;
using Data;
using UnityEngine;

public abstract class PlayerTowerStat : TowerStat
{
	protected virtual void Start()
	{

	}

	protected override void OnDead(TowerStat attacker)
	{
		Debug.Log("Player Dead");
	}
}