using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerUI : MonoBehaviour
{
    public WaveController waveController;

    List<GameObject> _list = new();

    bool corutineAllowed;

    private void Start()
    {
        for(int i = 0; i < waveController.thisStage.TowerBuilderPos.Count; i++)
        {
            var obj = Managers.Resource.Instantiate("UI/Timer/Timer", gameObject.transform);
            _list.Add(obj);
            obj.transform.position = waveController.thisStage.TowerBuilderPos[i];
            obj.transform.localScale = new Vector3(1, 1, 1);
            obj.GetComponent<Image>().fillAmount = 0;
        }
    }

    private void Update()
    {
        for(int i = 0; i < waveController.gameController.towers.Count; i++)
        {
            if (Util.FindChild<InstallTowerStat>(waveController.gameController.towers[i + 1].gameObject) == null) return;

            if (Util.FindChild<InstallTowerStat>(waveController.gameController.towers[i + 1].gameObject).isDestroy)
            {
                var image = _list[i].GetComponent<Image>();
                if(image.fillAmount != 1)
                {
                    image.fillAmount = 1;
                    StartCoroutine(DecreaseFillAmount(image, 5f));
                }
            }
        }
    }

    private IEnumerator DecreaseFillAmount(Image image, float duration)
    {
        float startFillAmount = image.fillAmount;
        float endFillAmount = 0;
        float elapsed = 0;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            image.fillAmount = Mathf.Lerp(startFillAmount, endFillAmount, elapsed / duration);
            yield return null;
        }

        image.fillAmount = endFillAmount;
    }
}
