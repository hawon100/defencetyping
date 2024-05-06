using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public Stage stage;
    public Transform[] spawnArea;
    public Vector3 spawnPos;
    public int currentWave;
    public int currentEnemy;
    public void Init()
    {
        
    }

    public void WaveStart()
    {
        if (stage == null) return;

        WaveExecute(stage.Wave[0]);
    }

    public void WaveExecute(Wave wave)
    {
        if (wave == null) return;

        for (int i = 0; i < wave.WaveEnemie.Count; i++)
        {
            for (int j = 0; j < wave.WaveEnemie[i].Amount; j++)
            {
                Transform area = spawnArea[Random.Range(0, spawnArea.Length)];

                spawnPos.x = Random.Range(area.position.x - area.localScale.x / 2,
                                          area.position.x + area.localScale.x / 2);
                spawnPos.y = Random.Range(area.position.y - area.localScale.y / 2,
                                          area.position.y + area.localScale.y / 2);

                GameObject enemy = Managers.Resource.Instantiate(wave.WaveEnemie[i].Enemy.gameObject);

                enemy.transform.position = spawnPos;

                currentEnemy += 1;
            }
        }
    }

    public void WaveUpdate()
    {
        currentEnemy -= 1;

        if (currentEnemy <= 0)
        {
            currentEnemy = 0;
            WaveChange();
        }
    }

    public void WaveChange()
    {
        currentWave += 1;
        WaveExecute(stage.Wave[currentWave]);
    }
}