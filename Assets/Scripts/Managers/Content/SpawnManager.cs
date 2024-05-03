using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour //Only Funcions
{
    public List<Wave> waves = new List<Wave>();
    public List<GameObject> curEnemy = new List<GameObject>(); //To GameManager
    public Transform[] spawnArea;
    public Vector3 spawnPos;
    public void Init()
    {
        Debug.Log("Fuck yOu!");
        //Spawn Area
        spawnArea = new Transform[4];
        
        for (int i = 0; i < 4; i++)
        {
            //GameObject s = Managers.Resource.Instantiate("SpawnArea/SpawnArea" + i, transform.parent);

        }

        Debug.Log(spawnArea[3] == null);
    }

    private void Start() //Temp
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
                Transform area = spawnArea[Random.Range(0, spawnArea.Length)];

                spawnPos.x = Random.Range(area.position.x - area.localScale.x / 2,
                                          area.position.x + area.localScale.x / 2);
                spawnPos.y = Random.Range(area.position.y - area.localScale.y / 2,
                                          area.position.y + area.localScale.y / 2);

                GameObject enemy = Managers.Resource.Instantiate(wave.Mob[i].Enemy.gameObject);

                enemy.transform.position = spawnPos;

                curEnemy.Add(enemy);
            }
        }
    }

    //public void 
}
