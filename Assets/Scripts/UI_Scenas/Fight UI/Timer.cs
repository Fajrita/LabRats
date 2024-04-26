using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Scripting;

public class Timer : MonoBehaviour
{
    public TMP_Text text;
    private float mins;
    private float secs;
    public bool timerRunning;
    public float maxTime;
    private float timeRemaining;
    private float timeWritten;
    public Settings settings;
    public GameObject fluke;
    public GameObject time;

    private void Start()
    {
        maxTime = settings.battleTime;
        timeRemaining = maxTime;
        StartTime(maxTime);
        StartCoroutine(StartBattle());
    }
    public void StartTime(float battleTime)
    {
        maxTime = battleTime;
        mins = Mathf.FloorToInt(battleTime / 60);
        secs = Mathf.FloorToInt(battleTime % 60);
        text.text = mins + ":" + secs;
    }

    void FixedUpdate()
    {
        if (timerRunning)
        {
            timeRemaining -= Time.deltaTime;
            if (timeRemaining != timeWritten)
            {
                if (timeRemaining >= 0)
                {
                    mins = Mathf.FloorToInt(timeRemaining / 60);
                    secs = Mathf.FloorToInt(timeRemaining % 60);
                    if (timeRemaining <= 4) time.SetActive(true);
                    ChangeTime();
                }
            }
        }

        if (timeRemaining <= 0) StartCoroutine(EndBattle());
    }

    void ChangeTime()
    {
        text.text = mins + ":" + secs;
    }

    IEnumerator StartBattle()
    {
        Time.timeScale = 0.0f;
        yield return new WaitForSecondsRealtime(1);
        fluke.SetActive(true);
        yield return new WaitForSecondsRealtime(4);
        Time.timeScale = 1.0f;
        fluke.SetActive(false);
        timerRunning = true;
    }

    IEnumerator EndBattle()
    {
        Time.timeScale = 0.1f;
        yield return new WaitForSecondsRealtime(3);
        Debug.Log("terminado");
        ScenesManager.Instance.ChangeScene(5);
    }
}
