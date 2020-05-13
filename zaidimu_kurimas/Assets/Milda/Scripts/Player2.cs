using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    //velocity how fast rigid body is moving
    private Rigidbody2D playerRigidBody;
    public Animator animator;

    public ParticleSystem dust;
    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    private int extraJumps;
    public int extraJumpValue;
    public float jumpForce = 5f;
    [SerializeField]
    private float movementSpeed = 5f;
    private bool facingRight;
    private float timeLeft = 5f;


    public float maxHealth = 5000;
    public float currentHealth;
    public HealthBar healthBar;

    void Start()
    {
        facingRight = true;
        playerRigidBody = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        extraJumps = extraJumpValue;
    }

    void Update()
    {

    }
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal2");
        animator.SetFloat("Speed", Mathf.Abs(horizontal));
        HandleMovment(horizontal);
        Flip(horizontal);

        currentHealth -= (Time.deltaTime / 2);
        healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            PlayerDestroy();
        }

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        if (isGrounded == true)
        {
            extraJumps = 2;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && extraJumps > 0)
        {
            playerRigidBody.velocity = Vector2.up * jumpForce;
            extraJumps--;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) && extraJumps == 0 && isGrounded == true)
        {
            playerRigidBody.velocity = Vector2.up * jumpForce;
        }
    }
    private void HandleMovment(float horizontal)
    {
        playerRigidBody.velocity = new Vector2(horizontal * movementSpeed, playerRigidBody.velocity.y);

    }
    private void Flip(float horizontal)
    {
        if (horizontal > 0 && !facingRight || horizontal < 0 && facingRight)
        {
            facingRight = !facingRight;
            Vector2 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Chocolate")
        {
            createDust();
            Destroy(collision.gameObject);
            if (currentHealth <= 4)
            {
                currentHealth += 1;
            }
            else if (currentHealth > 4)
            {
                currentHealth = 5;
            }
        }

        if (collision.gameObject.tag == "EnergyDrink")
        {
            createDust();
            Destroy(collision.gameObject);
            if (currentHealth <= 4)
            {
                currentHealth += 1;
            }
            else if (currentHealth > 4)
            {
                currentHealth = 5;
            }
        }

        if (collision.gameObject.tag == "Coffee")
        {
            createDust();
            Destroy(collision.gameObject);
            if (currentHealth <= 4)
            {
                currentHealth += 1;
            }
            else if (currentHealth > 4)
            {
                currentHealth = 5;
            }
        }
    }


    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);

    }

    public void PlayerDestroy()
    {
        Destroy(this.gameObject);
    }

    public void createDust()
    {
        dust.Play();
    }


}

