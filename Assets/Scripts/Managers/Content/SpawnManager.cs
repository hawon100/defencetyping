using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour //Only Funcions
{
    public List<Wave> waves = new List<Wave>();
    public List<GameObject> curEnemy;
    public Vector3 spawnPos;

    private void Start()
    {
        ExecuteWave(waves[Random.Range(0, waves.Count)]);     
    }

    public void ExecuteWave(Wave wave)
    {
        if (wave == null) return;

        for (int i = 0; i < wave.Mob.Count; i++)
        {
            for (int j = 0; j < wave.Mob[i].Count; j++)
            {
                float rad = Random.Range(0, 360) * Mathf.Deg2Rad;

                spawnPos.x = Mathf.Cos(rad) * 20f;
                spawnPos.y = Mathf.Sin(rad) * 20f;

                GameObject enemy = Managers.Resource.Instantiate(wave.Mob[i].Enemy.gameObject, transform.parent = null);

                enemy.transform.parent = null;
                enemy.transform.position = spawnPos;

                curEnemy.Add(enemy);
            }
        }
    }

    //public void 

    //private void Update()
    //{
    //    if (timeRate >= spawnTime)
    //    {
    //        timeRate -= spawnTime;
    //        if (isSpawn) Spawn();
    //    }
    //    else
    //    {
    //        timeRate += Time.deltaTime;
    //    }   
    //}

    //public void Spawn()
    //{
    //    for (int index = 0; index < spawnCount; index++)
    //    {
    //        for (int i = 0; i < spawnMob.Count; i++)
    //        {
    //            if (Random.Range(0, 100) < spawnMob[i].Probability)
    //            {
    //                float deg = Random.Range(0, 360) * Mathf.Rad2Deg;

    //                spawnPos.x = Mathf.Cos(deg) * 20f;
    //                spawnPos.y = Mathf.Sin(deg) * 20f;

    //                Poolable poolable = poolManager.Pop(spawnMob[i].Object, transform);

    //                poolable.transform.parent = null;
    //                poolable.transform.position = spawnPos;
    //            }
    //        }
    //    }

    //    if (count >= 3) isSpawn = false;

    //    count += 1;
    //}
}
