using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

[Serializable]
public class ScenesManager : MonoBehaviour
{
    public static ScenesManager Instance;
    private Animator animator;
    private AudioSource audioSource;

    private void Awake()
    {

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this) Destroy(gameObject);

        Time.timeScale = 1.0f;
        animator = transform.GetChild(0).GetComponent<Animator>();
        audioSource = transform.GetChild(0).GetComponent<AudioSource>();
    }

    public void ChangeScene(int scene)
    {
        StartCoroutine(AnimScene(scene));
    }

    IEnumerator AnimScene(int scene)
    {
        animator.SetBool("Start", false);
        audioSource.Play();
        yield return new WaitForSecondsRealtime(1f);
        Debug.Log("empiza carga de escena");
        AsyncOperation operation = SceneManager.LoadSceneAsync(scene);
        while (!operation.isDone)
        {
            Debug.Log("progress");
            Debug.Log(operation.progress);
            yield return null;
        }
        animator.SetBool("Start", true);
    }


}
