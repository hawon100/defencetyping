using UnityEngine;
using UnityEngine.UI;

public class TestScene : BaseScene
{
    public Text[] text;

    public InputField typingInput;
    public GameObject tower;

    protected override void Init()
    {
        base.Init();

        SceneType = Define.Scene.TestHawon;
    }

    private void Update()
    {
        for (int i = 0; i < text.Length; i++)
        {
            text[i].text = Managers.Typing._word[i];
        }
        Managers.Typing._input = typingInput.text;

        typingInput.text = Managers.Typing.WordEnter(typingInput.text);

        if (Managers.Typing.tower == null) return;

        Managers.Typing.tower.transform.parent = tower.transform;
        Managers.Typing.tower.transform.position = tower.transform.position;
    }

    public override void Clear()
    {

    }
}
