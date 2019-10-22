using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MasterScript : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    public GameObject player1ScoreZone;
    public GameObject player2ScoreZone;
    public GameObject topWall;
    public GameObject bottomWall;
    public GameObject ballPrefab;
    private GameObject ball;
    private int playerOneScore;
    private int playerTwoScore;

    // Start is called before the first frame update
    void Start()
    {
        ball = Instantiate(ballPrefab, new Vector3(0, 0, 1), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        //If the ball touches the left paddle
        if( ball && !ball.GetComponent<BallScript>().recentlyChanged && player1.GetComponent<BoxCollider>().bounds.Intersects(ball.GetComponent<SphereCollider>().bounds) )
        {
            player1.GetComponent<AudioSource>().Play(0);

            ball.GetComponent<BallScript>().xSpeed *= -1;
            ball.GetComponent<BallScript>().recentlyChanged = true;

            if (player1.GetComponent<PlayerOneController>().movingUp)
                ball.GetComponent<BallScript>().ySpeed = 0.15f;

            if (player1.GetComponent<PlayerOneController>().movingDown)
                ball.GetComponent<BallScript>().ySpeed = -0.15f;

            StartCoroutine(changedTimer());
        }

        //If the ball touches the right paddle
        if ( ball && !ball.GetComponent<BallScript>().recentlyChanged && player2.GetComponent<BoxCollider>().bounds.Intersects(ball.GetComponent<SphereCollider>().bounds) )
        {
            player2.GetComponent<AudioSource>().Play(0);

            ball.GetComponent<BallScript>().xSpeed *= -1;
            ball.GetComponent<BallScript>().recentlyChanged = true;

            if( player2.GetComponent<PlayerTwoController>().movingUp)
                ball.GetComponent<BallScript>().ySpeed = 0.15f;

            if (player2.GetComponent<PlayerTwoController>().movingDown)
                ball.GetComponent<BallScript>().ySpeed = -0.15f;

            StartCoroutine(changedTimer());
        }

        //If the ball touches the left score zone
        if (ball && player1ScoreZone.GetComponent<BoxCollider>().bounds.Intersects(ball.GetComponent<SphereCollider>().bounds))
        {
            playerOneScore++;
            StartCoroutine(score());
        }

        //If the ball touches the right score zone
        if (ball && player2ScoreZone.GetComponent<BoxCollider>().bounds.Intersects(ball.GetComponent<SphereCollider>().bounds))
        {
            playerTwoScore++;
            StartCoroutine(score());
        }

        //If the ball touches the walls
        if (ball && !ball.GetComponent<BallScript>().recentlyChanged && topWall.GetComponent<BoxCollider>().bounds.Intersects(ball.GetComponent<SphereCollider>().bounds) || ball && !ball.GetComponent<BallScript>().recentlyChanged && bottomWall.GetComponent<BoxCollider>().bounds.Intersects(ball.GetComponent<SphereCollider>().bounds))
        {
            ball.GetComponent<BallScript>().ySpeed *= -1;
            ball.GetComponent<BallScript>().recentlyChanged = true;

            StartCoroutine(changedTimer());
        }
    }

    IEnumerator changedTimer()
    {
        yield return new WaitForSeconds(0.1f);

        if( ball )
            ball.GetComponent<BallScript>().recentlyChanged = false;
    }

    IEnumerator score()
    {
        gameObject.GetComponent<AudioSource>().Play(0);
        Destroy(ball);
        ball = null;
        GameObject.Find("ScoreText").GetComponent<Text>().text = playerOneScore.ToString() + " - " + playerTwoScore.ToString();
        yield return new WaitForSeconds(3f);
        GameObject.Find("ScoreText").GetComponent<Text>().text = "";
        ball = Instantiate(ballPrefab, new Vector3(0, 0, 1), Quaternion.identity);
    }
}
