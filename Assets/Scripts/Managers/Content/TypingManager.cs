using UnityEngine;

public class TypingManager : MonoBehaviour
{
    public string _input;
    public string[] _word = new string[4];
    public GameObject tower;

    public void Init()
    {
        WordReset();
    }

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
            tower = Managers.Resource.Instantiate("Tower/InstallTower");
        }
        else if (_input == _word[1])
        {
            Debug.Log("공격 성공");
            //Temp
            GameObject b = Managers.Resource.Instantiate("Enemys/Bullet");
            //Temp
            b.GetComponent<BulletBase>().target = tower.GetComponent<TowerBase>()._target;
            b.GetComponent<PlayerBullet>().test();
            b.transform.parent = tower.transform;
            b.transform.position = tower.transform.position;
        }
        else if (_input == _word[2])
        {
            Debug.Log("스킬 성공");
        }
        else if (_input == _word[3])
        {
            Debug.Log("수리 성공");
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