using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public Animator anim;
    public Animator creditsAnim;
    public GameObject exitCreditsButton;
    public GameObject creditsPanel;
    public GameObject instructionsPanel;
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
        exitCreditsButton.SetActive(true);
        Invoke("StopCredits", 123f);
    }

    

    public void ExitCredits()
    {
        creditsPanel.SetActive(false);
        creditsPanel.GetComponent<CanvasGroup>().interactable = false;
        creditsPanel.GetComponent<CanvasGroup>().blocksRaycasts = false;
        exitCreditsButton.SetActive(false);
        EndCreditsTransition();
        AudioManager.instance.Stop("Credits");
        AudioManager.instance.Play("MainMenu");
    }

    public void EndCreditsTransition()
    {
        creditsAnim.SetTrigger("EndCredits");
    }

    public void OpenInstructions()
    {
        instructionsPanel.SetActive(true);
    }

    public void CloseInstructions()
    {
        instructionsPanel.SetActive(false);
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
