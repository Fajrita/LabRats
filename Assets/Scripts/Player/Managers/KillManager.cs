using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KillManager : MonoBehaviour
{
    private GameObject[] playersCount = new GameObject[4];
    public static int[] playersKills = new int[4];
  //  GameObject player01Count;
  //GameObject player02Count;
  //  GameObject player03Count;
  //  GameObject player04Count;
    //public static int player01Kills;
    //public static int player02Kills;
    //public static int player03Kills;
    //public static int player04Kills;

    public Settings settings;

    void Start()
    {
        for (int i = 0; i < settings.numNPC + settings.numPlayers; i++) {

            playersCount[i] = GameObject.Find("P" +(i+1)).gameObject.transform.GetChild(2).GetChild(1).GetChild(0).gameObject;
            playersKills[i] = 0;
        }
        //player01Count = GameObject.Find("P1").gameObject.transform.GetChild(2).GetChild(1).GetChild(0).gameObject;
        //player02Count = GameObject.Find("P2").gameObject.transform.GetChild(2).GetChild(1).GetChild(0).gameObject;
        //player03Count = GameObject.Find("P3").gameObject.transform.GetChild(2).GetChild(1).GetChild(0).gameObject;
        //player04Count = GameObject.Find("P4").gameObject.transform.GetChild(2).GetChild(1).GetChild(0).gameObject;


        //player01Kills = 0;
        //player02Kills = 0;
        //player03Kills = 0;
        //player04Kills = 0;
        //ShowKill();
    }

    public void AddKill(string iD)
    {
        switch (iD) {

            case "Player01":
                playersKills[0]++;
                ShowKill(0);
                break;

            case "Player02":
                playersKills[1]++;
                ShowKill(1);
                break;

            case "Player03":
                playersKills[2]++;
                ShowKill(2);
                break;

            case "Player04":
                playersKills[3]++;
                ShowKill(3);
                break;

            default:

                    break;
        
        }
    }

    void ShowKill(int i)
    {
        playersCount[i].GetComponent<TextMeshProUGUI>().text = Convert.ToString(playersKills[i]);
        //player01Count.GetComponent<TextMeshProUGUI>().text = Convert.ToString(player01Kills);
        //player02Count.GetComponent<TextMeshProUGUI>().text = Convert.ToString(player02Kills);
        //player03Count.GetComponent<TextMeshProUGUI>().text = Convert.ToString(player03Kills);
        //player04Count.GetComponent<TextMeshProUGUI>().text = Convert.ToString(player04Kills);
    }
}
