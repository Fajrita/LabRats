using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectButtonManager : MonoBehaviour
{

    public GameObject container;
    public static RuntimeAnimatorController[] playersAnimCtrls = new RuntimeAnimatorController[4];
    public static Sprite[] playerSprites = new Sprite[4];
    public Settings settings;
    public int readyplayers;
    public GameObject readyLines;

    public PlayerRats playerRats;

    public static SelectButtonManager Instance;

    private void Awake()
    {

        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this) Destroy(gameObject);
    }

    private void Update()
    {
        if (readyplayers == (settings.numPlayers + settings.numNPC))
        {
            readyLines.SetActive(true);
            EventSystem.current.SetSelectedGameObject(readyLines.transform.GetChild(3).GetChild(0).gameObject);
        }
        else readyLines.SetActive(false);
    }
    public void BackButton(int scene)
    {
        ScenesManager.Instance.ChangeScene(scene);
    }

    public void ReadyToFight(int scene)
    {
        for (int i = 0; i < container.transform.childCount; i++)
        {
            playersAnimCtrls[i] = container.transform.GetChild(i).GetComponent<Selector>().selectedRatCtrl;
            playerSprites[i] = container.transform.GetChild(i).GetComponent<Selector>().selectedRat;
            playerRats.playersRatsCtrls[i] = playersAnimCtrls[i];

        }
        if ((settings.numPlayers + settings.numNPC) >= 3) scene = 4;
        ScenesManager.Instance.ChangeScene(scene);
    }





}
