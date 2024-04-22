using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Player")]
    public Transform target; //따로 Script 제작
    //Managers.Game.target = target
    //모든 데이터는 Scene이 아닌 Script 내에 저장할 것!
    public void Init()
    {
        target = GameObject.Find("Target").transform;
        Debug.Log(target);
        Managers.Game.target = target;
    }
}
