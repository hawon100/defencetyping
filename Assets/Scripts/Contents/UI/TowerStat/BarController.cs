using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarController : MonoBehaviour
{
    public Slider hpSlider;

    private RectTransform rect;

    private int maximum;
    private float maximum2Float;

    private void Awake()
    {
        rect = GetComponent<RectTransform>();
        rect.localScale = Vector2.one;
        Debug.Log("Activate");
    }

    public void Init(int max)
    {
        maximum = max;
        hpSlider.value = 1;
    }

    public void SetPosition(Vector2 position)
    {
        rect.localPosition = position;
    }

    public void Updated(int hp)
    {
        hpSlider.value = (float)hp / maximum;
    }

    public void Init2Float(float max)
    {
        maximum2Float = max;
        hpSlider.value = 1;
    }

    public void Updated2Float(float current)
    {
        hpSlider.value = (float)current / maximum2Float;
    }
}
