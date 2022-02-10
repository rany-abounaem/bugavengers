using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject player;
    public Vector3 respawnPosition = new Vector3(0.5f, 0.5f, 0);
    public GameObject evilRobot;
    public GameObject enemyBullet;
    public bool inputEnabled = false;

    void Awake()
    {
        if (instance==null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnableInputs()
    {
        inputEnabled = true;
    }

    

    //public IEnumerator Respawn()
    //{
    //    player.SetActive(false);
    //    yield return new WaitForSeconds(2f);
    //    player.transform.position = respawnPosition;
    //    player.tag = "Player";
    //    player.GetComponent<PlayerController>().transformed = false;
    //    player.SetActive(true);
    //}
}
