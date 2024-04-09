using UnityEngine;

public class InstallTower : TowerBase
{
    [SerializeField] private Define.InstallTowerType _installType;

    protected override void OnAttack()
    {

    }
    
    protected override void AdjustLevel()
    {

    }

    protected override void Skill()
    {

    }
    
    protected override void TowerFixed()
    {

    }

    void OnMouseDown()
    {
        Debug.Log("Click!");
    }
}