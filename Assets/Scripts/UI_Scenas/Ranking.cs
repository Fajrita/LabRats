using System;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Ranking : MonoBehaviour
{
    public TMP_Text text;
    int P1;
    int P2;
    int P3;
    int P4;
    public static int winner;
    public static int[] killOrder;
    public static int[] playerRanking = new int[4];
    int[] keysBefore = new int[4];
    HashSet<int> assignedRanks = new HashSet<int>();

    private void Awake()
    {
        P1 = KillManager.playersKills[0];
        P2 = KillManager.playersKills[1];
        P3 = KillManager.playersKills[2];
        P4 = KillManager.playersKills[3];

        Dictionary<int, int> playerNames = new Dictionary<int, int>
        {
            {1, P1},
            {2, P2},
            {3, P3},
            {4, P4}
        };

        killOrder = new int[] { P1, P2, P3, P4 };
        Array.Sort(killOrder);
        Array.Reverse(killOrder);

       // int currentRank = 1;
        for (int i = 0; i < killOrder.Length; i++)
        {
            foreach (var kvp in playerNames)
            {
                if (kvp.Value == killOrder[i] && !assignedRanks.Contains(kvp.Key))
                {
                    playerRanking[i] = kvp.Key;
                    assignedRanks.Add(kvp.Key);
                    break;
                }
            }
        }

        if (P1 == killOrder[0]) winner = 1;
        else if (P2 == killOrder[0]) winner = 2;
        else if (P3 == killOrder[0]) winner = 3;
        else if (P4 == killOrder[0]) winner = 4;
    }
    void Start()
    {
        text.text = "Player" + winner + " Wins!!";
    }

}
