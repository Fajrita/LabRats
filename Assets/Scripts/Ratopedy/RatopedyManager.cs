using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;


public class RatopedyManager : MonoBehaviour
{
    public List<RatopedyScriptable> ratsToShow;
    GameObject ratObject;
    [SerializeField] TextMeshProUGUI ratNameTxt;
    [SerializeField] TextMeshProUGUI damageTxt;
    [SerializeField] TextMeshProUGUI speedTxt;
    [SerializeField] TextMeshProUGUI jumpTxt;
    [SerializeField] TextMeshProUGUI descriptionTxt;
    [SerializeField] TextMeshProUGUI attackTxt;
    
    int iD;
    int iDmax;

    private void Start()
    {
        ratObject = transform.parent.GetChild(1).GetChild(0).gameObject;
        iDmax = ratsToShow.Count - 1;
        iD = 0;
        GetDataToShow(iD);


    }
    private void Update()
    {
        Debug.Log(ratObject.GetComponent<Image>().sprite.name);
    
    }
    private void GetDataToShow(int iD)
    {  
        string name = ratsToShow[iD].name;
        int damage = ratsToShow[iD].damage;
        float speed = ratsToShow[iD].speed;
        string jump = ratsToShow[iD].jumpForce;
        string description = ratsToShow[iD].ratDescription;
        string attackDescription = ratsToShow[iD].attackDescription;
        Sprite sprite = ratsToShow[iD].sprite;
        RuntimeAnimatorController controller = ratsToShow[iD].animator;
        UpdateUI(name,damage,speed,jump,description,attackDescription);
        ChangeAnimator(sprite,controller);
    }

    private void ChangeAnimator(Sprite sprite, RuntimeAnimatorController controller)
    {
        ratObject.GetComponent<Image>().sprite = sprite;
        ratObject.GetComponent<Image>().SetNativeSize();
       // Debug.Log(sprite.name);
       // Debug.Log(ratObject.GetComponent<Image>().sprite.name);
      //  ratObject.GetComponent<Animator>().runtimeAnimatorController = controller;
    }

    private void UpdateUI(string name, int damage, float speed, string jump, string description, string attackDescription)
    {
         ratNameTxt.text = name;
         damageTxt.text = "Damage: " + damage.ToString();
         speedTxt.text = "Speed: " + speed.ToString();
         jumpTxt.text = "Jump Force: " + jump;
         descriptionTxt.text = "Description: " + description;
         attackTxt.text = "Attack: " + attackDescription;
    }

    void ShowNewRat()
    {
               
        GetDataToShow(iD);
    }

    

    public void NextChangeRat()
    {
        iD++;
        if (iD > iDmax)
        {
            iD = 0;
        }
        Debug.Log(iD);
        ShowNewRat();
    }

    public void LastRat()
    {
        iD--;
        if (iD < 0)
        {
            iD = iDmax;
        }
        Debug.Log(iD);
        ShowNewRat();
    }
}
