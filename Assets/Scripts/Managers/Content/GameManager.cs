using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Player")]
    public Transform target;
    public Transform background;
    public float absScreenX;
    public float absScreenY;
    public void Init()
    {
        target = GameObject.Find("TowerCenter").transform;
        background = GameObject.Find("Back").transform;
        absScreenX = background.localScale.x / 2;
        absScreenY = background.localScale.y / 2;
    }
}
