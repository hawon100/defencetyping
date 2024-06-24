using UnityEngine;

public class TypingManager
{
    public string _input;
    public string[] _word = new string[4];
    public GameObject tower; //<- GameObject To TowerBase.

    public Define.InstallTowerType type;

    public TowerBase towerBase;
    public TowerStat towerStat;

    //Temp
    public Vector2 curBuildPos;
    private int timeTimeTime;

    public void WordReset()
    {
        _word[0] = Managers.Word.BuildWord(_word[0]);
        _word[1] = Managers.Word.AttackWord(_word[1]);
        _word[2] = Managers.Word.SkillWord(_word[2]);
        _word[3] = Managers.Word.FixedWord(_word[3]);
    }

    public string WordEnter(string input)
    {
        if (!Input.GetKeyDown(KeyCode.Return)) return input;

        if (_input == _word[0])
        {
            Debug.Log("빌드 성공");
            Debug.Log(Managers.Game.teamData);
            switch(type)
            {
                case Define.InstallTowerType.Common: tower = Managers.Resource.Instantiate($"Tower/{Managers.Game.teamData.team[0].prefabName}"); break;
                case Define.InstallTowerType.Rare: tower = Managers.Resource.Instantiate($"Tower/{Managers.Game.teamData.team[1].prefabName}"); break;
                case Define.InstallTowerType.Epic: tower = Managers.Resource.Instantiate($"Tower/{Managers.Game.teamData.team[2].prefabName}"); break;
                case Define.InstallTowerType.Legend: tower = Managers.Resource.Instantiate($"Tower/{Managers.Game.teamData.team[3].prefabName}"); break;
            }
            Debug.Log(tower);
            towerBase = tower.GetComponent<TowerBase>();
            towerStat = tower.GetComponent<TowerStat>();
            towerStat.towerPos = curBuildPos;
            towerStat.Init();
            //towerStat.towerStatUI.
        }
        else if (_input == _word[1])
        {
            Debug.Log("공격 성공");
            towerBase = tower.GetComponent<TowerBase>();
            Debug.Log(tower.name);
            towerBase.Attack();

            //Temp
            //GameObject b = Managers.Resource.Instantiate("Enemys/Bullet");
            //Temp
            //b.GetComponent<BulletBase>().target = tower.GetComponent<TowerBase>()._target;
            //b.GetComponent<PlayerBullet>().test();
            //b.transform.parent = tower.transform;
            //b.transform.position = tower.transform.position;
        }
        else if (_input == _word[2])
        {
            Debug.Log("스킬 성공");
            towerBase = tower.GetComponent<TowerBase>();
            timeTimeTime += 1;
            Debug.Log(timeTimeTime + "번째 스킬 발동 상태: " + towerBase);
            towerBase.Skill();
        }
        else if (_input == _word[3])
        {
            if(UserStat.Gold >= UserStat.FixedPrice)
            {
                UserStat.Gold -= 30;
                Debug.Log("수리 성공");
                towerStat = tower.GetComponent<TowerStat>();
                towerStat.OnFixed(3);
            }
            else
            {
                Debug.Log("수리 실패 돈 부족");
            }
        }
        else
        {
            Debug.Log("실패");
        }

        WordReset();

        input = "";

        return input;
    }
}