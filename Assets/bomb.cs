using UnityEngine;
using System.Collections;

public class bomb : MonoBehaviour {
	public Material yellow;
	public bool grounded = false; // Whether it has hit the ground yet
	LineRenderer lineR;
	bool visible = false;
	bool fallsdown = true;//the direction gravity takes it
	Color green = Color.green;
	Color red = Color.red;

	public void Start(){
		lineR = gameObject.AddComponent<LineRenderer> ();
		lineR.SetVertexCount(2);
		lineR.material = new Material(Shader.Find("Particles/Additive"));
		lineR.useWorldSpace = true;
	}

	void FixedUpdate() {

		if(Input.GetKeyDown(KeyCode.R)) {
			visible = !visible;
		}

		if (visible && fallsdown) {
			Vector3 pos = transform.position;
			lineR.SetColors(renderer.material.color, green);
			lineR.SetPosition(0, pos);
			if (pos.y > -4.25f){
				pos.y = pos.y - 10f;
				if (pos.y < -4.25f){pos.y = -4.25f;}
				lineR.SetWidth(0.1F, 0.1F);
			}
			else{
				pos.y +=1f; 
				lineR.SetColors(renderer.material.color, red);
				lineR.SetWidth(0.2F, 0.2F);
			}
			lineR.SetPosition(1, pos);
			lineR.enabled = true;
		}

		else if (visible && !fallsdown){
			Vector3 pos = transform.position;
			lineR.SetColors(renderer.material.color, green);
			lineR.SetPosition(0, pos);
			if (pos.y < 7.25f){
				pos.y = pos.y + 10f;
				if (pos.y > 7.25f){pos.y = 7.25f;}
				lineR.SetWidth(0.1F, 0.1F);
			}
			else{
				pos.y -=1f; 
				lineR.SetColors(renderer.material.color, red);
				lineR.SetWidth(0.2F, 0.2F);
			}
			lineR.SetPosition(1, pos);
			lineR.enabled = true;
		}



		else{lineR.enabled = false;}

		// If bomb has fallen down bellow platforms
		if(transform.position.y < -10 || transform.position.y > 10) {
			// Destroy rigidbody to stop falling
			Destroy(gameObject.constantForce);
			Destroy(gameObject.rigidbody);

		}
	}

	public void startFalling() {
		gameObject.AddComponent<Rigidbody>();
		if(renderer.material.color == yellow.color) {
			fallsdown = false;
			print ("Yellow");
			gameObject.AddComponent<ConstantForce>();
			gameObject.constantForce.force = Physics.gravity * -2f;
		}
	}

	public void reset() {
		//print ("Resetting");
		grounded = false;
		fallsdown = true;
		Destroy(gameObject.constantForce);
		Destroy(gameObject.rigidbody);
		if(renderer.material.color == yellow.color) {
			transform.position = new Vector3(Random.Range (-8f, 8f),  Random.Range (-3f,-4f), Random.Range (-8f, 8f));
		} else {
			transform.position = new Vector3(Random.Range (-8f, 8f),  Random.Range (3f,4f), Random.Range (-8f, 8f));
		}
	}

}
