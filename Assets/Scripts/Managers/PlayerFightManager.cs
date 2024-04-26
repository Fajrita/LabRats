using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerFightManager : MonoBehaviour
{
    public Settings settings;
    public PlayerRats PlayerRats;
    public PlayerInputManager playerInputManager;
    public PlayerInput[] playerInput = new PlayerInput[4];
    public GameObject NPC;
    public GameObject[] playerNPC = new GameObject[4];
    public GameObject[] spawnPoint = new GameObject[4];
    private int usedSpawn;
    void Awake()
    {
        for (int i = 0; i < settings.numPlayers; i++)
        {
            
            playerInput[i] = playerInputManager.JoinPlayer(i, -1, "Player" + (i + 1), Keyboard.current);
            playerInput[i].gameObject.name = "Player0" + (i + 1);
            playerInput[i].gameObject.transform.position = spawnPoint[i].transform.position;
            playerInput[i].gameObject.transform.GetChild(0).GetComponent<Animator>().runtimeAnimatorController =
                SelectButtonManager.playersAnimCtrls[i];
            playerInput[i].gameObject.transform.GetChild(1).GetChild(0).GetComponent<Image>().sprite
                = PlayerRats.playerFollow[i];
            usedSpawn++;

            Debug.Log(i + 1);
        }

        for (int i = 0; i < settings.numNPC; i++)
        {
            playerNPC[i] = Instantiate(NPC, spawnPoint[usedSpawn + i].transform.position, Quaternion.identity);
            playerNPC[i].gameObject.name = "Player0" + (i + settings.numPlayers + 1);
            playerNPC[i].gameObject.transform.GetChild(0).GetComponent<Animator>().runtimeAnimatorController =
                SelectButtonManager.playersAnimCtrls[i + settings.numPlayers];
            playerNPC[i].gameObject.transform.GetChild(1).GetChild(0).GetComponent<Image>().sprite
                = PlayerRats.playerFollow[i + settings.numPlayers];

        }
    }
}
