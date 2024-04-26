using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Selector : MonoBehaviour
{
    public UIInitialRatSelector UIInitialRatSelector;
    private Sprite sprite;
    private int indexNum;
    public Image image;
    public Button ArrowLeft;
    public Button ArrowRight;
    public GameObject capsule;

    public PlayerInput playerInput;
    public bool ready;
    public Sprite selectedRat;
    public RuntimeAnimatorController selectedRatCtrl;

    private GameObject AUDIO;
    public AudioClip audioSelect;
    public AudioClip audioCapsule;

    private void Start()
    {
        AUDIO = GameObject.Find("AUDIO");
    }
    public void ArrowsPress(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            var value = (int)Math.Round(context.ReadValue<float>());
            if (value < 0) ArrowLeft.GetComponent<Image>().sprite = ArrowLeft.spriteState.pressedSprite;
            else if (value > 0) ArrowRight.GetComponent<Image>().sprite = ArrowRight.spriteState.pressedSprite;
            AUDIO.transform.GetChild(0).GetComponent<AudioSource>().PlayOneShot(audioSelect);
            ChangeIndex(value);
        }
        if (context.canceled)
        {
            ArrowLeft.GetComponent<Image>().sprite = ArrowLeft.spriteState.selectedSprite;
            ArrowRight.GetComponent<Image>().sprite = ArrowRight.spriteState.selectedSprite;
        }
    }

    public void NewPlayer()
    {
        Debug.Log("connect");
    }


    public void ChangeIndex(int number)
    {
        indexNum += number;
        if (indexNum < 0)
        {
            indexNum = UIInitialRatSelector.Sprites.Count - 1;
        }
        else if (indexNum > UIInitialRatSelector.Sprites.Count - 1)
        {
            indexNum = 0;
        }

        sprite = UIInitialRatSelector.Sprites[indexNum];
        image.sprite = sprite;

    }

    public void RatSelectedButton()
    {
        var capsuleAnim = capsule.GetComponent<Animator>();
        if (!ready)
        {
            ready = true;
            playerInput.actions["Change Selector"].Disable();
            capsuleAnim.SetTrigger("GoingDown");
            ArrowLeft.GetComponent<Image>().enabled = false;
            ArrowRight.GetComponent<Image>().enabled = false;
            selectedRat = UIInitialRatSelector.Sprites[indexNum];
            Debug.Log(selectedRat.name);
            SelectButtonManager.Instance.readyplayers++;
            selectedRatCtrl = UIInitialRatSelector.animCrontrols[indexNum];
            Debug.Log(UIInitialRatSelector.animCrontrols[indexNum]);
        }
        else if (ready)
        {
            ready = false;
            playerInput.actions["Change Selector"].Enable();
            SelectButtonManager.Instance.readyplayers--;
            capsuleAnim.SetTrigger("GoingUp");
            ArrowLeft.GetComponent<Image>().enabled = true;
            ArrowRight.GetComponent<Image>().enabled = true;
        }
    }

    public void RatSelected(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            var capsuleAnim = capsule.GetComponent<Animator>();
            if (!ready)
            {
                ready = true;
                playerInput.actions["Change Selector"].Disable();
                capsuleAnim.SetTrigger("GoingDown");
                ArrowLeft.GetComponent<Image>().enabled=false;
                ArrowRight.GetComponent<Image>().enabled = false;
                AUDIO.transform.GetChild(1).GetComponent<AudioSource>().PlayOneShot(audioCapsule);
                selectedRat = UIInitialRatSelector.Sprites[indexNum];
                Debug.Log(selectedRat.name);
                SelectButtonManager.Instance.readyplayers++;
                selectedRatCtrl = UIInitialRatSelector.animCrontrols[indexNum];
                Debug.Log(UIInitialRatSelector.animCrontrols[indexNum]);
            }
            else if (ready)
            {
                ready = false;
                playerInput.actions["Change Selector"].Enable();
                SelectButtonManager.Instance.readyplayers--;
                capsuleAnim.SetTrigger("GoingUp");
                ArrowLeft.GetComponent<Image>().enabled = true;
                ArrowRight.GetComponent<Image>().enabled = true;
                AUDIO.transform.GetChild(1).GetComponent<AudioSource>().PlayOneShot(audioCapsule);
            }
        }
    }
}
