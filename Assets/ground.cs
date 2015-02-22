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
		print ("Collision");
		if(other.tag == "Bomb") {
			if(other.gameObject.GetComponent<bomb>().grounded == true) {
				return;
			}
			else {
				other.gameObject.GetComponent<bomb>().grounded = true;
				if(other.renderer.material.color == renderer.material.color) {
					scoreKeeper.GetComponent<score>().addToScore(10);
					//print ("+10");
				}
				else {
					scoreKeeper.GetComponent<score>().addToScore(-10);
					//print ("-10");
				}
			}
		}
	}
}
