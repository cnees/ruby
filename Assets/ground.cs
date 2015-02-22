using UnityEngine;
using System.Collections;

public class ground : MonoBehaviour {

	public Transform scoreKeeper;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		//print ("Collision");
		if(other.tag == "Bomb") {
			// Ignore bombs that have already hit the ground.
			if(other.gameObject.GetComponent<bomb>().grounded == true) {
				return;
			}
			else {
				// grounded is true when the bomb has hit the ground.
				other.gameObject.GetComponent<bomb>().grounded = true;
				// Add ten points for matching colors, subtract ten for mismatched colors
				if(other.renderer.material.color == renderer.material.color) {
					scoreKeeper.GetComponent<score>().addToScore(10);
				}
				else {
					scoreKeeper.GetComponent<score>().addToScore(-10);
				}
			}
		}
	}
}
