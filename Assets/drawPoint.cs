using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class drawPoint : MonoBehaviour {
	public Transform mesh;
	public Transform vertex;
	public Transform[] vertices;
	public int numPlatformsAllowed;
	public Material cyan;
	public Material red;
	
	public Text platformInfo;
	public Text scoreKeeper;
	
	private List<Vector3> platformLoc;
	private List<GameObject> platforms;

	private bool justAddedPoint = false;
	// Use this for initialization
	void Start () {
		vertices = new Transform[2];
		platformLoc = new List<Vector3>();
		platforms = new List<GameObject>();
		platformInfo.text = (numPlatformsAllowed-platforms.Count)+" pfrms left, drawing cyan";
	}
	
	// Update is called once per frame
	void Update () {
		// Point is always 10m in front of the camera and in the middle of the window
		Vector3 previewPos = Camera.main.transform.position + Camera.main.transform.forward * 10f; 

		if(transform.position != previewPos) {
			transform.position = previewPos;
			if(vertices[1] != null) {
				mesh.GetComponent<mesh>().dropLastTriangle();
				mesh.GetComponent<mesh>().meshMaker(previewPos);
			}
		}

		// Add vertex at position where transparent gray preview point is
		if(Input.GetKeyUp(KeyCode.Space)) {
			justAddedPoint = true;
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
		else if(Input.GetMouseButtonDown(0)){
			recordPositions();
		}
	}
	void drawPlatform()
	{
		if(platformLoc.Count != 0 && (platformLoc.Count % 2 == 0))
		{
			int _index = platformLoc.Count - 2;
			Vector3 pos0 = platformLoc[_index++];
			Vector3 pos1 = platformLoc[_index];
			float absX0 = Mathf.Abs(pos0.x);
			float absX1 = Mathf.Abs(pos1.x);
			float xSize = Mathf.Max (absX0,absX1) - Mathf.Min (absX0,absX1);
			
			float absY0 = Mathf.Abs(pos0.y);
			float absY1 = Mathf.Abs(pos1.y);
			float ySize = Mathf.Max (absY0,absY1) - Mathf.Min (absY0,absY1);
			
			GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
			
			cube.transform.position = new Vector3((pos0.x+pos1.x)/2f,(pos0.y+pos1.y)/2f,(pos0.z+pos1.z)/2f);
			cube.transform.localScale = new Vector3(xSize/2f,ySize/2f,16);
			
			cube.GetComponent<BoxCollider>().isTrigger = true;
			cube.AddComponent("ground");
			cube.GetComponent<ground>().scoreKeeper = scoreKeeper.transform;
			platforms.Add(cube);
			
			
			if(platforms.Count == numPlatformsAllowed){
				platformInfo.text = "Out of platforms";
			}
			else if((platforms.Count % 2 == 0)){
				cube.GetComponent<Renderer>().renderer.material = cyan;
				platformInfo.text = (numPlatformsAllowed-platforms.Count)+" pfrms left, drawing red";
			}
			else {
				cube.GetComponent<Renderer>().renderer.material = red;
				platformInfo.text = (numPlatformsAllowed-platforms.Count)+" pfrms left, drawing cyan";
			}
			
		}
	}
	
	void recordPositions()
	{
		//Vector3 loc = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		Vector3 loc = Camera.main.transform.position + Camera.main.transform.forward * 10f;
		platformLoc.Add(loc);
		if((platformLoc.Count % 2) == 0 && platforms.Count < numPlatformsAllowed)
		{
			drawPlatform();
		}
	}
}
