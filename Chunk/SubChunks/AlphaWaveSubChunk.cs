using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlphaWaveSubChunk : SolidSubChunk {

	public override IEnumerator Generate() {
		yield return 0;
	/*	for (int x =0; x<chunkWidth; x++) {
			for (int z = 0; z<chunkDepth; z++) {
				//parentChunk.addBlock(x,0,z,1,index);
				if(Math.flipCoin())
					if(Math.flipCoin())
						//if(Math.flipCoin())
						parentChunk.addBlock(x,2,z,6,index);
			}
			
		}*/		
		//Architect.BuildSubChunk(this,this.design);
		
		//StartCoroutine(ReDraw());
		waitingChunks.Remove(this);
		renderChunks.Add(this);
		while( waitingChunks.Count > 0 && waitingChunks[0] == null )
			waitingChunks.RemoveAt(0);
		if(waitingChunks.Count > 0 )
			StartCoroutine(waitingChunks[0].Generate() );
		else { 
			if(state == 0)
				StartCoroutine(renderChunks[0].ReDraw());
			state = 1;
		}		
	}
	
	public override IEnumerator renderMesh(ChunkMesh data) {
		filter.mesh.Clear ();
		filter.mesh.vertices = data.Vertices.ToArray ();
		filter.mesh.triangles = data.Triangles.ToArray ();
		filter.mesh.uv = data.UVs.ToArray ();
		filter.mesh.RecalculateNormals ();
		//collide.sharedMesh = filter.mesh;
		yield return 0;
	}
}
