using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSelect : MonoBehaviour
{
    public void StageSelect(string sceneName)
    {
        switch(sceneName)
        {
            case "Korea War": Managers.Map.LoadScene(Define.Scene.Game); break;
        }
    }
}
