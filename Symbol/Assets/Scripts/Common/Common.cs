using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Common : SingletonMonoBehaviour<Common>
{
    public enum GameState
    {
        Action,
        Synthesis,
        Pause,
        GameClear,
        GameOver,
    }

    /// <summary>
    /// ゲームの状態
    /// </summary>
    public GameState state;

    // Update is called once per frame
    void Update()
    {
        
    }
}
