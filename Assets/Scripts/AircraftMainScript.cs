using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class AircraftMainScript : MonoBehaviour
{
    public float speed;
    float firstSpeed;
    float maxSpeed = 40f;
    public float acceleration;
    public GameObject fuelText;
    public GameObject speedText;
    float fuel = 100f;

    Rigidbody2D rb;

    public float rotationControl;
    string fuelT;


    float MovY, MovX = 1;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        firstSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (speed < maxSpeed)
            {
                speed += 2;

            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (speed > 10 )
            {
                speed -= 2;

            }
        }
        MovY = Input.GetAxis("Vertical");
        fuelT = fuel.ToString("0.00");
        fuelText.GetComponent<TextMeshProUGUI>().text = "Fuel: %" + fuelT.ToString();
        speedText.GetComponent<TextMeshProUGUI>().text = "Speed: " + speed.ToString();
        if(fuel > 0)
        {
            fuel -= Time.deltaTime;

        }
        else
        {
            fuel = 0;
        }

        if (fuel == 0)
        {
            fuelText.GetComponent<TextMeshProUGUI>().text = "Game Over";
        }

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