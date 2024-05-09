using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRend;

    private WaitForSeconds delay0p2 = new WaitForSeconds(0.2f);

    public void StartBomb() => StartCoroutine(Bombing());

    private IEnumerator Bombing()
    {
        for (int i = 0; i < 3; i++)
        {
            spriteRend.color = Color.red;
            yield return delay0p2;
            spriteRend.color = Color.white;
            yield return delay0p2;
        }
    }
}
