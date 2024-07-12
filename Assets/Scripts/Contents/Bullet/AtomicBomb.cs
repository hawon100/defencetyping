using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtomicBomb : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private float explosionTime;

    private WaitForSeconds second0p2 = new(0.2f);

    private BarController timeBar;
    private float timeRate;
    private void OnEnable()
    {
        GameObject t = Managers.Resource.Instantiate("UI/");

        timeRate = explosionTime;
        timeBar = t.GetComponent<BarController>();
        timeBar.Init2Float(explosionTime);
    }

    private void OnDisable()
    {
        StopCoroutine(StartAtomicBomb());
    }

    private void FixedUpdate()
    {
        timeRate -= Time.deltaTime;
        timeBar.Updated2Float(timeRate);

        if (timeRate > 1) return;

        timeRate = explosionTime;
        StartCoroutine(StartAtomicBomb());
    }

    private IEnumerator StartAtomicBomb()
    {
        for (int i = 0; i < 3; i++)
        {
            spriteRenderer.color = Color.red;
            yield return second0p2;
            spriteRenderer.color = Color.white;
            yield return second0p2;
        }

        GameObject a = Managers.Resource.Instantiate("Skills/AtomicWave", null);
        a.transform.position = transform.position;

        yield return second0p2;

        Managers.Resource.Destroy(this.gameObject);
    }
}
