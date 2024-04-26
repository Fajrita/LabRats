using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    public GameObject pausePanel;
    public Button resumeButton;
    public Button pauseButton;

    private void Update()
    {
        if (Input.GetKeyDown("backspace") && Time.timeScale == 1.0f)
        {
            pauseButton.onClick.Invoke();
        }
    }
    public void ExitFight(int scene)
    {
        Time.timeScale = 1.0f;
        ScenesManager.Instance.ChangeScene(scene);
    }

    public void PauseButton()
    {
        pausePanel.SetActive(true);
        EventSystem.current.SetSelectedGameObject(resumeButton.gameObject);
        Time.timeScale = 0.0f;
    }

    public void ResumeButton()
    {
        pausePanel.SetActive(false);
        EventSystem.current.SetSelectedGameObject(pauseButton.gameObject);
        Time.timeScale = 1.0f;
    }
}
