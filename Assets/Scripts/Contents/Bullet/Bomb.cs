using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRend;
    [SerializeField] private GameObject boom;

    private WaitForSeconds delay0p2 = new WaitForSeconds(0.2f);
    private WaitForSeconds delay0p5 = new WaitForSeconds(0.5f);

    public void StartBomb() => StartCoroutine(Bombing());

    private IEnumerator Bombing()
    {
        yield return delay0p5;

        for (int i = 0; i < 3; i++)
        {
            spriteRend.color = Color.red;
            yield return delay0p2;
            spriteRend.color = Color.white;
            yield return delay0p2;
        }

        GameObject b = Managers.Resource.Instantiate(boom, null);
        b.transform.position = transform.position;

        Death();
    }

    private void Death()
    {
        Managers.Resource.Destroy(this.gameObject);
    }
}
