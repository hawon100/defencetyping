using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    static Managers s_instance;
    static Managers Instance { get { Init(); return s_instance; } }

    //Content
    GameManager _game = new GameManager();
    SpawnManager _spawn = new SpawnManager();
    WordManager _word = new WordManager();
    WaveManager _wave = new WaveManager();
    TypingManager _typing = new TypingManager();

    public static GameManager Game { get { return Instance._game; } }
    public static SpawnManager Spawn { get { return Instance._spawn; } }
    public static WordManager Word { get {  return Instance._word; } }
    public static WaveManager Wave { get { return Instance._wave; } }
    public static TypingManager Typing { get {  return Instance._typing; } }

    //Core
    InputManager _input = new InputManager();
    DataManager _data = new DataManager();
    PoolManager _pool = new PoolManager();
    ResourceManager _resource = new ResourceManager();
    SoundManager _sound = new SoundManager();
    MapManager _map = new MapManager();

    public static InputManager Input { get { return Instance._input; } }
    public static DataManager Data { get { return Instance._data; } }
    public static PoolManager Pool { get { return Instance._pool; } }
    public static ResourceManager Resource { get { return Instance._resource; } }
    public static SoundManager Sound { get { return Instance._sound; } }
    public static MapManager Map { get { return Instance._map; } }

    private void Start()
    {
        Init();
    }

    private void Update()
    {
        _input.OnUpdate();
    }

    static void Init()
    {
        if (s_instance == null)
        {
            GameObject go = GameObject.Find("@Object");
            if (go == null)
            {
                go = new GameObject { name = "@Object" };
                go.AddComponent<Managers>();
            }

            DontDestroyOnLoad(go);
            s_instance = go.GetComponent<Managers>();

            s_instance._data.Init();
            s_instance._pool.Init();
            s_instance._sound.Init();
        }
    }

    public static void Clear()
    {
        Input.Clear();
        Sound.Clear();
        Map.Clear();
        Pool.Clear();
    }
}