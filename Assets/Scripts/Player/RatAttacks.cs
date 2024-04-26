using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatAttacks : MonoBehaviour
{
    public GameObject actualBullet;
    public int actualID;
    public int damageToDeal;
    public string killerName;
    public Transform shootingPoint;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void SearchAttack(int damage, string playerName, bool isFacingRight)
    {
        switch (actualID) { 

            case 3:
                IceRatAttack(actualBullet, damage, playerName, isFacingRight);
                break;

            case 6:
                MushrromRatAttack(actualBullet, damage, playerName, isFacingRight);
                break;
            default:
                
                break;
            case 10:
                LaserRatAttack(actualBullet, damage, playerName, isFacingRight);
                break;

            case 16:
                ExtintorRatAttack(actualBullet, damage, playerName, isFacingRight);
                break;
            case 17:
                DoveRatAttack(actualBullet, damage, playerName, isFacingRight);
                break;
            case 18:
                LlamaRatAttack(actualBullet, damage, playerName, isFacingRight);
                break;
        }
       
    }

    private void LlamaRatAttack(GameObject actualBullet, int damage, string playerName, bool isFacingRight)
    {
        StartCoroutine(LlamaDelay(0.35f, actualBullet, damage, playerName, isFacingRight));
    }

    private void DoveRatAttack(GameObject actualBullet, int damage, string playerName, bool isFacingRight)
    {
        GameObject bulletClone = Instantiate(actualBullet, transform.position + new Vector3(0,-1.5f,0), transform.rotation);
        bulletClone.GetComponent<BulletData>().SetDataBulletData(damage, playerName, isFacingRight);
    }

    private void LaserRatAttack(GameObject actualBullet, int damage, string playerName, bool isFacingRight)
    {
        GameObject bulletClone = Instantiate(actualBullet, shootingPoint.transform.position, transform.rotation);
        bulletClone.GetComponent<BulletData>().SetDataBulletData(damage, playerName, isFacingRight);
    }

    private void MushrromRatAttack(GameObject actualBullet, int damage, string playerName, bool isFacingRight)
    {
        StartCoroutine(InstanceDelay(0.3f,actualBullet,damage,playerName,isFacingRight));
    }

    void IceRatAttack(GameObject actualBullet, int damage, string playerName, bool isFacingRigth)
    {
        GameObject bulletClone = Instantiate(actualBullet, shootingPoint.transform.position, transform.rotation);
        bulletClone.GetComponent<BulletData>().SetDataBulletData(damage, playerName, isFacingRigth);
        
       
    }

    void ExtintorRatAttack(GameObject actualBullet, int damage, string playerName, bool isFacingRigth)
    {
        GameObject bulletClone = Instantiate(actualBullet, shootingPoint.transform.position, transform.rotation);
        bulletClone.GetComponent<BulletData>().SetDataBulletData(damage, playerName, isFacingRigth);


    }


    IEnumerator InstanceDelay(float time, GameObject actualBullet, int damage, string playerName, bool isFacingRight)
    {
        yield return new WaitForSeconds(time);
        GameObject bulletClone1 = Instantiate(actualBullet, shootingPoint.transform.position + new Vector3(1, 0, 0), transform.rotation);
        bulletClone1.GetComponent<BulletData>().SetDataBulletData(damage, playerName, isFacingRight);
        GameObject bulletClone2 = Instantiate(actualBullet, shootingPoint.transform.position + new Vector3(-1, 0, 0), transform.rotation);
        bulletClone2.GetComponent<BulletData>().SetDataBulletData(damage, playerName, isFacingRight);
        GameObject bulletClone3 = Instantiate(actualBullet, shootingPoint.transform.position + new Vector3(0, 1, 0), transform.rotation);
        bulletClone3.GetComponent<BulletData>().SetDataBulletData(damage, playerName, isFacingRight);
    }

    IEnumerator LlamaDelay(float time, GameObject actualBullet, int damage, string playerName, bool isFacingRight)
    {
        yield return new WaitForSeconds(time);
        GameObject bulletClone1 = Instantiate(actualBullet, shootingPoint.transform.position + new Vector3(0,0.5f,0), transform.rotation);
        bulletClone1.GetComponent<BulletData>().SetDataBulletData(damage, playerName, isFacingRight);
    }

}
