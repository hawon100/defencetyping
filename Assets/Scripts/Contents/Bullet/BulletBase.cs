using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBase : MonoBehaviour
{//전체 코드 바꾸기.
    [SerializeField] private string triggerTag;

    public Transform target;
    public float speed;

    protected Vector3 targetPos;

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
}
