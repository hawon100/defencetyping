using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatBase : MonoBehaviour
{
    public int hp;
    public int maxHp;
    public bool isDeath;

    public virtual void Init()
    {
        hp = maxHp;
        isDeath = false;
    }

    public virtual void Damage(int value)
    {
        hp -= value;
        hp = Mathf.Clamp(hp, 0, maxHp);

        if (hp <= 0) Death();
    }

    protected virtual void Death()
    {
        isDeath = true;

        Managers.Resource.Destroy(gameObject);
        Managers.Wave.WaveUpdate();
        //Managers.Spawn.curEnemy.Remove(this.gameObject);
        //Manager.Spawn.RemoveCurrentEnemy() -> -1 & if (0) WaveExecute();
    }
}
