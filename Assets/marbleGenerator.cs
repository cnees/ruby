using UnityEngine;
using System.Collections;

public class marbleGenerator : MonoBehaviour {

	public Transform box;

	// Use this for initialization
	void Start () {
		Instantiate(box, Vector3.zero, Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
