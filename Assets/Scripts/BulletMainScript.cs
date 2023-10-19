using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMainScript : MonoBehaviour
{

    public float speed;
    public bool follow = true;
    public GameObject plane;
    public GameObject text;
    public GameObject explosion;

    // Start is called before the first frame update
    void Start()
    {
        explosion.SetActive(false);
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        transform.Rotate(new Vector3(0, 0, 90));

    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody2D rb = plane.GetComponent<Rigidbody2D>();

        if (follow)
        {
            transform.position = plane.transform.position;


            if (Input.GetKeyDown(KeyCode.Space))
            {
                follow = false;
                float dir = Vector2.Dot(rb.velocity, rb.GetRelativeVector(Vector2.right));

                gameObject.GetComponent<Rigidbody2D>().velocity = rb.GetRelativeVector(Vector2.right) * speed;
                gameObject.GetComponent<SpriteRenderer>().enabled = true;


            }
        }
        else
        {
            transform.Rotate(new Vector3(0,0,-0.1f));
        }








    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        explosion.transform.position = transform.position;

        if (collision.gameObject.name == "Enemy")
        {
            text.SetActive(true);
            Destroy(gameObject);
            explosion.SetActive(true);
            Destroy(explosion, 1f);

        }

        if (collision.gameObject.name == "Ground")
        {
            Destroy(gameObject);
            explosion.SetActive(true);
            Destroy(explosion,1f);

        }



    }
}
