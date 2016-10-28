using UnityEngine;
using System.Collections;

public class BlockWater : Block {
	public BlockWater() : base() {
	}
	
	public override void testPrint() {
		Debug.Log ("Dirt");
	}
	public override Shape GetShape() {
		return ShapeBin.Road;
	}
	public override ChunkMesh Draw (SubChunk chunk, int x, int y, int z, ChunkMesh data){
		Shape shape = GetShape();
		if (!chunk.getBlock (x, y + 1, z).isSolid (WorldTypes.Direction.down, BlockBin.Air )) {
			data = FaceDataUp(data, x, y, z, shape);
		}
		if ( !chunk.getBlock (x, y - 1, z).isSolid (WorldTypes.Direction.up, BlockBin.Air)) {
			data = FaceDataDown(data, x, y, z, shape);
		}
		if (!chunk.getBlock (x, y, z - 1).isSolid (WorldTypes.Direction.north, BlockBin.Air)) {
			data = FaceDataSouth(data, x, y, z, shape);
		}
		if (!chunk.getBlock (x, y, z + 1).isSolid (WorldTypes.Direction.south, BlockBin.Air)) {
			data = FaceDataNorth(data, x, y, z, shape);
		}
		if (!chunk.getBlock (x-1, y, z).isSolid (WorldTypes.Direction.east, BlockBin.Air)) {
			data = FaceDataWest(data, x, y, z, shape);
		}
		if (!chunk.getBlock (x+1, y, z).isSolid (WorldTypes.Direction.west, BlockBin.Air)) {
			data = FaceDataEast(data, x, y, z, shape);
		}
		
		return data;
	}
	
	public override bool isSolid (WorldTypes.Direction direction, Block inType = null)
	{
		if(inType.isSolid(direction))
			return false;
		else 
			return true;
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

		tile.x = GetRandom(0,4.9f);
		tile.y = 0;

		return tile;
	}
		
}

