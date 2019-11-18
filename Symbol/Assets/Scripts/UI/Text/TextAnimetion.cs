using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextAnimetion : MonoBehaviour
{
    [SerializeField] private string[] setDisplayTexts;
    [SerializeField] private float displayInterval;
    [SerializeField] private TextButton nextButton = null;
    [SerializeField] Text text = null;

    private float timer = 0;
    private int textCount = 0;
    private int setDisplayTextsCount = 0;
    private bool m_AnimeStop = false;
    void Start()
    {
        TextManager.Instance.AddTextAnime(this);
    }

    public void Init()
    {
        //text = this.gameObject.GetComponent<Text>();
        nextButton.gameObject.SetActive(false);
        m_AnimeStop = false;
        timer = 0;
        textCount = 0;
        setDisplayTextsCount = 0;
    }

    public void AnimeUpdate(float Time)
    {
        if (m_AnimeStop) { return; }
        timer += Time;
        if (timer < displayInterval) { return; }

        string displayText = null;
        for (int i = 0; i < textCount; i++)
        {
            displayText += setDisplayTexts[setDisplayTextsCount][i];
        }
        text.text = displayText;

        textCount++;
        timer = 0;
        if (setDisplayTexts[setDisplayTextsCount].Length + 1 > textCount) { return; }
        nextButton.gameObject.SetActive(true);
        nextButton.Setcom(this);
        m_AnimeStop = true ;

    }

    public void NextText()
    {
        m_AnimeStop = false;
        textCount = 0;
        setDisplayTextsCount++;
        if (setDisplayTexts.Length > setDisplayTextsCount) { return; }
        TextManager.Instance.TextAnimeRemove(this);
    }
}
