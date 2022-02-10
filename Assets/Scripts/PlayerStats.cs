using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{

    public static PlayerStats instance;

    public UnityEvent hpUpdated, maxHpUpdated, levelUpdated, expUpdated;

    public float health = 100, maxHealth = 100, attackPower = 1, level = 1, experience = 0;

    void Awake()
    {
        if (instance == null)
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

    public void AddExperience(float value)
    {
        experience += value;
        expUpdated.Invoke();
        if (experience >= Mathf.RoundToInt(200 * Mathf.Log10(level) + 100))

        {
            LevelUp();
        }
    }

    public void RemoveExperience(float value)
    {
        experience -= value;
        if (experience < 0)
        {
            experience = 0;
        }
        expUpdated.Invoke();
        //level 2 exp 100, current lvl 1 exp 0
        if (level == 1)
            return;
        if (experience < Mathf.RoundToInt(200 * Mathf.Log10(level - 1) + 100))
        {
            LevelDown();
        }
    }

    public void LevelUp()
    {
        level++;
        levelUpdated.Invoke();
        attackPower = Mathf.RoundToInt(10 * Mathf.Log10(level) + 1);
        maxHealth = Mathf.RoundToInt(50 * Mathf.Log10(level) + 100);
        health = maxHealth;
    }

    public void LevelDown()
    {
        level--;
        levelUpdated.Invoke();
        attackPower = Mathf.RoundToInt(20 * Mathf.Log10(level) + 1);
        maxHealth = Mathf.RoundToInt(50 * Mathf.Log10(level) + 100);
        health = maxHealth;
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("Enemy") && gameObject.tag == "PossessedRobot")
    //    {
    //        Die();
    //    }
    //}

    public void Die()
    {
        //gameObject.SetActive(false);
        gameObject.transform.position = new Vector3(0.5f, 0.5f, 0);
        health = maxHealth;
        RemoveExperience(10);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    
}
