using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //value for player speed
    public float speed = 5;
    //value for the max distance allowed to travel
    public float maxDistance = 7.5f;

    float horizontalMovement;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //horizontalMovement value updated to negative value if "Left arrow" or "a" is pressed and positive value if "right arrow" or "d" is pressed
        horizontalMovement = Input.GetAxis("Horizontal");
        //checks for input going right
        //checks if the player is within the "maxDistance" movement range on the right
        //checks for input going left 
        //checks if the player is within the "maxDistance" movement range on the left
        if ((horizontalMovement>0 && transform.position.x < maxDistance) || (horizontalMovement < 0 && transform.position.x > -maxDistance))
        { 
            //player's position is updated by taking a point (Vector3.right)  multiplying it by the player input (left (-1) or right (+1)), speed of the object and Time.deltaTime which moves the object smoothly across several frames.
        transform.position += Vector3.right * horizontalMovement * speed * Time.deltaTime;
        }
    }
}
