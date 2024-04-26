using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PowerGeneratorManager : MonoBehaviour
{
    [SerializeField] GameObject[] powers;
    [SerializeField] Transform[] powerOriginalPositions;
    int time;
    float targetTime = 2f;
    void Start()
    {
       

    }

    
    void Update()
    {
       targetTime -= Time.deltaTime;
    
        
        if (targetTime <= 0) 
        {
            EnablePower();
        }

    }

    private void EnablePower()
    {
        
        int randomPosition = Random.Range(0, powers.Length);
        if (!powers[randomPosition].activeInHierarchy)
        {
            powers[randomPosition].transform.position = powerOriginalPositions[randomPosition].transform.position;
            powers[randomPosition].SetActive(true);
            targetTime = UnityEngine.Random.Range(2, 6);
        }
       
    }
}
