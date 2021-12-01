using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public Animator anim;
    public Animator creditsAnim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void LoadGame()
    {
        StartCoroutine(LoadNextLevel());
    }

    IEnumerator LoadNextLevel()
    {
        anim.SetTrigger("Fade");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(1);
        AudioManager.instance.Play("Atmosphere");
    }

    public void Credits()
    {
        AudioManager.instance.Stop("MainMenu");
        AudioManager.instance.Play("Credits");
        creditsAnim.SetTrigger("Credits");
        Invoke("StopCredits", 123f);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void StopCredits()
    {
        AudioManager.instance.Stop("Credits");
        AudioManager.instance.Play("MainMenu");
    }
}
