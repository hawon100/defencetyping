using UnityEngine;

public class UserStat : MonoBehaviour
{
    public int fixedPrice;
    public int skillPrice;
    public static int Gold;
    public static int FixedPrice;
    public static int SkillPrice;
    public static int maxLevel = 5;

    private void Awake()
    {
        var jsonData = PlayerPrefs.GetString("GoldData");
        Managers.DSL.goldData = JsonUtility.FromJson<Data.GoldData>(jsonData);
        Gold = Managers.DSL.goldData.coins[0].gold;
        FixedPrice = fixedPrice;
        SkillPrice = skillPrice;
    }
}