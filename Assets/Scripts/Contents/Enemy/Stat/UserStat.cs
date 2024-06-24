using UnityEngine;

public class UserStat : MonoBehaviour
{
    public UserData user;
    public int fixedPrice;
    public static int Gold;
    public static int FixedPrice;
    public static int maxLevel = 5;

    private void Awake()
    {
        Gold = user.gold;
        FixedPrice = fixedPrice;
    }

    private void Update()
    {
        user.gold = Gold;
        fixedPrice = FixedPrice;
    }
}