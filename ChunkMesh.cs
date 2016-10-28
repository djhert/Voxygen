using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ChunkMesh {
	public List<Vector3> Vertices = new List<Vector3>();
	public List<int> Triangles = new List<int>();
	public List<Vector2> UVs = new List<Vector2>();
	
	public void addVertices( Vector3 [] inVerts ) {
		foreach (Vector3 element in inVerts)
			Vertices.Add (element);
	}
	
	public void createQuads() { //Takes the four verts based on the array. 
		Triangles.Add (Vertices.Count - 4);
		Triangles.Add (Vertices.Count - 3);
		Triangles.Add (Vertices.Count - 2);
		
		Triangles.Add (Vertices.Count - 4);
		Triangles.Add (Vertices.Count - 2);
		Triangles.Add (Vertices.Count - 1);
	}
	
	public void CreateTri() {
		Triangles.Add(Vertices.Count - 3);
		Triangles.Add(Vertices.Count - 2);
		Triangles.Add(Vertices.Count - 1);
	}
	
	public void createDoubleQuads() { //Takes the four verts based on the array. 
		createQuads();
		Triangles.Add (Vertices.Count - 8);
		Triangles.Add (Vertices.Count - 7);
		Triangles.Add (Vertices.Count - 6);
		
		Triangles.Add (Vertices.Count - 4);
		Triangles.Add (Vertices.Count - 6);
		Triangles.Add (Vertices.Count - 5);
	}
}
