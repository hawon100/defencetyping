using UnityEngine;

public class BuildTower : MonoBehaviour
{
    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Click!");
            var go = Managers.Resource.Instantiate("Tower/InstallTower");
            go.transform.parent = transform;
        }
    }
}