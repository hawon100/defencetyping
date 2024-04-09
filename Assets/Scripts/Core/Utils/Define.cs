using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Define
{
    public enum TowerType
    {
        None,
        Center,
        Install,
    }

    public enum InstallTowerType
    {
        None,
        Common,
        Rare,
        Epic,
        Legend,
    }

    public enum Layer
    {
        None,
        Block = 8,
    }

    public enum Scene
    {
        Unknown,
        Login,
        Lobby,
        Game,
        InGame,
        TestHawon,
        TestKangmai,
    }

    public enum Sound
    {
        Bgm,
        Effect,
        MaxCount,
    }

    public enum MouseEvent
    {
        Press,
        PointerDown,
        PointerUp,
        Click,
    }

    public enum CameraMode
    {
        QuarterView,
    }
}
