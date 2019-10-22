using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOneController : MonoBehaviour
{
    public bool movingUp;
    public bool movingDown;

    // Start is called before the first frame update
    void Start()
    {
        movingUp = false;
        movingDown = false;
    }

    // Update is called once per frame
    void Update()
    {
        if( Input.GetKey(KeyCode.W) )
        {
            gameObject.transform.position = new Vector3( transform.position.x, transform.position.y + 0.1f, transform.position.z);
            movingUp = true;
            movingDown = false;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            gameObject.transform.position = new Vector3(transform.position.x, transform.position.y - 0.1f, transform.position.z);
            movingUp = false;
            movingDown = true;
        }
        else
        {
            movingUp = false;
            movingDown = false;
        }
    }
}
