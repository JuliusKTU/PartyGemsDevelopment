using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement2 : MonoBehaviour
{
    public ParticleSystem dust;
    public GameObject victory;

    public GameObject obstacle;

    public int whichDoorIsFinish = 1;

    private Rigidbody2D myrihidBody;
    [SerializeField]
    private float speed;

    private bool facingRight;
    bool jump = false;
    public Animator animator;
    [SerializeField]
    private Transform[] groundPoints;

    [SerializeField]
    private float groundRadius;

    [SerializeField]
    private LayerMask whatIsGround;

    private bool isGround;

    private bool jumping;
    [SerializeField]
    private float jumpForce;

    // Start is called before the first frame update
    void Start()
    {
        facingRight = false;

        myrihidBody = GetComponent<Rigidbody2D>();

        whichDoorIsFinish = Random.Range(0, 4);
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal2");

        isGround = isGrounded();
        inputsHandle();

        playerMovement(horizontal);
        Flip(horizontal);
        animator.SetFloat("Speed", Mathf.Abs(horizontal));
        resetValues();

    }

    private void playerMovement(float horizontal)
    {
        myrihidBody.velocity = new Vector2(horizontal * speed, myrihidBody.velocity.y);

        if (isGround && jumping)
        {
            isGround = false;
            myrihidBody.AddForce(new Vector2(0, jumpForce));
        }
    }
    private void Flip(float horizontal)
    {
        if (horizontal > 0 && !facingRight || horizontal < 0 && facingRight)
        {
            facingRight = !facingRight;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }
    private bool isGrounded()
    {
        if (myrihidBody.velocity.y <= 0)
        {
            foreach (Transform point in groundPoints)
            {
                Collider2D[] colliders = Physics2D.OverlapCircleAll(point.position, groundRadius, whatIsGround);
                for (int i = 0; i < colliders.Length; i++)
                {
                    if (colliders[i].gameObject != gameObject)
                    {
                        return true;
                    }
                }
            }
        }
        return false;
    }
    private void inputsHandle()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            jumping = true;
        }
    }
    private void resetValues()
    {
        jumping = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (whichDoorIsFinish == 0)
        {
            if (collision.gameObject.tag == "finish1")
            {
                FinishParticles();
            }
        }
        else if (collision.gameObject.tag == "finish1")
        {
            transform.position = new Vector2(8, -3.6f);
        }
        if (whichDoorIsFinish == 1)
        {
            if (collision.gameObject.tag == "finish2")
            {
                FinishParticles();
            }
        }
        else if (collision.gameObject.tag == "finish2")
        {
            transform.position = new Vector2(8, -3.6f);
        }
        if (whichDoorIsFinish == 2)
        {
            if (collision.gameObject.tag == "finish3")
            {
                FinishParticles();
            }
        }
        else if (collision.gameObject.tag == "finish3")
        {
            transform.position = new Vector2(8, -3.6f);
        }
        if (whichDoorIsFinish == 3)
        {
            if (collision.gameObject.tag == "finish4")
            {
                FinishParticles();
            }
        }
        else if (collision.gameObject.tag == "finish4")
        {
            transform.position = new Vector2(8, -3.6f);
        }
    }
    void FinishParticles()
    {
        Destroy(gameObject);
        Instantiate(victory, transform.position, Quaternion.identity);
    }
}
