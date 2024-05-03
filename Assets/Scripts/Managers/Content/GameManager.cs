using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Player")]
    public Transform target; 
    public void Init()
    {
        target = GameObject.Find("CenteralTower").transform;
    }
}
