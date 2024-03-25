using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBase : MonoBehaviour
{
    [SerializeField] private string triggerTag;

    protected PoolManager poolManager;
    protected Poolable poolable;

    protected virtual void Start()
    {
        poolManager = Managers.Pool;
        poolable = GetComponent<Poolable>();
    }

    protected virtual void Update()
    {
        Move();
    }

    protected virtual void Move()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(triggerTag))
        {
            Hit();
        }
    }

    protected virtual void Hit()
    {
        if (poolManager != null && poolable != null)
            poolManager.Push(poolable);
    }
}
