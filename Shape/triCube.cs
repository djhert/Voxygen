using UnityEngine;
using System.Collections;

public class triCube : Shape {
	public triCube() : base() {
	}
	
	public override Vector3 [] MakeShape( float x, float y, float z, WorldTypes.Direction direction, float size = 1.0f, int placement=1, int rotation=0  ) {
		return CreateTri(x,y,z,direction);
	}
	
	public Vector3[] CreateTri (float x, float y, float z, WorldTypes.Direction direction) {
		Vector3 [] verts;
		if( direction == WorldTypes.Direction.west || direction == WorldTypes.Direction.east ) 
			verts = new Vector3[3];
		else
			verts = new Vector3[4];
			
		switch(direction) {
		case WorldTypes.Direction.up:
			verts [0] = addtoCube(x,y,z,Shape.getVert(0,0.5f));
			verts [1] = addtoCube(x,y,z,Shape.getVert(4,0.5f));
			verts [2] = addtoCube(x,y,z,Shape.getVert(24,-0.5f)); 
			verts [3] = addtoCube(x,y,z,Shape.getVert(20,-0.5f)); 
			break;
		case WorldTypes.Direction.down:
			verts [0] = addtoCube(x,y,z,Shape.getVert(20,-0.5f));
			verts [1] = addtoCube(x,y,z,Shape.getVert(24,-0.5f));			
			verts [2] = addtoCube(x,y,z,Shape.getVert(4,-0.5f));
			verts [3] = addtoCube(x,y,z,Shape.getVert(0,-0.5f));
			break;
		case WorldTypes.Direction.north:
			verts [0] = addtoCube(x,y,z,Shape.getVert(4,-0.5f));
			verts [1] = addtoCube(x,y,z,Shape.getVert(4,0.5f));			
			verts [2] = addtoCube(x,y,z,Shape.getVert(0,0.5f));
			verts [3] = addtoCube(x,y,z,Shape.getVert(0,-0.5f));
			break;
		case WorldTypes.Direction.south:
			verts [0] = addtoCube(x,y,z,Shape.getVert(20,-0.5f));
			verts [1] = addtoCube(x,y,z,Shape.getVert(20,0.5f));			
			verts [2] = addtoCube(x,y,z,Shape.getVert(24,0.5f));
			verts [3] = addtoCube(x,y,z,Shape.getVert(24,-0.5f));
			break;
		case WorldTypes.Direction.west:
			verts [0] = addtoCube(x,y,z,Shape.getVert(0,-0.5f));
			verts [1] = addtoCube(x,y,z,Shape.getVert(0,0.5f));			
			verts [2] = addtoCube(x,y,z,Shape.getVert(20,-0.5f));
			break;
		case WorldTypes.Direction.east:
			verts [0] = addtoCube(x,y,z,Shape.getVert(24,-0.5f));
			verts [1] = addtoCube(x,y,z,Shape.getVert(4,0.5f));
			verts [2] = addtoCube(x,y,z,Shape.getVert(4,-0.5f));
			break;		
		}
		return verts;
	}
	
	public Vector3 addtoCube( float x, float y, float z, Vector3 inVert) {
		return new Vector3 (inVert.x + x, inVert.y + y, inVert.z + z);
	}

}
