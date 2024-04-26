using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    public PlayerRats PlayerRats;
    public Settings settings;
    public GameObject PlayerUIPack;
    public GameObject[] UIs = new GameObject[4];

    private void Awake()
    {
        for (int i = 0; i < settings.numPlayers + settings.numNPC; i++)
        {
            UIs[i] = Instantiate(PlayerUIPack, transform, false);
            UIs[i].name = "P" + (i+1);
            UIs[i].transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<Image>().sprite
                = SelectButtonManager.playerSprites[i];
            UIs[i].transform.GetChild(1).GetChild(0).GetComponent<Image>().sprite
                = PlayerRats.playerColor[i];
            UIs[i].transform.GetChild(1).GetChild(1).GetComponent<TMP_Text>().text
                = "Player " + (i + 1);
            UIs[i].transform.GetChild(2).GetChild(1).GetComponent<Image>().sprite
                = PlayerRats.playerKillColor[i];
            PlayerRats.playersRats[i] = SelectButtonManager.playerSprites[i];
        }
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
