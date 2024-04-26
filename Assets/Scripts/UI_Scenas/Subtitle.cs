using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Subtitle : MonoBehaviour
{
    public SubTitleList subtitleList;
    

    void Start()
    {
        GetComponent<TMP_Text>().text = subtitleList.Subtitles[Random.Range(0, subtitleList.Subtitles.Length)];
    }

  
    void Update()
    {
        
    }
}
