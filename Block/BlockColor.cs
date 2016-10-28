using UnityEngine;
using System.Collections;

public class BlockColor : Block {
	public int color;

	public BlockColor() : base() {
		this.color = 0;
		type = 1;
	}
	
	public BlockColor(int color) : base() {
		this.color = color;
		type = 1;
	}
	
	public override void testPrint() {
		Debug.Log ("ColorBlock " + color);
	}

	public override int [] prepareSave() {
		int [] saveData = new int [1];
		saveData[0] = color;
		return saveData; 
	}
	
	protected override ChunkMesh FaceDataUp (ChunkMesh meshData, float x, float y, float z, Shape shape)
	{
		meshData.addVertices (shape.MakeShape (x, y, z, WorldTypes.Direction.up));
		meshData.createQuads ();
		meshData.UVs.AddRange (FaceUVs (WorldTypes.Direction.up));
		return meshData;
	}
	
	protected override ChunkMesh FaceDataDown( ChunkMesh meshData, float x, float y, float z, Shape shape)
	{
		meshData.addVertices (shape.MakeShape (x, y, z, WorldTypes.Direction.down));
		meshData.createQuads ();
		meshData.UVs.AddRange (FaceUVs (WorldTypes.Direction.down));
		return meshData;
	}
	
	protected override ChunkMesh FaceDataNorth(ChunkMesh meshData, float x, float y, float z, Shape shape)
	{
		meshData.addVertices (shape.MakeShape (x, y, z, WorldTypes.Direction.north));
		meshData.createQuads ();
		meshData.UVs.AddRange (FaceUVs (WorldTypes.Direction.north));
		return meshData;
	}
	
	protected override ChunkMesh FaceDataSouth(ChunkMesh meshData, float x, float y, float z, Shape shape)
	{
		meshData.addVertices (shape.MakeShape (x, y, z, WorldTypes.Direction.south));
		meshData.createQuads ();
		meshData.UVs.AddRange (FaceUVs (WorldTypes.Direction.south));
		return meshData;
	}
	
	protected override ChunkMesh FaceDataEast (ChunkMesh meshData, float x, float y, float z, Shape shape)
	{
		meshData.addVertices (shape.MakeShape (x, y, z, WorldTypes.Direction.east));
		meshData.createQuads ();
		meshData.UVs.AddRange (FaceUVs (WorldTypes.Direction.east));
		return meshData;
	}
	
	protected override ChunkMesh FaceDataWest (ChunkMesh meshData, float x, float y, float z, Shape shape)
	{
		meshData.addVertices (shape.MakeShape (x, y, z, WorldTypes.Direction.west));
		meshData.createQuads ();
		meshData.UVs.AddRange (FaceUVs (WorldTypes.Direction.west));
		return meshData;
	}

	public override Vector2[] FaceUVs(WorldTypes.Direction direction) {
		Vector2[] UVs = new Vector2[4];
		float tileSize = 1.0f / 216.0f;
		//WorldTypes.Tile tilePos = TexturePosition(direction);
		UVs[0] = new Vector2(0,(int)color*tileSize);
		UVs[1] = new Vector2(0,(int)color*tileSize);
		UVs[2] = new Vector2(0,(int)color*tileSize);
		UVs[3] = new Vector2(0,(int)color*tileSize);
				
		return UVs;
	}
}
