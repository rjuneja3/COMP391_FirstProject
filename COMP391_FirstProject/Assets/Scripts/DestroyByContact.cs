using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {

	public GameObject explosionAsteroid;
    public GameObject explosionPlayer;
    public int scoreValue = 10;
    private GameController gameControllerScript;
	void Start () {
        GameObject gameControllerObject= GameObject.FindWithTag("GameController");
        if(gameControllerObject != null)
        {
            gameControllerScript=gameControllerObject.GetComponent<GameController>();
        }
        if(gameControllerObject==null)
        {
            Debug.Log("Cannot find gameController script on GameController Object");
        }
	}
    private void Awake()
    {
        
    }

    // This trigger will run code when another object with a collider where is trigger? boolean is set to true.
    // and collides with this object
    void OnTriggerEnter2D(Collider2D other)
    {
        // Ignore the boundary collider
        if(other.tag =="boundary")
        {
        
            return;
            //
        }
        if (other.tag == "Player")
        {
            Instantiate(explosionPlayer, other.transform.position, other.transform.rotation);
            // Trigger gameOver logic
            gameControllerScript.GameOver(); //calls gameOver function in the GameController Script

        }
        // Create the asteroid explosion
        Instantiate(explosionAsteroid, this.transform.position, this.transform.rotation);
        gameControllerScript.AddScore(scoreValue);
        Destroy(other.gameObject);
        Destroy(this.gameObject);
    }

  
}
