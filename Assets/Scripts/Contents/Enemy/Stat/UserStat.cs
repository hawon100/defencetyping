using UnityEngine;

public class UserStat : MonoBehaviour
{
    public UserData user;
    public int fixedPrice;
    public int skillPrice;
    public static int Gold;
    public static int FixedPrice;
    public static int SkillPrice;
    public static int maxLevel = 5;

    private void Awake()
    {
        Gold = user.gold;
        FixedPrice = fixedPrice;
        SkillPrice = skillPrice;
    }
}