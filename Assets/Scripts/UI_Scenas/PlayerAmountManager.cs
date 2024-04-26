using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerAmountManager : MonoBehaviour
{
    public Settings settings;
    public PlayerInputManager playerInputManager;
    public PlayerInput[] playerInput = new PlayerInput[4];
    private GameObject[] npcSelectors = new GameObject[3];
    public GameObject content;
    public GameObject npcSelector;
    public GameObject[] spawnPoint = new GameObject[4];
    private int usedSpawn;
    void Start()
    {
        ContentSize();
        for (int i = 0; i < settings.numPlayers; i++)
        {
            playerInput[i] = playerInputManager.JoinPlayer(i, -1, "Player" + (i + 1), Keyboard.current);
            playerInput[i].gameObject.name = "Player" + (i + 1);
            playerInput[i].gameObject.transform.SetParent(content.transform, false);
            playerInput[i].gameObject.transform.Find("ArrowLeft").GetComponent<Button>().enabled = false;
            playerInput[i].gameObject.transform.Find("ArrowRight").GetComponent<Button>().enabled = false;
            playerInput[i].gameObject.transform.Find("NameTag").GetChild(0).GetComponent<TMP_Text>().text
                = "Player " + (i + 1);
            playerInput[i].gameObject.transform.Find("SelectButtonT").GetComponent<TMP_Text>().text
                = "Select: " + playerInput[i].actions.FindAction("ButtonSelect").controls[0].name;
            playerInput[i].gameObject.transform.Find("MoveButtonT").GetComponent<TMP_Text>().text
            = "Move: " + playerInput[i].actions.FindAction("Change Selector").controls[0].name
                + " / " + playerInput[i].actions.FindAction("Change Selector").controls[1].name;

        }

        for (int i = 0; i < settings.numNPC; i++)
        {
            npcSelectors[i] = Instantiate(npcSelector, content.transform, false);
            npcSelectors[i].GetComponent<PlayerInput>().enabled = false;
            npcSelectors[i].name = "NPC" + (settings.numPlayers + i + 1);
            npcSelectors[i].transform.Find("NameTag").GetChild(0).GetComponent<TMP_Text>().text
                = "NPC " + (settings.numPlayers + i + 1);
            npcSelectors[i].gameObject.transform.Find("SelectButtonT").GetComponent<TMP_Text>().text
                = "Click NPC Tag";

        }
    }

    void ContentSize()
    {
        switch (settings.numPlayers + settings.numNPC)
        {
            case 2:
                content.GetComponent<GridLayoutGroup>().spacing = new Vector2(300, 50);
                npcSelector.transform.localScale = new Vector2(1, 1);
                break;
            case 3:
                content.GetComponent<GridLayoutGroup>().spacing = new Vector2(100, 50);
                npcSelector.transform.localScale = new Vector2(0.9f, 0.9f);
                break;
            case 4:
                content.GetComponent<GridLayoutGroup>().spacing = new Vector2(5, 50);
                npcSelector.transform.localScale = new Vector2(0.9f, 0.9f);
                break;
        }
    }
}
