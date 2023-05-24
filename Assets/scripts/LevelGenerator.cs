using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelGenerator : MonoBehaviour
{
    public Vector2Int size;
    public Vector2 space;
    public GameObject brickPrefab;

    // called before the start
    private void Awake()
    {
        //nested for loops create the bricks each time the scene is loaded
        for(int i = 0; i < size.x; i++)
        {
            for(int j = 0; j < size.y; j++)
            {
                //creates a new brick 
                GameObject newBrick = Instantiate(brickPrefab, transform);
                //sets the position of the new brick starting at the centre of the screen so that it's always symetrical
                newBrick.transform.position = transform.position + new Vector3((float)((size.x-1)*.5f-i) * space.x, j * space.y, 0);
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Restart()
    {
        //un-pauses the game
        Time.timeScale = 1;
        //loads the scene causing the game to restart
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
