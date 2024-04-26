using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.Controls;
using Unity.VisualScripting;
using UnityEngine.Audio;
public class MainButtonManager : MonoBehaviour
{
    [Header("Main Buttons")]
    public Button playerSet;
    public Button NPCSet;
    public Button timeSet;
    [Header("Play Menu Values")]
    public int numberPlayers;
    public TMP_Text numberPlayersText;
    public int numberNPC;
    public TMP_Text numberNPCText;
    public float time;
    public TMP_Text timeText;
    public Settings settings;
    [Header("Option Menu Values")]
    public AudioMixer audioMixer;
    public Slider volumeSlider;


    private void Start()
    {
        //Play Menu Settings
        numberPlayers = settings.numPlayers;
        numberPlayersText.text = numberPlayers.ToString();
        numberNPC = settings.numNPC;
        numberNPCText.text = numberNPC.ToString();
        time = settings.battleTime;
        timeText.text = (time / 60) + ":00";

        //Option Menu Settings
        //volumeSlider.value = settings.volume;
        //Deberia esta en scene manager 
        //audioMixer.SetFloat("MasterVolume", settings.volume);
    }
    public void BackButton(int scene)
    {
        ScenesManager.Instance.ChangeScene(scene);
    }

    public void Ratopedy(int scene)
    {
        ScenesManager.Instance.ChangeScene(scene);
    }

    //Main Menu
    public void MenuButtons(GameObject panel)
    {
        if (!panel.activeSelf)
        {
            panel.SetActive(true);
            EventSystem.current.SetSelectedGameObject(panel.transform.GetChild(0).gameObject);
        }
        else
        {
            panel.SetActive(false);
            EventSystem.current.currentSelectedGameObject.GetComponent<Animator>().Play("Normal");
        }
    }


    // Play Menu
    public void SetArrows(InputAction.CallbackContext context)
    {
        if (EventSystem.current.currentSelectedGameObject.GetComponent<Button>() == playerSet)
        {
            Button left = playerSet.transform.GetChild(2).gameObject.GetComponent<Button>();
            Button right = playerSet.transform.GetChild(3).gameObject.GetComponent<Button>();
            if (context.performed)
            {
                var value = (int)Math.Round(context.ReadValue<float>());
                if (value > 0)
                {
                    right.GetComponent<Image>().sprite = right.spriteState.pressedSprite;
                    //AddNPlayerSelector();
                    right.onClick.Invoke();
                }
                if (value < 0)
                {
                    left.GetComponent<Image>().sprite = left.spriteState.pressedSprite;
                    //RestNPlayerSelector();
                    left.onClick.Invoke();
                }
            }
            if (context.canceled)
            {
                right.GetComponent<Image>().sprite = right.spriteState.selectedSprite;
                left.GetComponent<Image>().sprite = left.spriteState.selectedSprite;
            }
        }
        else
        if (EventSystem.current.currentSelectedGameObject.GetComponent<Button>() == NPCSet)
        {
            Button left = NPCSet.transform.GetChild(2).gameObject.GetComponent<Button>();
            Button right = NPCSet.transform.GetChild(3).gameObject.GetComponent<Button>();
            if (context.performed)
            {
                var value = (int)Math.Round(context.ReadValue<float>());
                if (value > 0)
                {
                    right.GetComponent<Image>().sprite = right.spriteState.pressedSprite;
                    //AddNPCButton();
                    right.onClick.Invoke();
                }
                if (value < 0)
                {
                    left.GetComponent<Image>().sprite = left.spriteState.pressedSprite;
                    //RestNPCButton();
                    left.onClick.Invoke();
                }
            }
            if (context.canceled)
            {
                right.GetComponent<Image>().sprite = right.spriteState.selectedSprite;
                left.GetComponent<Image>().sprite = left.spriteState.selectedSprite;
            }
        }
        else if (EventSystem.current.currentSelectedGameObject.GetComponent<Button>() == timeSet)
        {
            Button left = timeSet.transform.GetChild(2).gameObject.GetComponent<Button>();
            Button right = timeSet.transform.GetChild(3).gameObject.GetComponent<Button>();
            if (context.performed)
            {
                var value = (int)Math.Round(context.ReadValue<float>());
                if (value > 0)
                {
                    right.GetComponent<Image>().sprite = right.spriteState.pressedSprite;
                    //AddTimeSelector(); 
                    right.onClick.Invoke();
                }
                if (value < 0)
                {
                    left.GetComponent<Image>().sprite = left.spriteState.pressedSprite;
                    //RestTimeSelector();
                    left.onClick.Invoke();
                }
            }
            if (context.canceled)
            {
                right.GetComponent<Image>().sprite = right.spriteState.selectedSprite;
                left.GetComponent<Image>().sprite = left.spriteState.selectedSprite;
            }
        }
    }

    public void AddNPlayerSelector()
    {
        if (numberPlayers < 4)
        {
            numberPlayers += 1;
            if ((numberNPC + numberPlayers) > 4)
            {
                numberNPC--;
                numberNPCText.text = numberNPC.ToString();
            }
            numberPlayersText.text = numberPlayers.ToString();
        }
    }
    public void RestNPlayerSelector()
    {
        
        if (numberPlayers > 1)
        {
            numberPlayers -= 1;
            if ((numberNPC + numberPlayers) == 1)
            {
                numberNPC++;
                numberNPCText.text = numberNPC.ToString();
            }
            numberPlayersText.text = numberPlayers.ToString();
        }
    }
    public void AddNPCButton()
    {
        if (numberNPC < 3 && (numberNPC + numberPlayers) < 4)
        {
            numberNPC++;
            numberNPCText.text = numberNPC.ToString();
        }
    }
    public void RestNPCButton()
    {
        if (numberNPC > 0 && (numberNPC + numberPlayers) > 1)
        {
            numberNPC--;
            numberNPCText.text = numberNPC.ToString();
        }
    }
    public void FightButton()
    {
        settings.battleTime = time;
        settings.numPlayers = numberPlayers;
        settings.numNPC = numberNPC;
        ScenesManager.Instance.ChangeScene(2);
    }
    public void AddTimeSelector()
    {
        if (time < 1200)
        {
            time += 60;
            var mins = time / 60;
            timeText.text = mins.ToString() + ":00";
        }
    }
    public void RestTimeSelector()
    {
        if (time > 60)
        {
            time -= 60;
            var mins = time / 60;
            timeText.text = mins.ToString() + ":00";
        }
    }

    //Options Menu
    public void SetVolume(float volume)
    {
        var volumeType = gameObject.GetComponentInParent<RectTransform>().gameObject.name;
        audioMixer.SetFloat(volumeType, volume);
        switch(volumeType)
        {
            case "MasterVolume":
                settings.MasterVolume = volume;
                break;
            case "MusicVolume":
                settings.MusicVolume = volume;
                break;
            case "SFXVolume":
                settings.SFXVolume = volume;
                break;
        }
        
    }
}
