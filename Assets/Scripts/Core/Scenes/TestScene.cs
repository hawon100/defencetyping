using UnityEngine;
using UnityEngine.UI;

public class TestScene : BaseScene
{
    public Text[] text;

    public InputField typingInput;

    public BuildTower[] towers;
    public BuildTower tower;

    public float curDelayChange;
    public float maxDelayChange;

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

        for (int i = 0; i < towers.Length; i++)
        {
            if (towers[i].isTyping == true)
            {
                tower = towers[i];
            }
        }

        if (Managers.Typing.tower == null) return;

        Managers.Typing.tower.transform.parent = tower.transform;
        Managers.Typing.tower.transform.position = tower.transform.position;
    }

    private void Reload()
    {
        curDelayChange += Time.deltaTime;
        if (curDelayChange < maxDelayChange) return;

        Managers.Typing.WordReset();

        curDelayChange = 0;
    }

    public override void Clear()
    {

    }
}
