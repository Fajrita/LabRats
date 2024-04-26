using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class WinnerAmountManager : MonoBehaviour
{
    public Settings settings;
    public GameObject winnerPodio;
    public RectTransform content;
    public GameObject podio;
    private GameObject winner;

    public UIInitialRatSelector UIInitialRatSelector;

    public PlayerRats PlayerRats;
    public Sprite[] place = new Sprite[3];

    private Vector3 pos = new Vector3(-8.4f, -7.2f, 1);
    private Vector3 varPos = new Vector3(3.3f, -1.2f, 0);

    private void Awake()
    {
        Time.timeScale = 1.0f;
        ContentSize();

        

        
    }
    void Start()
    {
        var winnerSprite = PlayerRats.playersRats[Ranking.playerRanking[0] - 1];
        var winnerAnim = PlayerRats.playersRatsCtrls[Ranking.playerRanking[0] - 1];
        winnerPodio.transform.GetChild(1).gameObject.GetComponent<Image>().sprite =
            winnerSprite;
        winnerPodio.transform.GetChild(1).gameObject.GetComponent<Animator>().runtimeAnimatorController =
            winnerAnim;
        winner = Instantiate(winnerPodio, pos,  Quaternion.identity, content);

        for (int i = 0; i < (settings.numPlayers + settings.numNPC) - 1; i++)
        {
            var nextSprite = PlayerRats.playersRats[Ranking.playerRanking[i + 1] - 1];
            pos += varPos;
            podio.transform.GetChild(1).gameObject.GetComponent<Image>().sprite =
            nextSprite;
            podio.transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = place[i];
            podio.transform.GetChild(0).GetChild(0).GetComponent<Image>().SetNativeSize();
            Instantiate(podio, pos, Quaternion.identity, content);

        }
        winner.transform.GetChild(1).gameObject.GetComponent<Animator>().SetTrigger("Win");



    }
    void ContentSize()
    {
        switch (settings.numPlayers + settings.numNPC)
        {
            case 2:
                pos = new Vector3(-3.3f, -7.8f, 1);
                varPos += new Vector3(0, -1f, 0);
                break;
            case 3:
                pos = new Vector3(-6f, -7.6f, 1);
                varPos += new Vector3(0, -0.3f, 0);
                break;
            case 4:
                content.position  += new Vector3(0, 0, 0);
                break;
        }
    }
}
