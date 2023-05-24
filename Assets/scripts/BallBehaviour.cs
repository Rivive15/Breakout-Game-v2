using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BallBehaviour : MonoBehaviour
{

    public AudioSource brickSFX;
    public AudioSource ballSFX;

    public float minY = -5.5f;
    public float maxVelocity = 15f;

    Rigidbody2D rb;

    int score = 0;
    int lives = 5;
    public TextMeshProUGUI scoreText;
    //array of images representing lives
    public GameObject[] livesImage;
    public GameObject gameOverPanel;
    public GameObject victoryPanel;
    int brickCount;

    // Start is called before the first frame update
    void Start()
    {
        //creates the hitbox for the ball allowing it to interract with the physics engine
        rb = GetComponent<Rigidbody2D>();
        //counts the amount of "children" (bricks) of the LevelGenerator object at the start of the scene
        brickCount = FindObjectOfType<LevelGenerator>().transform.childCount;
        //initialising the starting velocity of the ball because the gravity scale of the object in game is set to 0 and would otherwise not move from the starting position
        rb.velocity = Vector2.down * 10f;
    }

    // Update is called once per frame
    void Update()
    {
        //checks if ball is above the bottom of the screen
        if (transform.position.y < minY)
        {
            //game over condition
            if(lives <= 0)
            {
                GameOver();
            }
            //resets the ball to the starting position if it crosses the bottom of the screen
            else
            {
                //resets the ball back to its starting position
                transform.position = Vector3.zero;
                //resets the ball's velocity 
                rb.velocity = Vector2.down * 10f;
                lives--;
                //removes one image representing the lives
                livesImage[lives].SetActive(false);
            }
        }
        //limits the speed of the ball so it doesn't cause any glitches like phasing through the bricks and platform
        if(rb.velocity.magnitude > maxVelocity)
        {
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxVelocity);
        }
    }
    //checking collisions
    private void OnCollisionEnter2D(Collision2D collision)
    { 
    //checking collisions with bricks
        if(collision.gameObject.CompareTag("Brick"))
        {
            //plays brick sfx
            brickSFX.Play();
            //destroys brick if collided with
            Destroy(collision.gameObject);
            //updates score in incriments of 10
            score += 10;
            scoreText.text = score.ToString("00000");
            //removes 1 brick from the brickCount
            brickCount--;
            //checks if there's any bricks left
            if (brickCount <= 0)
            {
                //pulls up victory panel
                victoryPanel.SetActive(true);
                //pauses the game 
                Time.timeScale = 0;
                //destroys the ball
                Destroy(gameObject);
            }
            
        }
        //checks collision with wall or platform 
        else if (collision.gameObject.tag == "CollisionTag")
        {
         //plays ball sfx
             ballSFX.Play();
        }
    }
    //game over function
    void GameOver()
    {
        //pulls up the game over panel
        gameOverPanel.SetActive(true);
        //pauses the game 
        Time.timeScale = 0;
        //destroys the ball
        Destroy(gameObject);
    }
}
