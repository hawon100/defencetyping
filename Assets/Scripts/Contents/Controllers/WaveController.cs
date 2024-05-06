using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveController : MonoBehaviour
{
    [SerializeField] private Stage thisStage;
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
    }
}
