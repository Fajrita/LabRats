using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSingleton : MonoBehaviour
{
    public static MusicSingleton Instance;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this) Destroy(gameObject);

    }
    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
