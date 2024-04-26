using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "new UIInitialRatSelector", menuName = "UI/UIInitialRatSelector")]
public class UIInitialRatSelector : ScriptableObject
{

    public List<Sprite> Sprites;
    public List<RuntimeAnimatorController> animCrontrols;
    public List<Sprite> WinnerSprites;
}


