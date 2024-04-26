using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="new Settings", menuName= "UI/Settings")]
public class Settings : ScriptableObject
{
    public int numPlayers;
    public int numNPC;
    public float battleTime;

    public float MasterVolume;
    public float MusicVolume;
    public float SFXVolume;
}
