using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour {

	public AudioClip destroy;
	public GameObject smallAsteroid;

	private GameController gameController;

	// Use this for initialization
	void Start () {

		// Get a reference to the game controller object and the script
		GameObject gameControllerObject = 
			GameObject.FindWithTag ("GameController");

		gameController = 
			gameControllerObject.GetComponent <GameController> ();

		// Push the asteroid in the direction that it's facing
		GetComponent<Rigidbody2D> ()
			.AddForce (transform.up * Random.Range (-50.0f, 150.0f));

		// Give a random angular velocity/rotation
		GetComponent<Rigidbody2D> ()
			.angularVelocity = Random.Range (-0.0f, 90.0f);
	}
	
	// Update is called once per frame
	void OnCollisionEnter2D(Collision2D c) {

		if (c.gameObject.tag.Equals ("Bullet")) {
			
			// Destroy the bullet
			Destroy (c.gameObject);

			// If large asteroid, spawn new ones
			if (tag.Equals ("Large Asteroid")) {
				Instantiate (smallAsteroid,
					new Vector3 (transform.position.x - .5f,
						transform.position.y - .5f, 0),
					Quaternion.Euler (0, 0, 90));

				// THIS IS WHERE I HAVE FALLEN... TO MY FUTURE SELF... CARRY ON MY WORK... FINSIH IT... REDEEM THE FAMILY...
				// TAKE THIS ALEX1KENOBI... YOU'RE MY ONLY HOPE...
			}
		}
	}
}
