using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBase : MonoBehaviour
{
    [SerializeField] private string triggerTag;

    public Transform target;
    public float speed;

    protected virtual void Awake()
    {
        //target = Managers.Game.target;
    }

    protected virtual void Start()
    {

    }

    protected virtual void Update()
    {
        Move();
    }

    protected virtual void Move()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(triggerTag))
        {
            Hit(other.gameObject);
        }
    }

    protected virtual void Hit(GameObject hitObject)
    {
        StartCoroutine(HitDestroy());
    }

    IEnumerator HitDestroy()
    {
        yield return new WaitForSeconds(1.5f);
        Managers.Resource.Destroy(this.gameObject);
    }
}
