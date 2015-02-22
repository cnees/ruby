using UnityEngine;
using System.Collections;

public class MoveCamera : MonoBehaviour {

	public Transform scoreKeeper;
	public Transform mesh;

	private float speed = 0.25f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift)) {
			scoreKeeper.GetComponent<score>().addToScore(-5);
			GameObject[] bombs = GameObject.FindGameObjectsWithTag("Bomb");
			foreach(GameObject bomb in bombs) {
				bomb.GetComponent<bomb>().reset ();
				mesh.GetComponent<mesh>().reset ();
			}
			GameObject[] vertices = GameObject.FindGameObjectsWithTag("Vertex");
			foreach(GameObject vertex in vertices) {
				Destroy(vertex);
			}
		}
		if(Input.GetKeyDown(KeyCode.Return)) {
			GameObject[] bombs = GameObject.FindGameObjectsWithTag("Bomb");
			foreach(GameObject bomb in bombs) {
				bomb.GetComponent<bomb>().startFalling();
			}
		}
		if(Input.GetKey(KeyCode.Q)) {
			transform.RotateAround(Vector3.zero, transform.forward, -1f);
		}
		else if(Input.GetKey(KeyCode.E)) {
			transform.RotateAround(Vector3.zero, transform.forward, 1f);
		}
		if(Input.GetKey(KeyCode.S)) {
			transform.RotateAround(Vector3.zero, transform.right, 1f);
		}
		else if(Input.GetKey(KeyCode.W)) {
			transform.RotateAround(Vector3.zero, transform.right, -1f);
		}
		if(Input.GetKey(KeyCode.A)) {
			transform.RotateAround(Vector3.zero, transform.up, 1f);
		}
		else if(Input.GetKey(KeyCode.D)) {
			transform.RotateAround(Vector3.zero, transform.up, -1f);
		}
		if(Input.GetKey(KeyCode.UpArrow)) {
			transform.Translate(Vector3.forward * speed);
		}
		else if(Input.GetKey(KeyCode.DownArrow)) {
			transform.Translate(-1 * Vector3.forward * speed);
		}
	}
}
