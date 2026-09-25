using System.Collections;
using System.Threading.Tasks;
using Unity.AppUI.UI;
using UnityEngine;


public class BallController : MonoBehaviour
{
    public Rigidbody2D rigidBody;
    public float startSpeed = 8f;
    public Manager gameManager;

    public GameObject goalLeft;
    public GameObject goalRight;

    public AudioSource audioSource;
    public AudioClip bounceSound;
    public AudioClip scoreSound;

    public Rigidbody2D L_paddleBody;
    public Rigidbody2D R_paddleBody;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartBall();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void StartBall()
    {
        bool right = Random.value >= 0.5f;

        float xVelocity = right ? 1f : -1f;
        float yVelocity = Random.Range(-1f, 1f);

        rigidBody.linearVelocity = new Vector2(xVelocity, yVelocity).normalized * startSpeed;



        rigidBody.linearVelocity = new Vector2(xVelocity * startSpeed, yVelocity * startSpeed);
    }

    public void ResetBall()
    {
        rigidBody.linearVelocity = Vector2.zero; // stop bewegen
        transform.position = Vector3.zero; // terug naar 0,0,0 plaatsen
        StartCoroutine(DelayedStart());
    }

    private IEnumerator DelayedStart()
    {
        yield return new WaitForSeconds(0.5f);
        StartBall();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == goalRight)
        {
            gameManager.ScoreLeft();
            audioSource.PlayOneShot(scoreSound);
            ResetBall();
        }
        else if (collision.gameObject == goalLeft)
        {
            gameManager.ScoreRight();
            audioSource.PlayOneShot(scoreSound);
            ResetBall();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.rigidbody == L_paddleBody)
        {
            audioSource.PlayOneShot(bounceSound);
        }
        else if (collision.rigidbody == R_paddleBody)
        {
            audioSource.PlayOneShot(bounceSound);
        }
    }
}
