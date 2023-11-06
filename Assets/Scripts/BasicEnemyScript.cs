using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Bullet"))
        { 
            //call explosion
            GameObject explosion = Instantiate(Resources.Load("Explosion")) as GameObject;
            explosion.transform.position = transform.position;

            Destroy(gameObject);
        }
    }
}
