using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AircraftMainScript : MonoBehaviour
{
    public float speed;
    public float acceleration;

    Rigidbody2D rb;

    public float rotationControl;


    float MovY, MovX = 1;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        MovY = Input.GetAxis("Vertical");

    }

    private void FixedUpdate()
    {
        Vector2 Vel = transform.right * (MovX * acceleration);

        rb.AddForce(Vel);
        float dir = Vector2.Dot(rb.velocity, rb.GetRelativeVector(Vector2.right));

        if (acceleration > 0)
        {
            if (dir > 0)
            {
                rb.rotation += MovY * rotationControl * (rb.velocity.magnitude / speed);
            }
            else
            {
                rb.rotation -= MovY * rotationControl * (rb.velocity.magnitude / speed);

            }
        }

        float thrustForce = Vector2.Dot(rb.velocity, rb.GetRelativeVector(Vector2.down)) * 2.0f;

        Vector2 relForce = Vector2.up * thrustForce;

        rb.AddForce(rb.GetRelativeVector(relForce));


        if (rb.velocity.magnitude > speed)
        {
            rb.velocity = rb.velocity.normalized * speed;
        }


    }
}