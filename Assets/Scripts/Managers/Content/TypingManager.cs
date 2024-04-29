using UnityEngine;

public class TypingManager
{
    public string _input;
    public string[] _word = new string[4];
    public GameObject tower; //<- GameObject To TowerBase.

    public Define.InstallTowerType type;

    //public TowerBase towerBase;
    //public TowerStat towerStat;

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
            Debug.Log("���� ����");
            switch(type)
            {
                case Define.InstallTowerType.Common: tower = Managers.Resource.Instantiate("Tower/CommonTower"); break;
                case Define.InstallTowerType.Rare: tower = Managers.Resource.Instantiate("Tower/RareTower"); break;
                case Define.InstallTowerType.Epic: tower = Managers.Resource.Instantiate("Tower/EpicTower"); break;
                case Define.InstallTowerType.Legend: tower = Managers.Resource.Instantiate("Tower/LegendTower"); break;
            }

            Debug.Log(tower);
            //towerBase = tower.GetComponent<TowerBase>();
            //towerStat = tower.GetComponent<TowerStat>();
            //towerStat.towerStatUI.
        }
        else if (_input == _word[1])
        {
            Debug.Log("���� ����");
            Debug.Log(tower);

            // if (tower == null) return "Null";

            tower.GetComponent<TowerBase>().Attack();

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
            Debug.Log("��ų ����");
        }
        else if (_input == _word[3])
        {
            Debug.Log("���� ����");

            //tower.GetComponent<TowerStat>().OnFixed(1);
        }
        else
        {
            Debug.Log("����");
        }

        WordReset();

        input = "";

        return input;
    }
}