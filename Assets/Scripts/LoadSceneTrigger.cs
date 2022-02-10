using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneTrigger : MonoBehaviour
{
    public int sceneId;
    public Animator anim;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //StartCoroutine(LoadLevel());
        if(collision.CompareTag("PossessedRobot"))
            LoadLevel();
    }

    void LoadLevel()
    {
        if (sceneId == 2)
        {
            AudioManager.instance.Stop("MainMenu");
            AudioManager.instance.Play("Levels");
        }
        else if (sceneId == 3)
        {
            AudioManager.instance.Stop("Levels");
            AudioManager.instance.Play("Boss");
        }
        SceneManager.LoadScene(sceneId);
        GameManager.instance.player.transform.position = new Vector3(0.5f, 0.5f, 0);
    }

    //IEnumerator LoadLevel()
    //{
    //    anim.SetTrigger("Fade");
    //    yield return new WaitForSeconds(1f);
    //    SceneManager.LoadScene(sceneId);
    //    if (sceneId == 2)
    //    {
    //        AudioManager.instance.Stop("MainMenu");
    //        AudioManager.instance.Play("Levels");
    //    }
    //    else if (sceneId == 3)
    //    {
    //        AudioManager.instance.Stop("Levels");
    //        AudioManager.instance.Play("Boss");
    //    }
    //    GameManager.instance.player.transform.position = new Vector3(0.5f, 0.5f, 0);
    //}
}
