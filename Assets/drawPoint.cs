using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class drawPoint : MonoBehaviour {
	public Transform mesh;
	public Transform vertex;
	public Transform[] vertices;

	// Use this for initialization
	void Start () {
		vertices = new Transform[2];
	}
	
	// Update is called once per frame
	void Update () {
		// Point is always 10m in front of the camera and in the middle of the window
		Vector3 previewPos = Camera.main.transform.position + Camera.main.transform.forward * 10f; 
		transform.position = previewPos;

		// Add vertex at position where transparent gray preview point is
		if(Input.GetKeyUp(KeyCode.Space)) {

			// Make oldest vertex black
			// Only the most recent two vertices will remain white, since they'll be in the next triangle 
			if(vertices[0] != null) {
				vertices[0].renderer.material.color = Color.black;
			}
			vertices[0] = vertices[1]; // Stop keeping track of oldest vertex, move back second oldest

			// Create new vertex
			vertices[1] = (Transform)Instantiate (vertex, previewPos, Quaternion.identity);

			// Add new vertex to mesh
			mesh.GetComponent<mesh>().meshMaker(previewPos);
		}
	}
}
