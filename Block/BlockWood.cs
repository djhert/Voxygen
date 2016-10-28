using UnityEngine;
using System.Collections;

public class BlockWood : Block {
	public BlockWood() : base() {
	}

	public override void testPrint() {
		Debug.Log ("Wood");
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
	
	public override WorldTypes.Tile TexturePosition(WorldTypes.Direction direction)
	{
		WorldTypes.Tile tile = new WorldTypes.Tile();
		if (direction == WorldTypes.Direction.up || direction == WorldTypes.Direction.down) {
		//	tile.x =  1 - Random.Range(1,3);
			tile.x = 2;
			tile.y = 1;
		} else { 
			tile.x = 1;
			tile.y = 1;
		}
		return tile;
	}

}
