using UnityEngine;

public abstract class TowerBase : MonoBehaviour
{
    [SerializeField] protected Define.TowerType _type;
    [SerializeField][Range(0.0f, 10.0f)] protected float _range;
    [SerializeField] protected string _targetTag;
    public Transform _target; //T3mp -> protected


    public Vector2 targetPos;//TEMTemp

    protected abstract void Start();
    protected virtual void Update()
    {

    }
    protected abstract void OnAttack();
    protected abstract void AdjustLevel();
    protected abstract void Skill();
    protected abstract void TowerFixed();
    protected abstract void OnDamaged();

    protected virtual void Detected()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, _range);

        //_target = null;

        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag(_targetTag))
            {
                _target = collider.transform;
                targetPos = _target.position;
                return;
            }
        }

        _target = null;

        //// 감지 범위 내에 타겟이 없으면 초기 위치로 돌아가기
        //if (Vector3.Distance(transform.position, originalPosition) > returnRadius)
        //{
        //    _target = null;
        //    _agent.SetDestination(originalPosition);
        //}
    }

    protected float Gaze(Vector3 currentVec, Vector3 targetVec)
    {
        float degree = Mathf.Atan2(targetVec.y - currentVec.y, targetVec.x - currentVec.x);

        return degree * Mathf.Rad2Deg;
    }

    protected virtual void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, _range);
    }

    public virtual void Attack()
    {
        OnAttack();
    }
}