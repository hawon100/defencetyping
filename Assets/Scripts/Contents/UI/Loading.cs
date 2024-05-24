using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Loading : MonoBehaviour
{
    public Slider progressbar;
    public Text loadtext;

    private void Start()
    {
        StartCoroutine(LoadScene());
    }

    private IEnumerator LoadScene()
    {
        yield return null;
    }
}