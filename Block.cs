using UnityEngine;
using System.Collections;

public class Block  {
	public bool hBlock = false;
	public bool isVisible = false;
	public const float tileSize = 0.25f;
	
	public int type;
	
	public Block() { }

	public virtual bool getVisible() { return isVisible; }

	public virtual ChunkMesh Draw( SubChunk chunk, int x, int y, int z, ChunkMesh data ) { 		
		
		Shape shape = GetShape();
		if ( !chunk.getBlock (x, y + 1, z).isSolid (WorldTypes.Direction.down, BlockBin.Solid)) {
			data = FaceDataUp(data, x, y, z, shape);
		}
		if ( !chunk.getBlock (x, y - 1, z).isSolid (WorldTypes.Direction.up, BlockBin.Solid)) {
			data = FaceDataDown(data, x, y, z, shape);
		}
		if (!chunk.getBlock (x, y, z - 1).isSolid (WorldTypes.Direction.north, BlockBin.Solid)) {
			data = FaceDataSouth(data, x, y, z, shape);
		}
		if (!chunk.getBlock (x, y, z + 1).isSolid (WorldTypes.Direction.south, BlockBin.Solid)) {
			data = FaceDataNorth(data, x, y, z, shape);
		}
		if (!chunk.getBlock (x-1, y, z).isSolid (WorldTypes.Direction.east, BlockBin.Solid)) {
			data = FaceDataWest(data, x, y, z, shape);
		}
		if (!chunk.getBlock (x+1, y, z).isSolid (WorldTypes.Direction.west, BlockBin.Solid)) {
			data = FaceDataEast(data, x, y, z, shape);
		}
		return data;
	}
	
	public virtual bool isSolid (WorldTypes.Direction direction, Block inType = null) { return true; }
	
	public virtual Shape GetShape() {
		return ShapeBin.worldCube;
	}
	
	public virtual void testPrint() {
		Debug.Log ("default");
	}
	
	public virtual string getType() {
		return "block";
	}

	public virtual int [] prepareSave() {
		return new int[0];
	}
	
	protected virtual ChunkMesh FaceDataUp (ChunkMesh chunkMesh, float x, float y, float z, Shape shape)
	{
		return chunkMesh;
	}
	
	protected virtual ChunkMesh FaceDataDown( ChunkMesh chunkMesh, float x, float y, float z, Shape shape)
	{
		return chunkMesh;
	}
	
	protected virtual ChunkMesh FaceDataNorth(ChunkMesh chunkMesh, float x, float y, float z, Shape shape)
	{
		return chunkMesh;
	}
	
	protected virtual ChunkMesh FaceDataSouth(ChunkMesh chunkMesh, float x, float y, float z, Shape shape)
	{
		return chunkMesh;
	}
	
	protected virtual ChunkMesh FaceDataEast (ChunkMesh chunkMesh, float x, float y, float z, Shape shape)
	{
		return chunkMesh;
	}
	
	protected virtual ChunkMesh FaceDataWest (ChunkMesh chunkMesh, float x, float y, float z, Shape shape)
	{
		return chunkMesh;
	}
	
	public virtual WorldTypes.Tile TexturePosition(WorldTypes.Direction direction)
	{
		WorldTypes.Tile tile = new WorldTypes.Tile();
		tile.x = 0;
		tile.y = 0;
		
		return tile;
	}
	
	public virtual float [] GetTileSizes() {
		return new float[2] {0.25f,0.25f} ;
	}

	public virtual Vector2[] FaceUVs(WorldTypes.Direction direction) {
		Vector2[] UVs = new Vector2[4];
		WorldTypes.Tile tilePos = TexturePosition(direction);
		float[] tileSize = GetTileSizes ();
		UVs[0] = new Vector2(tileSize[0] * tilePos.x,
			(tileSize[1] * tilePos.y)+0.02f);
		UVs[1] = new Vector2(tileSize[0] * tilePos.x,
			(tileSize[1] * tilePos.y + tileSize[1])-0.02f);
		UVs[2] = new Vector2(tileSize[0] * tilePos.x + tileSize[0],
			(tileSize[1] * tilePos.y + tileSize[1])-0.02f);
		UVs[3] = new Vector2(tileSize[0] * tilePos.x + tileSize[0],
			(tileSize[1] * tilePos.y)+0.02f);

		return UVs;
	}
	
	protected int GetRandom( float min, float max ) {
		return Mathf.FloorToInt(Random.Range(min, max));
	}

}
