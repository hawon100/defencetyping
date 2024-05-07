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
            case "Korea War": PanelOpen(); break;
            case "Background": PanelClose(); break;
        }
    }

    private void PanelOpen()
    {
        infoPanel.DOAnchorPosX(0, 0.5f);
    }

    private void PanelClose()
    {
        infoPanel.DOAnchorPosX(-600, 0.5f);
    }
}
