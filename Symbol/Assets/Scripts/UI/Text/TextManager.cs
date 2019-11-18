using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextManager : MonoBehaviour
{
    private static TextManager m_instance = null;
    public static TextManager Instance
    {
        get => m_instance;
    }

    private List<TextAnimetion> textAnimetions = new List<TextAnimetion>();

    private void Start()
    {
        textAnimetions = new List<TextAnimetion>();
    }
    private void Awake()
    {
        if(m_instance == null)
        {
            m_instance = this;
        }else
        {
            Destroy(this.gameObject);
        }
    }


    private void FixedUpdate()
    {
        TextAnimetionUpdate();
    }

    private void TextAnimetionUpdate()
    {
        float deltaTime = Time.deltaTime;
        for(int i = 0; i < textAnimetions.Count; i++)
        {
            textAnimetions[i].AnimeUpdate(deltaTime);
        }
    }

    public void AddTextAnime(TextAnimetion textAnimetion)
    {
        textAnimetions.Add(textAnimetion);

    }

    public void TextAnimeRemove(TextAnimetion textAnimetion)
    {
        textAnimetions.Remove(textAnimetion);
    }
}
