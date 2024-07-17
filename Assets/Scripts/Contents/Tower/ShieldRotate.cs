using UnityEngine;

public class ShieldRotate : MonoBehaviour
{
    public GameObject[] shieldPrefab;
    public Transform shieldCenter;
    public float radius = 5.0f;
    public float rotationSpeed = 30.0f; // 초당 회전 속도 (각도)

    private InstallTowerStat towerStat;
    private float[] angles;
    private int shieldCount;

    private void Awake()
    {
        towerStat = GetComponent<InstallTowerStat>();
    }

    void Start()
    {
        shieldCount = towerStat.Hp;
        shieldPrefab = new GameObject[shieldCount];

        float singleRadius = 360f / shieldCount;
        angles = new float[shieldCount];

        for (int i = 0; i < shieldCount; i++)
        {
            angles[i] = singleRadius * i;
            shieldPrefab[i] = Managers.Resource.Instantiate("Shield", shieldCenter);
            PositionShield(i);
        }
    }

    void FixedUpdate()
    {
        shieldCount = towerStat.Hp;

        UpdateShieldCount();
        // 각도를 회전 속도에 따라 증가시키고 방패의 위치를 업데이트
        for (int i = 0; i < shieldCount; i++)
        {
            angles[i] += rotationSpeed * Time.deltaTime;
            PositionShield(i);
        }
    }

    void PositionShield(int index)
    {

        float radian = angles[index] * Mathf.Deg2Rad;
        shieldPrefab[index].transform.position = new Vector3(Mathf.Cos(radian) * radius,
                                                             Mathf.Sin(radian) * radius,
                                                             shieldCenter.position.z) + shieldCenter.position;
    }

    void UpdateShieldCount()
    {
        // shieldCount 값에 따라 방패 활성화/비활성화
        for (int i = 0; i < shieldPrefab.Length; i++)
        {
            if (i < shieldCount)
            {
                if (!shieldPrefab[i].activeSelf)
                {
                    shieldPrefab[i].SetActive(true);
                }
                PositionShield(i);
            }
            else
            {
                if (shieldPrefab[i].activeSelf)
                {
                    shieldPrefab[i].SetActive(false);
                }
            }
        }
    }
}

