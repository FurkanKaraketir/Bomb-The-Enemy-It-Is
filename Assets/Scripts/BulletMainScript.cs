using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMainScript : MonoBehaviour
{

    public float speed;
    public bool follow = true;
    public GameObject plane;
    public GameObject text;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (follow)
        {
            transform.position = plane.transform.position;


            if (Input.GetKeyDown(KeyCode.Space))
            {
                follow = false;
                gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.right * speed;

            }
        }



        

    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.name == "Enemy")
        {
            text.SetActive(true);
        }

        if (collision.gameObject.name == "Ground")
        {
            gameObject.SetActive(false);
        }


    }
}
