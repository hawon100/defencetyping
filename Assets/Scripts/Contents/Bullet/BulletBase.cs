using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBase : MonoBehaviour
{//전체 코드 바꾸기.
    public string triggerTag;

    public Transform target;
    public float speed;
    public int damage;

    protected Vector3 targetPos;

    protected TrailRenderer trailRend; //Temp -> private
    protected virtual void Awake()
    {
        trailRend = GetComponent<TrailRenderer>();
    }

    public virtual void Init()
    {
        trailRend.Clear();
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

    protected bool Measure(Vector3 Vector, float distance)
    {
        return Vector.sqrMagnitude <= distance * distance;
    }

    protected virtual void Hit()
    {
        trailRend.Clear();
        Managers.Resource.Destroy(gameObject);
    }

    protected bool isDistance(Vector3 currentVec, Vector3 targetVec, float distance)
    {
        return (targetVec - currentVec).sqrMagnitude <= distance * distance;
    }
}
