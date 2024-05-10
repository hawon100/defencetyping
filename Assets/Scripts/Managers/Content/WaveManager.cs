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
    public bool isWave = true;
    public bool isWin = false;
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

        Debug.Log("Wave " + (currentWave + 1) + "/Spawned : " + currentEnemy);
    }

    public void WaveUpdate() //Problem
    {
        currentEnemy -= 1;

        if (currentEnemy <= 0)
        {
            Debug.Log("Wave " + (currentWave + 1) + "/Destroyed : " + currentEnemy);
            currentEnemy = 0;
            WaveChange();
        }
    }

    public void WaveChange()                                        
    {
        if (currentWave + 1 >= stage.Wave.Count)
        {
            WaveEnd();
            return;
        }
        
        currentWave += 1;
        WaveExecute(stage.Wave[currentWave]);
    }

    public void WaveEnd()
    {
        Debug.Log("Wave End!");
        isWave = false;
        isWin = true;
    }
}
