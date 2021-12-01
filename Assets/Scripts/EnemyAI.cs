using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class EnemyAI : MonoBehaviour
{
    bool faceRight = true;
    Rigidbody2D rb;
    SpriteRenderer spriteRenderer;
    public List<Transform> waypoints;
    public int currentWaypoint = 0;


    //AI Stats
    public float health,maxHealth,attackPower,level,experience;
    public Slider hpSlider;
    public UnityEvent hpUpdated;
    


    int patrolProbability, shootProbability;
    bool patrolling = false;
    public float moveSpeed = 100f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        hpUpdated.AddListener(() => UpdateHPSlider());
    }

    // Update is called once per frame
    void Update()
    {
        patrolProbability  = Random.Range(0, 100);
        shootProbability = Random.Range(0, 100);

        if (patrolProbability < 1)
        {
            patrolling = true;
        }

        if (patrolling)
        {
            rb.AddForce((waypoints[currentWaypoint].position - transform.position).normalized * Time.deltaTime * moveSpeed);

            //Switching look direction
            if (rb.velocity.x > 0 && spriteRenderer.flipX)
            {
                faceRight = true;
                spriteRenderer.flipX = false;
            }
            else if (rb.velocity.x < 0 && !spriteRenderer.flipX)
            {
                faceRight = false;
                spriteRenderer.flipX = true;
            }

            if (Vector2.Distance(waypoints[currentWaypoint].position, transform.position) < 0.5)
            {
                patrolling = false;
                if (currentWaypoint == waypoints.Capacity - 1)
                    currentWaypoint = 0;
                else
                    currentWaypoint++;
            }
        }

        
        if (((faceRight && GameManager.instance.player.transform.position.x > transform.position.x) ||
            (!faceRight && GameManager.instance.player.transform.position.x < transform.position.x))
            && (Mathf.Abs(transform.position.y - GameManager.instance.player.transform.position.y) < 0.5f))
        {
            if (shootProbability < 1)
            {
                GameObject instantiatedBullet = Instantiate(GameManager.instance.enemyBullet, transform.position, Quaternion.identity);
                instantiatedBullet.GetComponent<SpriteRenderer>().flipX = faceRight ? false : true;
                Rigidbody2D instBulletRb = instantiatedBullet.GetComponent<Rigidbody2D>();
                Bullet instBulletScript = instantiatedBullet.GetComponent<Bullet>();
                instBulletScript.damage *= attackPower;
                int forceValue = faceRight ? 1 : -1;
                instBulletRb.AddForce(new Vector2(forceValue, 0) * 200);
            }
        }
        //rb.AddForce((player.transform.position - transform.position).normalized * Time.deltaTime * moveSpeed);
    }

    public void TakeDamage(float dmg)
    {
        health -= dmg;

        if (health <= 0)
        {
            
            health = 100;
            Die();
        }

        hpUpdated.Invoke();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Animator>().SetTrigger("isPossessed");
            gameObject.SetActive(false);
            Invoke("SwitchTag", 0.5f);
            collision.GetComponent<PlayerController>().transformed = true;
        }
    }

    public void Die()
    {
        AudioManager.instance.Play("EvilRobotDeath");
        gameObject.GetComponent<Animator>().SetTrigger("Death");
        PlayerStats.instance.AddExperience(experience);
        Invoke("GoInactive", 1f);
    }

    public void GoInactive()
    {
        gameObject.SetActive(false);
    }

    public void SwitchTag()
    {
        GameManager.instance.player.tag = "PossessedRobot";
    }

    public void UpdateHPSlider()
    {
        hpSlider.value =  (health / maxHealth);
    }
}
