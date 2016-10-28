using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : Shape {

	protected float offsetX;
	protected float offsetZ;
	protected bool which;
	
	protected static int[] listOne = new int[] { 0, 4, 20, 24 }; 
	protected static int[] listTwo = new int[] { 2, 14, 10, 22 }; 
	
	public Billboard() : base() {
		offsetX = Random.Range(-0.25f,0.25f);
		offsetZ = Random.Range(-0.25f,0.25f);
		which = Math.flipCoin();
	}
	
	public override Vector3 [] MakeShape( float x, float y, float z, WorldTypes.Direction direction, float size = 1.0f, int placement=1, int rotation=0  ) {
		return CreateBillboard(x,y,z,direction);
	}
	
	public Vector3[] CreateBillboard (float x, float y, float z, WorldTypes.Direction direction)
	{
		Vector3 [] verts = new Vector3[4];
		if(which)
			switch(direction) {
			case WorldTypes.Direction.north:
				/*verts [0] = addtoCube(x,y,z,Shape.getVert(listTwo[2],-0.5f),offsetX,offsetZ);
				verts [1] = addtoCube(x,y,z,Shape.getVert(listTwo[2],0.5f),offsetX,offsetZ);			
				verts [2] = addtoCube(x,y,z,Shape.getVert(listTwo[1],0.5f),offsetX,offsetZ);
				verts [3] = addtoCube(x,y,z,Shape.getVert(listTwo[1],-0.5f),offsetX,offsetZ); */
				verts [0] = addtoCube(x,y,z,Shape.getVert(listOne[2],-0.5f),offsetX,offsetZ);
				verts [1] = addtoCube(x,y,z,Shape.getVert(listOne[2],0.5f),offsetX,offsetZ);			
				verts [2] = addtoCube(x,y,z,Shape.getVert(listOne[1],0.5f),offsetX,offsetZ);
				verts [3] = addtoCube(x,y,z,Shape.getVert(listOne[1],-0.5f),offsetX,offsetZ);
				break;
			case WorldTypes.Direction.south:
				/*verts [0] = addtoCube(x,y,z,Shape.getVert(listTwo[1],-0.5f),offsetX,offsetZ);
				verts [1] = addtoCube(x,y,z,Shape.getVert(listTwo[1],0.5f),offsetX,offsetZ);			
				verts [2] = addtoCube(x,y,z,Shape.getVert(listTwo[2],0.5f),offsetX,offsetZ);
				verts [3] = addtoCube(x,y,z,Shape.getVert(listTwo[2],-0.5f),offsetX,offsetZ);*/
				verts [0] = addtoCube(x,y,z,Shape.getVert(listOne[1],-0.5f),offsetX,offsetZ);
				verts [1] = addtoCube(x,y,z,Shape.getVert(listOne[1],0.5f),offsetX,offsetZ);			
				verts [2] = addtoCube(x,y,z,Shape.getVert(listOne[2],0.5f),offsetX,offsetZ);
				verts [3] = addtoCube(x,y,z,Shape.getVert(listOne[2],-0.5f),offsetX,offsetZ);
				break;
			case WorldTypes.Direction.west:
				/*verts [0] = addtoCube(x,y,z,Shape.getVert(listTwo[3],-0.5f),offsetX,offsetZ);
				verts [1] = addtoCube(x,y,z,Shape.getVert(listTwo[3],0.5f),offsetX,offsetZ);			
				verts [2] = addtoCube(x,y,z,Shape.getVert(listTwo[0],0.5f),offsetX,offsetZ);
				verts [3] = addtoCube(x,y,z,Shape.getVert(listTwo[0],-0.5f),offsetX,offsetZ);*/
				verts [0] = addtoCube(x,y,z,Shape.getVert(listOne[3],-0.5f),offsetX,offsetZ);
				verts [1] = addtoCube(x,y,z,Shape.getVert(listOne[3],0.5f),offsetX,offsetZ);			
				verts [2] = addtoCube(x,y,z,Shape.getVert(listOne[0],0.5f),offsetX,offsetZ);
				verts [3] = addtoCube(x,y,z,Shape.getVert(listOne[0],-0.5f),offsetX,offsetZ);
				break;
			case WorldTypes.Direction.east:
				/*verts [0] = addtoCube(x,y,z,Shape.getVert(listTwo[0],-0.5f),offsetX,offsetZ);
				verts [1] = addtoCube(x,y,z,Shape.getVert(listTwo[0],0.5f),offsetX,offsetZ);			
				verts [2] = addtoCube(x,y,z,Shape.getVert(listTwo[3],0.5f),offsetX,offsetZ);
				verts [3] = addtoCube(x,y,z,Shape.getVert(listTwo[3],-0.5f),offsetX,offsetZ);*/
				verts [0] = addtoCube(x,y,z,Shape.getVert(listOne[0],-0.5f),offsetX,offsetZ);
				verts [1] = addtoCube(x,y,z,Shape.getVert(listOne[0],0.5f),offsetX,offsetZ);			
				verts [2] = addtoCube(x,y,z,Shape.getVert(listOne[3],0.5f),offsetX,offsetZ);
				verts [3] = addtoCube(x,y,z,Shape.getVert(listOne[3],-0.5f),offsetX,offsetZ);
				break;		
			}

		return verts;
	}
	public Vector3 addtoCube( float x, float y, float z, Vector3 inVert, float offX, float offZ) {
		return new Vector3 (inVert.x + x + offX, (inVert.y + y), inVert.z + z + offZ);
	}
}
