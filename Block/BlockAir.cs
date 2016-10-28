using UnityEngine;
using System.Collections;

public class BlockAir : Block {
	public BlockAir () : base () {
	}
	
	public override string getType() {
		return "air";
	}

	public override bool isSolid (WorldTypes.Direction direction, Block inType = null) {
		return false;
	}
	
	public override ChunkMesh Draw( SubChunk chunk, int x, int y, int z, ChunkMesh data ) { 
		return data; 
	}

	public override void testPrint() {
		Debug.Log ("Air");
	}
}
