using UnityEngine;
using System.Collections;

public class WorldTypes {
	public enum Direction { north, south, east, west, up, down }
	public enum Shapes { cube, halfcube, tricube, worldcube,road,tallgrass }
	public struct Tile {public int x; public int y;}

}
