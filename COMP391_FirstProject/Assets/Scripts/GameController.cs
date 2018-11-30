using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// NEW USING STATEMTNS
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
    // Create waves of hazards.
    [Header("Wave settings")]
    public GameObject hazard; // What are we spawning? //This array is gonna be of size. we have to specify.
    // public List <GameObject> hazards;    // This is less efficient, no size specified.
    public Vector2 spawn;
    public int hazardCount;     //How many hazards per wave.
    public float startWait;     // How long until the first wave?
    public float spawnWait;     // How long between each hazard in each wave?
    public float waveWait;      // How long between each wave of hazards?

    [Header("UI Settings")]
    public Text scoreText; //Reference tot he text component of ScoreTextObject UI
    public Text gameOverText; //Reference tot he text component of GameOverText UI
    public Text restartText; //Reference to the text component of RestartText UI

    [Header("Audio Settings")]
    

    // Private variables
    private int score;
    private bool gameOver;
    private bool restart;


	// Use this for initialization
	void Start () {

        score = 0;
        UpdateScore();
        gameOver = false;
        restart = false;
        StartCoroutine(SpawnWaves()); // runs a function separate from the rest of the code (in it's own thread)
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

		//Check whether you are restarting
        if(restart)
        {
            if(Input.GetKeyDown(KeyCode.R))
            {
                //Restart our game!
                //This is the old way!! DONT USE THIS
                // Application.LoadLevel("Level1");    
                // The new way, USE THIS!!
                //SceneManager.LoadScene("Level1"); // <--- Easy way of loading a specific sceness
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //Access current active scene and returns the current build number
            }
        }
	}
    // FUnction dedicated to spawning waves of hazards
    // Coroutine - Can be used to run a function on a particular time instead of waiting other functions to finish first. It keeps on running.
    IEnumerator SpawnWaves()
    {
        //Delay until first wave appears.
        yield return new WaitForSeconds(startWait); // Pause, this will "wait" for  "startWait" seconds.
        while(true)
        {
            // Spawing our hazards
            for(int i=0; i<hazardCount; i++)
            {
                Vector2 spawnPosition = new Vector2(spawn.x, Random.Range(-spawn.y, spawn.y));
                //                                     11                   -4          4
                Instantiate(hazard, spawnPosition, Quaternion.identity);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);

            if(gameOver)
            {
                // Start "Restart" squence
                //Activate the restart UI Text
                restartText.enabled = true;
                // (optional) Set restart text
                //restartText.text ="";
                //Set restart boolean value to true
                restart = true;

                // Exit out of loop
                break; //stop anymore waves to come up
            }
        }
    }
    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        //Debug.Log("Score: " + score);
        UpdateScore();

    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        // WHat happens when my game is over?
        gameOver = true;
        gameOverText.enabled = true;
    }
}
