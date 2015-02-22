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
		Vector3 mousePos = Camera.main.transform.position + Camera.main.transform.forward * 10f; 
		transform.position = mousePos;
		if(Input.GetKeyUp(KeyCode.Space)) {
			if(vertices[0] != null) {
				vertices[0].renderer.material.color = Color.black;
			}
			vertices[0] = vertices[1];
			vertices[1] = (Transform)Instantiate (vertex, mousePos, Quaternion.identity);
			mesh.GetComponent<mesh>().meshMaker(mousePos);
		}
	}
}
