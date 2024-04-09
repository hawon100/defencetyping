using UnityEngine;

public abstract class TowerBase : MonoBehaviour
{
    [SerializeField] protected Define.TowerType _type;
    [SerializeField][Range(0.0f, 10.0f)] protected float _range;
    [SerializeField] protected string targetTag;

    protected abstract void OnAttack();
    protected abstract void AdjustLevel();
    protected abstract void Skill();
    protected abstract void TowerFixed();

    protected virtual void Detected()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, _range);
        foreach (var collider in colliders)
        {
            if (collider.CompareTag(targetTag))
            {
                target = collider.transform;
                return;
            }
        }

        // 감지 범위 내에 타겟이 없으면 초기 위치로 돌아가기
        if (Vector3.Distance(transform.position, originalPosition) > returnRadius)
        {
            target = null;
            agent.SetDestination(originalPosition);
        }
    }

    protected virtual void OnGuI()
    {

    }
}