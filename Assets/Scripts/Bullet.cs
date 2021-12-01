using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.CompareTag("EnemyBullet") && collision.CompareTag ("PossessedRobot"))
        {
            collision.GetComponent<PlayerStats>().TakeDamage(damage);
        }
        else if (gameObject.CompareTag("Bullet") && collision.CompareTag("Enemy"))
        {
            collision.GetComponent<EnemyAI>().TakeDamage(damage);
        }
    }
}
