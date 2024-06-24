using UnityEngine;

public class TowerStat : MonoBehaviour
{
    public TeamData teamData;
    public CharListData charData;
    public TowerStatUI towerStatUI;
    public Vector2     towerPos;

    [SerializeField] protected int _level;
    [SerializeField] protected int _hp;
    [SerializeField] protected int _maxHp;
    [SerializeField] protected int _attack;

    public int Level { get { return _level; } set { _level = value; } }
    public int Hp { get { return _hp; } set { _hp = value; } }
    public int MaxHp { get { return _maxHp; } set { _maxHp = value; } }
    public int Attack { get { return _attack; } set { _attack = value; } }

    private void Start()
    {
        for(int i = 0; i < teamData.team.Count; i++)
        {
            if (teamData.team[i].prefabName == charData.dataEdit[i].prefabName)
            {
                _level = charData.dataEdit[i].stat.level;
                _hp = charData.dataEdit[i].stat.hp;
                _maxHp = charData.dataEdit[i].stat.hp;
                _attack = charData.dataEdit[i].stat.attack;
            }
        }
    }

    public virtual void Init()
    {
        Hp = MaxHp;
    }

    //public virtual void OnAttacked(TowerStat attacker)
    //{
    //    int damage = Mathf.Max(0, attacker.Attack - Defence);
    //    Hp -= damage;
    //    if (Hp <= 0)
    //    {
    //        Hp = 0;
    //        OnDead(attacker);
    //    }
    //}

    public virtual void OnAttacked(int damagedHp)
    {
        Hp -= damagedHp;
        Hp = Mathf.Clamp(Hp, 0, MaxHp);
        if (Hp <= 0)
        {
            Hp = 0;
            OnDead();
        }
    }

    protected virtual void OnDead()
    {
        
    }

    //protected virtual void OnDead(TowerStat attacker)
    //{

    //}

    public virtual void OnFixed(int fixHp)
    {
        Hp += fixHp;
        Hp = Mathf.Clamp(Hp, 0, MaxHp);
    }
}