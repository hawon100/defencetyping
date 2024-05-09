using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBase : MonoBehaviour
{//��ü �ڵ� �ٲٱ�.
    [SerializeField] private string triggerTag;

    public Transform target;
    public float speed;

    protected Vector3 targetPos;

    protected TrailRenderer trailRend; //Temp -> private
    protected virtual void Awake()
    {
        trailRend = GetComponent<TrailRenderer>();
    }

    public virtual void Init()
    {
        //trailRend.Clear();
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

    //private void OnTriggerEnter2D(Collider2D other)
    //{
    //    if (other.gameObject.CompareTag(triggerTag))
    //    {
    //        target = null;
    //        Hit(other.gameObject);
    //    }
    //}

    protected bool Measure(Vector3 Vector, float distance)
    {
        return Vector.sqrMagnitude <= distance * distance;
    }

    protected virtual void Hit()
    {
        trailRend.Clear();
        Managers.Resource.Destroy(gameObject);
    }
}
