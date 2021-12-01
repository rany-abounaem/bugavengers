using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Spawn
{
    public GameObject respawnEnemy;
    public int respawnTime;
    public float timer = 0;
    public Vector3 respawnPosition;
    public bool respawning = false;
}

public class SpawnManager : MonoBehaviour
{

    public Spawn[] respawns;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Spawn respawn in respawns)
        {
            if (respawn.respawnEnemy.activeSelf && !respawn.respawning)
            {
                respawn.respawning = true;
            }
            else if (!respawn.respawnEnemy.activeSelf && respawn.respawning)
            {
                respawn.timer += Time.deltaTime;
                if (respawn.timer >= respawn.respawnTime)
                {
                    respawn.respawning = false;
                    respawn.timer = 0;
                    respawn.respawnEnemy.transform.position = respawn.respawnPosition;
                    respawn.respawnEnemy.SetActive(true);
                }
            }
        }
        
    }


}
