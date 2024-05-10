using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //Temp

public class WaveController : MonoBehaviour
{
    [SerializeField] private Stage thisStage;

    [SerializeField] private Text waveText; //Temp
    [SerializeField] private Image analogPanel;
    [SerializeField] private Button returnButton;
    private int curWave;
    private void Start()
    {
        Managers.Wave.spawnArea = new Transform[4];
        Managers.Game.Init();

        for (int i = 0; i < 4; i++)
        {
            GameObject sa = Managers.Resource.Instantiate("SpawnArea/SpawnArea" + i, transform.parent);

            Managers.Wave.spawnArea[i] = sa.transform;
        }

        Managers.Wave.stage = thisStage;
        Managers.Wave.WaveStart();
        UpdateWave_Temp();
    }

    private void FixedUpdate()
    {
        UpdateWave_Temp();
        UpdateGame();
    }

    private void UpdateWave_Temp()
    {
        waveText.text = "Wave : " + (Managers.Wave.currentWave + 1);
    }

    private void UpdateGame()
    {
        if (Managers.Wave.isWave) return;

        float alpha = Mathf.Lerp(analogPanel.color.a, 0.5f, Time.deltaTime * 0.2f);
        Color color = new Color(1, 1, 1, alpha);
        analogPanel.color = color;

        if (Mathf.Round(analogPanel.color.a) == 0.5f)
        {
            returnButton.enabled = true;
        }
    }
}
