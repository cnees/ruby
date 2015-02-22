using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class score : MonoBehaviour {
	private int points;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void addToScore(int add) {
		points += add;
		print (points.ToString());
		GetComponent<Text>().text = points.ToString();
	}
}
