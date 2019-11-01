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

    [System.Serializable]
    public struct Data
    {
        public string crystalForm;
        public Sprite icon;
        public GameObject model;
    }

    [SerializeField]
    private Data[] PrefabData;

    public Data[] GetPrefabData { get { return PrefabData; } }

    // Update is called once per frame
    void Update()
    {
        
    }
}
