using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    //[System.Serializable]
    //public class SpawnMob //public class Wave
    //{
    //    public GameObject Object; //WaveManager
    //    [Range(0, 100)] public int Probability;
    //}

    public List<Wave> generalWave;
    public List<Wave> bossWave;
    public float spawnTime;
    public int spawnCount;

    public int curEnemy;

    private PoolManager poolManager; //이러한 것들을 실행시킬 것들이 필요

    private Vector3 spawnPos;

    private float timeRate;


    public bool isSpawn = true;

    private int count;

    private void Awake()
    {
        poolManager = Managers.Pool;
        Managers.Spawn.generalWave = generalWave;
    }

    private void Start()
    {
        ExecuteWave(generalWave[Random.Range(0, generalWave.Count)]);    
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

                Poolable poolable = poolManager.Pop(wave.Mob[i].Object, transform);

                poolable.transform.parent = null;
                poolable.transform.position = spawnPos;

                curEnemy++;
            }
        }
    }

    public void RemoveObject()
    {
        curEnemy -= 1;

        if (curEnemy <= 0)
        {
            curEnemy = 0;
            ExecuteWave(generalWave[Random.Range(0, generalWave.Count)]);
        }
    }

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
