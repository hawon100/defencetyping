using UnityEngine;

public class TypingManager
{
    public string _input;
    public string[] _word = new string[4];
    public GameObject tower;

    public Define.InstallTowerType type;

    public void WordReset()
    {
        _word[0] = Managers.Word.BuildWord(_word[0]);
        _word[1] = Managers.Word.AttackWord(_word[1]);
        _word[2] = Managers.Word.SkillWord(_word[2]);
        _word[3] = Managers.Word.FixedWord(_word[3]);
    }

    public bool WordEnd(bool isTyping)
    {
        return isTyping;
    }

    public string WordEnter(string input)
    {
        if (!Input.GetKeyDown(KeyCode.Return)) return input;
        
        WordEnd(false);

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
        }
        else if (_input == _word[1])
        {
            Debug.Log("���� ����");
        }
        else if (_input == _word[2])
        {
            Debug.Log("��ų ����");
        }
        else if (_input == _word[3])
        {
            Debug.Log("���� ����");
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