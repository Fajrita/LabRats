using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class LasersManager : MonoBehaviour
{

    [SerializeField] GameObject laserX;
    [SerializeField] GameObject laserY;
    [SerializeField] Transform laserXSpawn;
    [SerializeField] Transform laserYSpawn;
    [SerializeField] float targetTime = 10f;
    void Start()
    {
        
    }
    void Update()
    {
        targetTime -= Time.deltaTime;

        if (targetTime <= 0)
        {
            MoveLaser();
        }

        if (laserX.transform.position.x > 20f)
        {
            laserX.SetActive(false);
        }

        if (laserY.transform.position.x > 20f)
        {
            laserY.SetActive(false);
        }
    }

    private void MoveLaser()
    {
        int laser = Random.Range(0, 2);
        if (laser == 0)
        {
             laserX.transform.position = laserXSpawn.transform.position;
             laserX.SetActive(true);
             targetTime = Random.Range(10, 25);
        }

        if (laser == 1)
        {
            laserY.transform.position = laserYSpawn.transform.position;
            laserY.SetActive(true);
            targetTime = Random.Range(10, 25);
        }
    }

   
}
