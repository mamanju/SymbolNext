using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// クリスタルの情報
/// </summary>
public class CrystalInfo : MonoBehaviour
{
    [System.Serializable]
    public struct Data
    {
        /// <summary>
        /// 記号の形
        /// </summary>
        public string form;

        public enum Type
        {
            wood,
            Rock,
            Iron,
            other,
        }

        /// <summary>
        /// 材質
        /// </summary>
        public Type type;

        public Sprite icon;
        public GameObject model;
    }
    public Data data;

}