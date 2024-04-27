using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public List<Wave> waves = new List<Wave>();
    private bool isSpawn;
    private int waveCount;
    private void Start()
    {
        //Managers.Spawn.Init();
        //Temp - Start
        Managers.Spawn.spawnArea = new Transform[4];

        for (int i = 0; i < 4; i++)
        {
            //GameObject s = Managers.Resource.Instantiate("SpawnArea/SpawnArea" + i, transform.parent);
            GameObject sa = Managers.Resource.Instantiate("SpawnArea/SpawnArea" + i, transform.parent);

            Managers.Spawn.spawnArea[i] = sa.transform;
        }
        //End

        waveCount = Managers.Spawn.waves.Count;

        for (int i = 0; i < waveCount; i++)
        {
            Managers.Spawn.waves.Add(waves[i]);
        }

        Managers.Spawn.ExecuteWave(waves[1]);
    }

    private void FixedUpdate()
    {
        isSpawn = Managers.Spawn.curEnemy.Count <= 0 == true;

        if (!isSpawn) return;

        isSpawn = false;
        Managers.Spawn.ExecuteWave(waves[Random.Range(0, waveCount)]);
    }
}
