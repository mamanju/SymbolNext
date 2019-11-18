using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextButton : MonoBehaviour
{
    private TextAnimetion textAnimetion = null;
    public void ToNext()
    {
        this.textAnimetion.NextText();
        textAnimetion = null;
        this.gameObject.SetActive(false);
    }

    public void Setcom(TextAnimetion textAnimetion)
    {
        this.textAnimetion = textAnimetion;
    }
}
