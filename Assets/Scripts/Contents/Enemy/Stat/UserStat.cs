using UnityEngine;

public class UserStat : MonoBehaviour
{
    public static UserStat Instance { get; private set; }

    public int _gold;
    public int _fixedPrice;
    public static int Gold;
    public static int FixedPrice;

    private void Awake()
    {
        Instance = this;
        Gold = _gold;
        FixedPrice = _fixedPrice;
    }

    private void Update()
    {
        _gold = Gold;
        _fixedPrice = FixedPrice;
    }
}