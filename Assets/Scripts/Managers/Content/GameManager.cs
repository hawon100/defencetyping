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

    public Stage currentStage;

    public Transform uiCanvas;

    public Vector3 checkedTowerPos;

    public void Init()
    {
        //absScreenX = background.localScale.x / 2;
        //absScreenY = background.localScale.y / 2;
    }

    public void EndGame()
    {

    }
}
