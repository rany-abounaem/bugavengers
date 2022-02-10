using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnder : MonoBehaviour
{
    public Animator creditsAnim;
    public GameObject exitCreditsButton;

    public void FinishGame()
    {
        AudioManager.instance.Stop("Boss");
        AudioManager.instance.Play("Credits");
        creditsAnim.SetTrigger("Credits");
        exitCreditsButton.SetActive(true);
        Invoke("EndGame", 123f);
    }

    public void EndGame()
    {
        AudioManager.instance.Play("MainMenu");
        AudioManager.instance.Stop("Credits");
        GameManager.instance.player.transform.position = new Vector3(0.5f, 0.5f, 0);
        SceneManager.LoadScene(0);
    }
}
