using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController Instance { get; private set; }

    public Text[] text;

    public InputField typingInput;

    public BuildTower[] towers;
    public BuildTower tower;

    public float curDelayChange;
    public float maxDelayChange;

    private void Start()
    {
        Instance = this;
    }

    private void Update()
    {
        Update_WordTyping();
        Update_Build();
    }

    private void Update_WordTyping()
    {
        for (int i = 0; i < text.Length; i++)
        {
            text[i].text = Managers.Typing._word[i];
        }

        Managers.Typing._input = typingInput.text;

        typingInput.text = Managers.Typing.WordEnter(typingInput.text);

        for (int i = 0; i < towers.Length; i++)
        {
            if (towers[i].isTyping)
            {
                tower = towers[i];
            }
        }
    }

    private void Update_Build()
    {
        if (Managers.Typing.tower == null) return;
        if (tower == null) return;

        Managers.Typing.tower.transform.parent = tower.transform;
        Managers.Typing.tower.transform.position = tower.transform.position;

        if (!tower.isTyping)
        {
            tower = null;
            Managers.Typing.tower = null;
        }
    }

    private void WordReload()
    {
        curDelayChange += Time.deltaTime;

        if (curDelayChange < maxDelayChange) return;

        Managers.Typing.WordReset();

        curDelayChange = 0;
    }
}