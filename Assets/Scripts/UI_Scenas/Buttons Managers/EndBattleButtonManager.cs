using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndBattleButtonManager : MonoBehaviour
{

    public Settings settings;
    public void BackButton(int scene)
    {
        if ((settings.numPlayers + settings.numNPC) >= 3) scene = 4;
        ScenesManager.Instance.ChangeScene(scene);
    }
    public void MainButton(int scene)
    {
        
        ScenesManager.Instance.ChangeScene(scene);
    }
}
