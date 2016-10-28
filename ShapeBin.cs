using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public static class ShapeBin {
	public static Billboard billboard = new Billboard();
	public static Cube cube = new Cube();
	public static WorldCube worldCube= new WorldCube();
	public static RoadCube Road = new    RoadCube();

	public static Shape GetShape( WorldTypes.Shapes shape ) {
		if(shape == WorldTypes.Shapes.tallgrass)
			return billboard;
		else if(shape == WorldTypes.Shapes.cube) 
			return cube;
		else if(shape == WorldTypes.Shapes.worldcube)
			return worldCube;
		else if(shape == WorldTypes.Shapes.road)
			return Road;
		else
			return cube;
	}
}
