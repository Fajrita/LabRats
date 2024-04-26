using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerRats", menuName = "UI/PlayerRats")]
public class PlayerRats : ScriptableObject
{
    public Sprite[] playersRats = new Sprite[4];
    public RuntimeAnimatorController[] playersRatsCtrls = new RuntimeAnimatorController[4];
    public Sprite[] playerColor = new Sprite[4];
    public Sprite[] playerKillColor = new Sprite[4];
    public Sprite[] playerFollow = new Sprite[4];
}
