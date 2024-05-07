using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSelect : MonoBehaviour
{
    public RectTransform infoPanel;

    public void StageSelect(string sceneName)
    {
        switch(sceneName)
        {
            case "Korea War": infoPanel.DOAnchorPosX(0, 0.5f); break;
        }
    }
}
