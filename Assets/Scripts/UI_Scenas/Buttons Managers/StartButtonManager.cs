using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButtonManager : MonoBehaviour
{
    public void StartButton(int scene)
    {
        ScenesManager.Instance.ChangeScene(scene);
    }
}
