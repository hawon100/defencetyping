using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SwipeMenu : MonoBehaviour
{
    public RectTransform levelPanel;
    public GameObject scrollbar;
    private float scroll_pos = 0;
    private float[] pos;

    public delegate void ScrollPosChanged(float newScrollPos);
    public event ScrollPosChanged OnScrollPosChanged;

    public float ScrollPos
    {
        get { return scroll_pos; }
        set
        {
            if (scroll_pos != value)
            {
                scroll_pos = value;
                OnScrollPosChanged?.Invoke(scroll_pos);
            }
        }
    }

    protected virtual void Update()
    {
        pos = new float[transform.childCount];
        float distance = 1f / (pos.Length - 1f);

        for (int i = 0; i < pos.Length; i++)
        {
            pos[i] = distance * i;
        }

        if (Input.GetMouseButton(0))
        {
            ScrollPos = scrollbar.GetComponent<Scrollbar>().value;
        }
        else
        {
            for (int i = 0; i < pos.Length; i++)
            {
                if (scroll_pos < pos[i] + (distance / 2) && scroll_pos > pos[i] - (distance / 2))
                {
                    scrollbar.GetComponent<Scrollbar>().value = Mathf.Lerp(scrollbar.GetComponent<Scrollbar>().value, pos[i], 0.1f);
                }
            }
        }

        for (int i = 0; i < pos.Length; i++)
        {
            if (scroll_pos < pos[i] + (distance / 2) && scroll_pos > pos[i] - (distance / 2))
            {
                transform.GetChild(i).localScale = Vector2.Lerp(transform.GetChild(i).localScale, new Vector2(1f, 1f), 0.1f);
                for (int j = 0; j < pos.Length; j++)
                {
                    if (j != i)
                    {
                        transform.GetChild(j).localScale = Vector2.Lerp(transform.GetChild(j).localScale, new Vector2(0.8f, 0.8f), 0.1f);
                    }
                }
            }
        }
    }

    private void Start()
    {
        OnScrollPosChanged += HandleScrollPosChanged;
    }

    private void HandleScrollPosChanged(float newScrollPos)
    {
        //Debug.Log("Scroll position changed to: " + newScrollPos);
        levelPanel.DOAnchorPosY(-815, 0.5f);
    }

    private void OnDestroy()
    {
        OnScrollPosChanged -= HandleScrollPosChanged;
    }
}
