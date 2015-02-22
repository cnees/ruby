using UnityEngine;
using System.Collections;

public class target : MonoBehaviour {
	private bool covered = false;
	public int vertexNumber;

	// Use this for initialization
	void Start () {
		gameObject.renderer.material.color = Color.blue;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		if(covered) {

		}
		else if(other.gameObject.name == "Vertex" || other.gameObject.name == "Vertex(Clone)") {
			covered = false;
			other.gameObject.renderer.material.color = Color.green;
			renderer.material.color = Color.green;
			transform.localScale -= new Vector3(0.25f, 0.25f, 0.25f);
		}
	}

	public void setVertexNumber(int vertexNum) {
		vertexNumber = vertexNum;
	}
}
