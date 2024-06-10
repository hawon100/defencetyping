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
    }

    private void Update()
    {
        Gold = _gold;
        FixedPrice = _fixedPrice;
    }
}