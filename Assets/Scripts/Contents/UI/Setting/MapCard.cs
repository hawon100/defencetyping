using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapCard : MonoBehaviour
{
    [Header("Map Card Front")]
    [SerializeField]
    private Image image;
    [SerializeField]
    private Text text;

    [Header("Map Card Back")]
    [SerializeField]
    private GameObject panel;

    private bool corutineAllowed, facedUp;

    private void Start()
    {
        corutineAllowed = true;
        facedUp = false;
    }

    public void OnButtonDown()
    {
        if (corutineAllowed)
        {
            StartCoroutine(RotateCard());
        }
    }

    private IEnumerator RotateCard()
    {
        corutineAllowed = false;

        if(!facedUp)
        {
            for(float i = 0f; i <= 180f; i+=10f)
            {
                transform.rotation = Quaternion.Euler(0f, i, 0f);
                if(i == 90f)
                {
                    image.enabled = false;
                    text.enabled = false;
                    panel.SetActive(true);
                }
                yield return new WaitForSeconds(0.01f);
            }
        }
        else if (facedUp)
        {
            for (float i = 180f; i>= 0f; i-=10f)
            {
                transform.rotation = Quaternion.Euler(0f, i, 0f);
                if (i == 90f)
                {
                    image.enabled = true;
                    text.enabled = true;
                    panel.SetActive(false);
                }
                yield return new WaitForSeconds(0.01f);
            }
        }

        corutineAllowed = true;
        facedUp = !facedUp;
    }
}
