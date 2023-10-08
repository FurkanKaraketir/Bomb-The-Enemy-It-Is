using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMainScript : MonoBehaviour
{

    public float speed;
    public bool follow = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (follow)
        {
            transform.position = PositionSynchronizer.SharedPosition;


            if (Input.GetKeyDown(KeyCode.Space))
            {
                follow = false;

            }
        }
        else
        {
            transform.position = transform.position + (Vector3.right * (speed * Time.deltaTime));

        }




    }
}
