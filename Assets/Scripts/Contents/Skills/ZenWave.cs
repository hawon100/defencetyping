using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZenWave : BulletBase
{
    [SerializeField] private float seconds;

    private WaitForSeconds waitSeconds;
    protected override void Awake()
    {
        Debug.Log("Start");
        waitSeconds = new(seconds);
    }

    //private void OnEnable()
    public void StableStart()
    {
        Debug.Log("StableStart");
        StartCoroutine(StableDestroy());
    }

    private IEnumerator StableDestroy()
    {
        yield return waitSeconds;

        transform.localScale = Vector2.one;
        Managers.Resource.Destroy(transform.parent.gameObject);

        StopCoroutine(StableDestroy());
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log(other.name);

        if (!other.gameObject.CompareTag(triggerTag)) return;

        if (triggerTag == "Enemy") other.GetComponent<EnemyStatBase>().Damage(damage);
        if (triggerTag == "Tower") other.GetComponent<TowerStat>().OnAttacked(damage);
    }
}
