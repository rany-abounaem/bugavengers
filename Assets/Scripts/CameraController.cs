using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Vector3 playerPosition;
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerPosition = GameManager.instance.player.transform.position;
        transform.position = new Vector3(playerPosition.x, playerPosition.y, transform.position.z);
    }
}
