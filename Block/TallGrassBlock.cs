using UnityEngine;
using System.Collections;

public class TallGrassBlock : Block {
	public TallGrassBlock() : base() {
	}
	
	public override void testPrint() {
		Debug.Log ("Tall Grass");
	}
	
	public override Shape GetShape() {
		return ShapeBin.billboard;
	}
	public override ChunkMesh Draw (SubChunk chunk, int x, int y, int z, ChunkMesh data){
		Shape shape = GetShape();

			data = FaceDataSouth(data, x, y, z, shape);
		
			data = FaceDataNorth(data, x, y, z, shape);
		
			data = FaceDataWest(data, x, y, z, shape);
		
			data = FaceDataEast(data, x, y, z, shape);
		
		
		return data;
	}
	
	public override bool isSolid (WorldTypes.Direction direction, Block inType = null)
	{
		return false;
	}
	
	
	protected override ChunkMesh FaceDataUp (ChunkMesh meshData, float x, float y, float z, Shape shape)
	{
		//For 2 do createDoubleQuads
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
		tile.x = 0;
		tile.y = 2;
		return tile;
	}

	public override Vector2[] FaceUVs(WorldTypes.Direction direction) {
		Vector2[] UVs = new Vector2[4];
		WorldTypes.Tile tilePos = TexturePosition(direction);
		float tileSizeX = 1.0f;
		float tileSizeY = 0.25f;
		UVs[0] = new Vector2(tileSizeX * tilePos.x,
		                     (tileSize * tilePos.y)+0.01f);
		UVs[1] = new Vector2(tileSizeX * tilePos.x,
		                     (tileSizeY * tilePos.y + tileSizeY)-0.05f);
		UVs[2] = new Vector2(tileSizeX * tilePos.x + tileSizeX,
		                     (tileSizeY * tilePos.y + tileSizeY)-0.05f);
		UVs[3] = new Vector2(tileSizeX * tilePos.x + tileSizeX,
		                     (tileSize * tilePos.y)+0.01f);
	/*	UVs[7] = new Vector2(tileSizeX * tilePos.x,
		                     tileSizeY * tilePos.y);
		UVs[6] = new Vector2(tileSizeX * tilePos.x,
		                     tileSizeY * tilePos.y + tileSizeY);
		UVs[5] = new Vector2(tileSizeX * tilePos.x + tileSizeX,
		                     tileSizeY * tilePos.y + tileSizeY);
		UVs[4] = new Vector2(tileSizeX * tilePos.x + tileSizeX,
		                     tileSizeY * tilePos.y);
		*/
		return UVs;
	}
}

