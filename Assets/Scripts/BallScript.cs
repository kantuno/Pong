using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public float xSpeed;
    public float ySpeed;
    public bool recentlyChanged;
    private Vector2 direction;

    // Start is called before the first frame update
    void Start()
    {
        float startingDirection = Random.Range(0f,1f);

        if( startingDirection < 0.5f ) //Start moving left
        {
            if( xSpeed > 0 )
                xSpeed *= -1;
        }
        else //Start moving right
        {
            if (xSpeed < 0)
                xSpeed *= -1;
        }

        ySpeed = 0;

        recentlyChanged = false;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = new Vector3(gameObject.transform.position.x + xSpeed, gameObject.transform.position.y + ySpeed, 1);
    }
}
