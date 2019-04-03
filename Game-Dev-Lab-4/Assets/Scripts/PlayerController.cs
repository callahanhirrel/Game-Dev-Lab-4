using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 7;
    private Rigidbody2D rb2d;
    private Vector2 velocity;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float input = Input.GetAxis("Horizontal");
        velocity = new Vector2(input * speed, rb2d.velocity.y);
    }

    private void FixedUpdate()
    {
        rb2d.MovePosition(rb2d.position + velocity * Time.deltaTime);
    }
}
