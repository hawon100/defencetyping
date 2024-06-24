using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZenWave : MonoBehaviour
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
        Managers.Resource.Destroy(transform.parent.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.name);

        if (!other.gameObject.CompareTag("Enemy")) return;

        other.GetComponent<EnemyStatBase>().Damage(10);
    }
}
