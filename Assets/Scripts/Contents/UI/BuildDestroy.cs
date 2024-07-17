using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildDestroy : MonoBehaviour
{
    private Image _timer;
    private GameObject _destroyObj;

    private void Start()
    {
        _timer = gameObject.GetComponent<Image>();
        _destroyObj = Util.FindChild(gameObject);
    }

    private void Update()
    {
        if (_timer.fillAmount <= 0)
        {
            _destroyObj.SetActive(false);
        }
        else
        {
            _destroyObj.SetActive(true);
        }
    }
}
