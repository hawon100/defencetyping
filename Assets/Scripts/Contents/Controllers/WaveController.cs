using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //Temp

public class WaveController : MonoBehaviour
{
    [SerializeField] private Stage thisStage;

    [SerializeField] private Text waveText; //Temp
    [SerializeField] private Image analogPanel;
    [SerializeField] private GameObject returnButton;
    [SerializeField] private Color darkColor;
    [SerializeField] private Text gameText;
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

        analogPanel.color = Color.Lerp(analogPanel.color, darkColor, 1.2f * Time.deltaTime);

        if (Mathf.Round(analogPanel.color.r) == darkColor.r)
        {
            returnButton.SetActive(true);
            if (Managers.Wave.isWin)
            {
                gameText.text = "You Win !";
            }
            else
            {
                gameText.text = "Game Over !";
            }
        }
    }
}
