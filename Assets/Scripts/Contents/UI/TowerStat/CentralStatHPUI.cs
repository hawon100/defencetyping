using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CentralStatHPUI : MonoBehaviour
{
    public Slider hpSlider;

    private int maxHp;

    private void Awake()
    {

    }

    public void InitHP(int max)
    {
        maxHp = max;
        hpSlider.value = 1;
    }

    public void UpdateHP(int hp)
    {
        hpSlider.value = (float)hp / maxHp;
    }
}
