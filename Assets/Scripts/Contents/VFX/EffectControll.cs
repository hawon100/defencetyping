using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectControll : MonoBehaviour
{
    [SerializeField] private float seconds;

    private WaitForSeconds waitSeconds;
    private void Start()
    {
        waitSeconds = new(seconds);
    }

    private void OnEnable()
    {
        StartCoroutine(StableDestroy());
    }

    private IEnumerator StableDestroy()
    {
        yield return waitSeconds;

        transform.localScale = Vector2.one;
        Managers.Resource.Destroy(this.gameObject);
    }
}
