using UnityEngine;

public abstract class TowerBase : MonoBehaviour
{
    [SerializeField] protected Define.TowerType _type;
    [SerializeField][Range(0.0f, 10.0f)] protected float _range;
    [SerializeField] protected string _targetTag;
    protected Transform _target;

    protected abstract void Start();
    protected abstract void Update();
    protected abstract void OnAttack();
    protected abstract void AdjustLevel();
    protected abstract void Skill();
    protected abstract void TowerFixed();
    protected abstract void OnDamaged();

    protected virtual void Detected()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, _range);
        
        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag(_targetTag))
            {
                if (_target == null) return;

                _target = collider.transform;
            }
        }
    }

    protected virtual void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, _range);
    }
}