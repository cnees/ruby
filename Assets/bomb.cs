using UnityEngine;
using System.Collections;

public class bomb : MonoBehaviour {
	public bool grounded = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}

	void FixedUpdate() {
		if(transform.position.y < -10) {
			Destroy(gameObject.rigidbody);
		}
	}

	public void startFalling() {
		gameObject.AddComponent<Rigidbody>();
	}

	public void reset() {
		print ("Resetting");
		grounded = false;
		Destroy(gameObject.rigidbody);
		transform.position = new Vector3(Random.Range (-8f, 8f),  Random.Range (3f,4f), Random.Range (-8f, 8f));
	}

}
