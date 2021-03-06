﻿	using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class mesh : MonoBehaviour {

	private List<Vector3> points;
	private List<int> triangles;
	//private List<Vector2> uvs;

	// Use this for initialization
	void Start () {
		points = new List<Vector3>();
		triangles = new List<int>();
		//uvs = new List<Vector2>();
		GetComponent<MeshFilter>().mesh = new Mesh();
	}

	// Get rid of mesh
	public void reset() {
		points.Clear();
		triangles.Clear();
		GetComponent<MeshFilter>().mesh.Clear ();
	}

	private void updateMesh() {
		// Three or more points are needed to start the mesh
		if(triangles.Count >= 3) {
			// Clear old mesh
			GetComponent<MeshFilter>().mesh.Clear ();
			// Update vertices and triangles
			GetComponent<MeshFilter>().mesh.vertices = points.ToArray();
			GetComponent<MeshFilter>().mesh.triangles = triangles.ToArray();
			// UVs are for mapping textures. You should ignore them.
			Vector2[] uvs = new Vector2[points.Count];
			Vector3[] verts = GetComponent<MeshFilter>().mesh.vertices;
			for (int i = 0; i < uvs.Length; i++) {
				uvs[i] = new Vector2(verts[i].x, verts[i].z);
			}
			GetComponent<MeshFilter>().mesh.uv = uvs;
			GetComponent<MeshFilter>().mesh.RecalculateNormals();
			GetComponent<MeshFilter>().mesh.RecalculateBounds();
			GetComponent<MeshFilter>().mesh.Optimize();
			
			// Refersh collider
			GetComponent<MeshCollider>().sharedMesh = null;
			GetComponent<MeshCollider>().sharedMesh = GetComponent<MeshFilter>().mesh;
		}
	}

	public void dropLastTriangle() {
		if(points.Count >= 3) {
			triangles.RemoveAt(triangles.Count - 1);
			triangles.RemoveAt(triangles.Count - 1);
			triangles.RemoveAt(triangles.Count - 1);
			triangles.RemoveAt(triangles.Count - 1);
			triangles.RemoveAt(triangles.Count - 1);
			triangles.RemoveAt(triangles.Count - 1);
			points.RemoveAt(points.Count - 1);
			updateMesh();
		}
	}
	
	// Adds newPoint to mesh
	public void meshMaker(Vector3 newPoint) {

		// Add point
		points.Add (newPoint);

		// Add UV
		/*Vector2 uv = new Vector2(newPoint.x, newPoint.y);
		uv.Normalize();
		uvs.Add (uv);	*/

		// Add triangle
		if(points.Count >= 3) {
			triangles.Add (points.Count - 3);
			triangles.Add (points.Count - 2);
			triangles.Add (points.Count - 1);
			triangles.Add (points.Count - 3);
			triangles.Add (points.Count - 1);
			triangles.Add (points.Count - 2);
		}

		updateMesh();
	}
}
