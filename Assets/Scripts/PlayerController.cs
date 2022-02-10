using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//enum MoveDirection { UP, DOWN, LEFT, RIGHT };

public class PlayerController : MonoBehaviour
{
    
    public bool faceRight;
    public bool transformed = false;
    public float moveSpeed;
    public GameObject bullet;
    public float bulletDelay = 0.16f;
    public Vector3 respawnPosition = new Vector3(0.5f, 0.5f, 0);

    Rigidbody2D rb;
    SpriteRenderer spriteRenderer;
    Animator anim;
    

    float horizontalAxisInput, verticalAxisInput;
    //MoveDirection moveDirection = MoveDirection.UP;
    bool moveRight, moveDown, moveLeft, moveUp = false;
    // Start is called before the first frame update
    void Start()
    {
        faceRight = true;
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalAxisInput = Input.GetAxisRaw("Horizontal");
        verticalAxisInput = Input.GetAxisRaw("Vertical");
        moveRight = false;
        moveDown = false;
        moveUp = false;
        moveLeft = false;

        if (GameManager.instance.inputEnabled)
        {
            moveRight = horizontalAxisInput > 0 ? true : false;
            moveDown = verticalAxisInput < 0 ? true : false;
            moveUp = verticalAxisInput > 0 ? true : false;
            moveLeft = horizontalAxisInput < 0 ? true : false;

            if (Input.GetKey(KeyCode.Space) && bulletDelay <= 0 && transformed)
            {
                anim.SetTrigger("isShooting");
                AudioManager.instance.Play("Bullet");
                GameObject instantiatedBullet = Instantiate(bullet, transform.position, Quaternion.identity);
                instantiatedBullet.GetComponent<SpriteRenderer>().flipX = faceRight ? false : true;
                Rigidbody2D instBulletRb = instantiatedBullet.GetComponent<Rigidbody2D>();
                Bullet instBulletScript = instantiatedBullet.GetComponent<Bullet>();
                instBulletScript.damage *= PlayerStats.instance.attackPower;
                int forceValue = faceRight ? 1 : -1;
                instBulletRb.AddForce(new Vector2(forceValue, 0) * 300);
                bulletDelay = 0.16f;
            }
        }
        
        if (bulletDelay > 0)
            bulletDelay -= Time.deltaTime;
    }

    private void FixedUpdate()
    {
        if (moveRight)
        {
            faceRight = true;
            rb.AddForce(new Vector2(1, 0) * moveSpeed * Time.deltaTime);
            if (spriteRenderer.flipX)
                spriteRenderer.flipX = false;
        }
        else if (moveLeft)
        {
            faceRight = false;
            rb.AddForce(new Vector2(-1, 0) * moveSpeed * Time.deltaTime);
            if (!spriteRenderer.flipX)
                spriteRenderer.flipX = true;
        }
        if (moveUp)
            rb.AddForce(new Vector2(0, 1) * moveSpeed * Time.deltaTime);
        else if (moveDown)
            rb.AddForce(new Vector2(0, -1) * moveSpeed * Time.deltaTime);

        if (moveUp || moveDown || moveLeft || moveRight)
            anim.SetBool("isRunning", true);
        else
            anim.SetBool("isRunning", false);

    }

    

    public void PlayFootsteps()
    {
        AudioManager.instance.Play("Footsteps");
    }



    //void SwitchDirection()
    //{
    //    Vector2 transformLocalScale = transform.localScale;
    //    transform.localScale = new Vector2(-transformLocalScale.x, transformLocalScale.y);
    //}
}
