using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// クリスタルの情報
/// </summary>
public class CrystalInfo
{
    public enum Form
    {
        stick,
        slanting,
        Circle,
        Square,
        Triangle,
        Cross,
        brackets,
    }

    /// <summary>
    /// 記号の形
    /// </summary>
    public Form form;
    public enum Type
    {
        wood,
        Iron,
        Rock,
        other,
    }

    /// <summary>
    /// 材質
    /// </summary>
    public Type type;

    
}

public class TestRecipe : CrystalInfo
{
    private Dictionary<Form, int> recipe = new Dictionary<Form, int>
    {
        {Form.stick,0 },{Form.stick,1 },
        {Form.stick,1 },{Form.stick,0 }
    };
}