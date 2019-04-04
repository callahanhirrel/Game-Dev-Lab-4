using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpPower;
    public LayerMask theGround;
    public Transform groundCheck;
    public float fallMultiplier;
    public float jumpMultiplier;
    private bool onTheGround = false;
    public Transform target1;
    public Transform target2;

    private Rigidbody2D rb2d;
    private Vector2 velocity;
    private bool jumping = false;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float velX = Input.GetAxis("Horizontal");
        float velY = rb2d.velocity.y;
        velocity = new Vector2(velX * speed, velY);
        onTheGround = Physics2D.Linecast(transform.position, groundCheck.position, theGround);

        if (onTheGround && Input.GetButtonDown("Jump"))
        {
            jumping = true;
        }
        if (!Input.GetButton("Jump"))
        {
            jumping = false;
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }

    private void FixedUpdate()
    {
        if (jumping)
        {
            rb2d.AddForce(Vector2.up * jumpPower);
        }
        rb2d.MovePosition(rb2d.position + velocity * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("star"))
        {
            transform.position = target1.position;
        } else if (collision.transform.CompareTag("star2"))
        {
            transform.position = target2.position;
        }
    }

}
