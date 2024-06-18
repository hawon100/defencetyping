using UnityEngine;

public class TowerStat : MonoBehaviour
{ 
    public TowerStatUI towerStatUI;
    public Vector2     towerPos;

    [SerializeField] protected int _level;
    [SerializeField] protected int _hp;
    [SerializeField] protected int _maxHp;
    [SerializeField] protected int _attack;
    [SerializeField] protected int _defence;

    public int Level { get { return _level; } set { _level = value; } }
    public int Hp { get { return _hp; } set { _hp = value; } }
    public int MaxHp { get { return _maxHp; } set { _maxHp = value; } }
    public int Attack { get { return _attack; } set { _attack = value; } }
    public int Defence { get { return _defence; } set { _defence = value; } }

    private void Start()
    {
        //_level = 1;
        //_hp = 3;
        //_maxHp = 3;
        //_attack = 1;
        //_defence = 0;
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