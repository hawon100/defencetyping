using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BuildTower : MonoBehaviour
{
    public RectTransform WordPanel;
    public RectTransform InputPanel;
    public bool isTyping = false;

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Click!");
            PanelOpen();
        }
    }

    private void PanelOpen()
    {
        isTyping = true;
        WordPanel.DOAnchorPosY(540, 0.5f).SetDelay(0.5f);
        InputPanel.DOAnchorPosY(-540, 0.5f).SetDelay(0.5f);
    }

    private void PanelClose()
    {
        isTyping = false;
        WordPanel.DOAnchorPosY(690, 0.5f).SetDelay(0.5f);
        InputPanel.DOAnchorPosY(-690, 0.5f).SetDelay(0.5f);
    }
}