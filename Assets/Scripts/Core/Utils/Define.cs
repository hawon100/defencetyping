using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Define
{
    public enum CurrentStage
    {
        None = -1,
        Battle_of_Okpo = 0,
        Battle_of_Happo = 1,
        Battle_of_Jukjinpo = 2,
        Battle_of_Sacheon,
        Battle_of_Dangpo,
        Battle_of_Danghangpo,
        Battle_of_Yulpo,
        Battle_of_Hansan_Island,
        Battle_of_Angolpo,
        Battle_of_Busan,
        Battle_of_Ungpo,
        Battle_of_Jangmunpo,
        Battle_of_Chilcheollyang,
        Battle_of_Myeongnyang,
        Battle_of_Jeolyi_Island,
        Battle_of_Noryang,
        EndLine,
    }

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

    public enum CameraMode
    {
        QuarterView,
    }
}
