using UnityEngine;

public class BuildTower : MonoBehaviour
{
    public TowerBase tower;
    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Click!");
            GameObject go = Managers.Resource.Instantiate(tower.gameObject, transform);
            go.transform.parent = transform;
            go.transform.position = transform.position;
        }
    }
}