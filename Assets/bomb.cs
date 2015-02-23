using UnityEngine;
using System.Collections;

public class bomb : MonoBehaviour {
	public Material yellow;
	public bool grounded = false; // Whether it has hit the ground yet

	void FixedUpdate() {

		// If bomb has fallen down bellow platforms
		if(transform.position.y < -10 || transform.position.y > 10) {
			// Destroy rigidbody to stop falling
			Destroy(gameObject.constantForce);
			Destroy(gameObject.rigidbody);

		}
	}

	public void startFalling() {
		gameObject.AddComponent<Rigidbody>();
		if(renderer.material.color == yellow.color) {
			print ("Yellow");
			gameObject.AddComponent<ConstantForce>();
			gameObject.constantForce.force = Physics.gravity * -2f;
		}
	}

	public void reset() {
		//print ("Resetting");
		grounded = false;
		Destroy(gameObject.constantForce);
		Destroy(gameObject.rigidbody);
		if(renderer.material.color == yellow.color) {
			transform.position = new Vector3(Random.Range (-8f, 8f),  Random.Range (-3f,-4f), Random.Range (-8f, 8f));
		} else {
			transform.position = new Vector3(Random.Range (-8f, 8f),  Random.Range (3f,4f), Random.Range (-8f, 8f));
		}
	}

}
