using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Define
{
    public enum WordState
    {
        None,
        Build,
        Attack,
        Skill,
        Fixed
    }

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
        Captain,
    }

    public enum WaveLevel
    {
        Easy,
        Normal,
        Hard,
        Boss,
    }

    public enum Layer
    {
        None,
        Block = 8,
        Background = 9,
        TowerInstall = 10,
        Tower = 11,
    }

    public enum Scene
    {
        Unknown,
        Lobby,
        Game,
        Loading,
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

    public enum BulletType
    {
        Enemy,
        Tower,
    }

    public enum CameraMode
    {
        QuarterView,
    }
}
