using UnityEngine;

public abstract class TowerBase : MonoBehaviour
{
    protected Define.TowerType type;
    protected abstract void Skill();
}