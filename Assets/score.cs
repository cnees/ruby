using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class score : MonoBehaviour {
	private int points;

	public void addToScore(int add) {
		points += add;
		//print (points.ToString());
		GetComponent<Text>().text = points.ToString();
	}
}
