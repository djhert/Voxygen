using UnityEngine;
using System.Collections;

public class bottomUp : Shape {
	public bottomUp() : base() {
	}
	
	public override Vector3 [] MakeShape( float x, float y, float z, WorldTypes.Direction direction, float size = 1.0f, int placement=1, int rotation=0  ) {
		return CreateBottom(x,y,z);
	}
	
	public Vector3[] CreateBottom (float x, float y, float z)
	{
		Vector3 [] verts = new Vector3[4];

		verts [0] = addtoCube(x,y,z,Shape.getVert(0,-0.5f));
		verts [1] = addtoCube(x,y,z,Shape.getVert(4,-0.5f));
		verts [2] = addtoCube(x,y,z,Shape.getVert(24,-0.5f)); 
		verts [3] = addtoCube(x,y,z,Shape.getVert(20,-0.5f)); 
		return verts;
	}
	
	public Vector3 addtoCube( float x, float y, float z, Vector3 inVert) {
		return new Vector3 (inVert.x + x, (inVert.y + y)/3.0f, inVert.z + z);
	}

}
