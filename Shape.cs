using UnityEngine;
using System.Collections;

public class Shape {
	public bool half = false;
	
	public int [] verts = new int[8]; //Stores each of the verts needed to make the shape at each location. a -1 indicates no vert there
	
	public static Vector2 [] ShapeKey = new Vector2[25] {
		new Vector2(-0.5f,0.5f), // 0 Bottom Left
		new Vector2(-0.25f,0.5f), //1
		new Vector2(-0f,0.5f),  //2
		new Vector2(0.25f,0.5f),  //3
		new Vector2(0.5f,0.5f),  //4 Bottom Right
		
		new Vector2(-0.5f,0.25f), //5
		new Vector2(-0.25f,0.25f), //6
		new Vector2(0f,0.25f),  //7
		new Vector2(0.25f,0.25f),  //8
		new Vector2(0.5f,0.25f),  //9
		
		new Vector2(-0.5f,0f), //10
		new Vector2(-0.25f,0f), //11
		new Vector2(0f,0f),  //12
		new Vector2(0.25f,0f),  //13
		new Vector2(0.5f,0f),  //14
		
		new Vector2(-0.5f,-0.25f), //15
		new Vector2(-0.25f,-0.25f), //16
		new Vector2(0f,-0.25f),  //17
		new Vector2(0.25f,-0.25f),  //18
		new Vector2(0.5f,-0.25f),  //19
	
		new Vector2(-0.5f,-0.5f), //20 Top Left
		new Vector2(-0.25f,-0.5f), //21
		new Vector2(0f,-0.5f),  //22
		new Vector2(0.25f,-0.5f),  //23
		new Vector2(0.5f,-0.5f)  //24 Top Right
	};
	
	public static Vector3 getVert( int index, float Y ) {
		return new Vector3( ShapeKey[index].x, Y, ShapeKey[index].y);
	}
	
	public virtual Vector3 [] MakeShape( float x, float y, float z, WorldTypes.Direction direction, float size = 1.0f, int placement=1, int rotation=0 ) {
		return new Vector3[]{ new Vector3 (x, y, z) };
	}

	public virtual Vector3 [] Create( float x, float y, float z, WorldTypes.Direction direction ) { 
		return new Vector3[]{ new Vector3 (x, y, z) }; 
	}

}
