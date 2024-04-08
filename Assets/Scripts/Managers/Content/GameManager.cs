using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Player")]
    public Transform target; //���� Script ����
    //Managers.Game.target = target
    //��� �����ʹ� Scene�� �ƴ� Script ���� ������ ��!
    private void Awake()
    {
        target = GameObject.Find("Target").transform;
        Debug.Log(target);
        Managers.Game.target = target;
    }
}
