using System.Collections;
using UnityEngine;

public class move : MonoBehaviour
{
    public float moveSpeed = 2;
    public float jumpForce;

    private Rigidbody2D rb;
    private bool facingRight = true;
    public float moveDirection;
    public bool isJumping = false;
    public float CheckRadius;
    public int maxJumpCount;
    public int jumpCount;
    public Transform groundCheck;
    public LayerMask groundObjects;
    public bool isGrounded;


    // Start is called before the first frame update
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        jumpCount = maxJumpCount;
    }
    void Update()
    {
        MoveLeftRight();
        Animate();
        Move();
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, CheckRadius, groundObjects);

        if (isGrounded)
        {
            jumpCount = maxJumpCount;
        }


    }
    private void FixedUpdate()
    {

        Jumping();
        Move();
    }
    private void Move()
    {

        //when you mouse over velocity you should have items pop up that tells you what it is asking for 

        rb.velocity = new Vector2(moveDirection * moveSpeed, rb.velocity.y);
        
        
    }
    private void Jumping()
    {
        if (isJumping)
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            jumpCount--;
            isJumping = false;
        }
    }

    private void Animate()
    {
        if (moveDirection > 0 && !facingRight)
        {
            Flipcharacter();
        }
        else if (moveDirection < 0 && facingRight)
        {
            Flipcharacter();
        }
        rb.velocity = new Vector2(moveDirection * moveSpeed, rb.velocity.y);

    }
    // Update is called once per frame


    private void MoveLeftRight()
    {
        moveDirection = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Jump") && jumpCount > 0)
        {
            isJumping = true;
        }
    }

    private void Flipcharacter()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);

    }
    IEnumerator PowerUPSpeed()
    {
        moveSpeed = 9;
        yield return new WaitForSeconds(5);
        moveSpeed = 5;
    }

    public void SpeedPowerUp()
    {
        StartCoroutine(PowerUPSpeed());
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "MovingPlatform")
        {
            transform.parent = col.transform;
        }
    }
    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "MovingPlatform")
        {
            transform.parent = null;
        }
    }

}
