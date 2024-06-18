using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class CharDataEdit
{
    public string charName;
    public Sprite charImage;
    public Button charButton;
    public GameObject charObj;
}

public class TeamEdit : MonoBehaviour
{
    public GameObject content;
    public List<CharDataEdit> dataEdit = new();
    public List<GameObject> holder = new List<GameObject>(4);
    List<GameObject> _charDataList = new();

    private void Start()
    {
        for (int i = 0; i < 100; i++) _charDataList.Add(Managers.Resource.Instantiate("UI/Lobby/CharButton"));
        foreach (var obj in _charDataList) Managers.Resource.Destroy(obj);

        for (int i = 0; i < dataEdit.Count; i++)
        {
            var obj = Managers.Resource.Instantiate("UI/Lobby/CharButton");
            dataEdit[i].charObj = obj;
            dataEdit[i].charObj.transform.parent = content.transform;
            dataEdit[i].charObj.FindChild<Text>().text = dataEdit[i].charName;
            dataEdit[i].charObj.FindChild<Image>().sprite = dataEdit[i].charImage;
            dataEdit[i].charButton = dataEdit[i].charObj.GetComponent<Button>();
        }

        dataEdit[0].charButton.onClick.AddListener(() => CharAdd(0));
    }

    private void CharAdd(int i)
    {
        Debug.Log($"{i}");
        Debug.Log($"{i%4}");
        dataEdit[i].charObj.transform.parent = holder[i % 4].transform;
        dataEdit[i].charObj.transform.localScale = holder[i % 4].transform.localScale;
    }

    public void OnButtonClick()
    {
        // Remove Character 
    }
}
