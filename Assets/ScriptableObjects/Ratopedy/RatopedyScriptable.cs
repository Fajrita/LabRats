using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

[CreateAssetMenu(fileName = "new RatToShow", menuName = "Ratopedy Rats")]
public class RatopedyScriptable : ScriptableObject
{
    
    public string name;
    public int damage;
    public string jumpForce;
    public float speed;
    [TextArea(2,6)]
    public string ratDescription;
    [TextArea(2, 6)]
    public string attackDescription;
    public RuntimeAnimatorController animator;
    public Sprite sprite;

}

