using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SolidSubChunk : SubChunk {
	
	//public Design design;

	public override void Start() {

	}
	// Use this for initialization
	public override void poolStart () {
		if(!filter)
			filter = gameObject.GetComponent<MeshFilter> ();
		if(!collide)
			collide = gameObject.GetComponent<MeshCollider> ();
		if(!renderer)
			renderer = gameObject.GetComponent<MeshRenderer>();
		state = 0;
		updateChunk = false;
		blocks = new short[chunkWidth,chunkHeight,chunkDepth];
		for (int x =0; x<chunkWidth; x++) {
			for (int y = 0; y<chunkHeight; y++) {
				for (int z = 0; z<chunkDepth; z++) {
					blocks[x,y,z] = 0;
				}
			}
		}
	}
	
	public override IEnumerator Generate() {
		yield return 0;
		TerrainGen.GenerateTerrain( this.parentChunk );	
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

	public override IEnumerator ReDraw() {
		if(this==null) {
			while( waitingChunks.Count > 0 && waitingChunks[0] == null )
				waitingChunks.RemoveAt(0);
			if(waitingChunks.Count > 0 )
				StartCoroutine(waitingChunks[0].Generate() );			
			yield return 0;
		}
		yield return 0;
		ChunkMesh data = new ChunkMesh ();
		for (int x = 0; x<chunkWidth; x++)
			for (int y =0; y<chunkHeight; y++)
				for (int z = 0; z<chunkDepth; z++)
					if (blocks [x, y, z] != 0)
						data = BlockBin.GetBlock(blocks [x, y, z]).Draw (this, x, y, z, data);
		StartCoroutine(renderMesh (data));
		renderChunks.Remove(this);
		while( renderChunks.Count > 0 && renderChunks[0] == null )
			renderChunks.RemoveAt(0);
		if(renderChunks.Count > 0 )
			StartCoroutine(renderChunks[0].ReDraw() );
		else 
			state = 3;
		
	}

	public override IEnumerator renderMesh(ChunkMesh data) {
		filter.mesh.Clear ();
		filter.mesh.vertices = data.Vertices.ToArray ();
		filter.mesh.triangles = data.Triangles.ToArray ();
		filter.mesh.uv = data.UVs.ToArray ();
		filter.mesh.RecalculateNormals ();
		collide.sharedMesh = filter.mesh;
		yield return 0;
	}
	

	// Update is called once per frame
	protected override void Update () {
		if(updateChunk) {
			updateChunk = false;
			StartCoroutine(ReDraw());
		}
		if(parentChunk.world.cam.tick==0) {
			if(isVisible != renderer.enabled) 
				renderer.enabled = isVisible;
			num++;
		}
		else if(parentChunk.world.cam.tick==2){
			bool tempVis = parentChunk.world.cam.canISee(parentChunk.subChunk[0].collide);	
			if(tempVis != isVisible) {
				isVisible = tempVis;
				renderer.enabled = isVisible;
			}
		}
	}
}
