using UnityEngine;
using System.Collections;

public class MoveCamera : MonoBehaviour {

	public Transform scoreKeeper; // Object holding the script that keeps score
	public Transform mesh; // User generated mesh

	private float speed = 0.3f; // Movement speed in meters per Update()
	
	// Update is called once per frame
	void Update () {

		// Press shift to reset the scene
		if(Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift)) {
			// Deduct 5 points per reset
			scoreKeeper.GetComponent<score>().addToScore(-5);

			// Reset all the bombs
			GameObject[] bombs = GameObject.FindGameObjectsWithTag("Bomb");
			foreach(GameObject bomb in bombs) {
				bomb.GetComponent<bomb>().reset ();
			}

			// Delete the mesh
			mesh.GetComponent<mesh>().reset ();

			// Delete all the vertices
			GameObject[] vertices = GameObject.FindGameObjectsWithTag("Vertex");
			foreach(GameObject vertex in vertices) {
				Destroy(vertex);
			}

		}

		// Press return to enable physics for all the bombs
		if(Input.GetKeyDown(KeyCode.Return)) {
			GameObject[] bombs = GameObject.FindGameObjectsWithTag("Bomb");
			foreach(GameObject bomb in bombs) {
				bomb.GetComponent<bomb>().startFalling();
			}
		}

		// qweasd (rotation) and uiojkl (movement) control the camera

		if(Input.GetKey(KeyCode.Q)) {
			transform.RotateAround(Vector3.zero, transform.forward, -1f);
			//transform.LookAt(transform.position + transform.forward * 10f);
		}
		else if(Input.GetKey(KeyCode.E)) {
			transform.RotateAround(Vector3.zero, transform.forward, 1f);
			//transform.LookAt(transform.position + transform.forward * 10f);
		}
		if(Input.GetKey(KeyCode.W)) {
			transform.RotateAround(Vector3.zero, transform.right, 1f);
			//transform.RotateAround(transform.position + transform.forward * 10f, transform.right, 1f);
			//transform.LookAt(transform.position + transform.forward * 10f);
		}
		else if(Input.GetKey(KeyCode.S)) {
			transform.RotateAround(Vector3.zero, transform.right, -1f);
			//transform.RotateAround(transform.position + transform.forward * 10f, transform.right, -1f);
			//transform.LookAt(transform.position + transform.forward * 10f);
		}
		if(Input.GetKey(KeyCode.A)) {
			transform.RotateAround(Vector3.zero, transform.up, 1f);
			//transform.RotateAround(transform.position + transform.forward * 10f, transform.up, 1f);
			//transform.LookAt(transform.position + transform.forward * 10f);
		}
		else if(Input.GetKey(KeyCode.D)) {
			transform.RotateAround(Vector3.zero, transform.up, -1f);
			//transform.RotateAround(transform.position + transform.forward * 10f, transform.up, -1f);
			//transform.LookAt(transform.position + transform.forward * 10f);
		}
		if(Input.GetKey(KeyCode.U)) {
			transform.Translate(Vector3.forward * speed);
		}
		else if(Input.GetKey(KeyCode.O)) {
			transform.Translate(-1 * Vector3.forward * speed);
		}
		if(Input.GetKey(KeyCode.L)) {
			transform.Translate(Vector3.right * speed);
		}
		else if(Input.GetKey(KeyCode.J)) {
			transform.Translate(-1 * Vector3.right * speed);
		}
		if(Input.GetKey(KeyCode.I)) {
			transform.Translate(Vector3.up * speed);
		}
		else if(Input.GetKey(KeyCode.K)) {
			transform.Translate(-1 * Vector3.up * speed);
		}
	}
}
