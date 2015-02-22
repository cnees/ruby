using UnityEngine;
using System.Collections;

public class bomb : MonoBehaviour {

	public bool grounded = false; // Whether it has hit the ground yet

	void FixedUpdate() {

		// If bomb has fallen down bellow platforms
		if(transform.position.y < -10) {
			// Destroy rigidbody to stop falling
			Destroy(gameObject.rigidbody);
		}
	}

	public void startFalling() {
		gameObject.AddComponent<Rigidbody>();
	}

	public void reset() {
		//print ("Resetting");
		grounded = false;
		Destroy(gameObject.rigidbody);
		transform.position = new Vector3(Random.Range (-8f, 8f),  Random.Range (3f,4f), Random.Range (-8f, 8f));
	}

}
