using UnityEngine;
using System.Collections;
using System.Collections.Generic;
[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(MeshCollider))]

public class SubChunk : PooledObject {
	public short[ , , ] blocks;
	public short index;

	public Chunk parentChunk;
	
	public int chunkWidth;
	public int chunkHeight;
	public int chunkDepth;
	
	protected bool updateChunk = false;
	
	public static List<SubChunk> waitingChunks = new List<SubChunk>();
	public static List<SubChunk> renderChunks = new List<SubChunk>();
	
	public int state = 0;
	
	public MeshFilter filter;
	public MeshCollider collide;
	public MeshRenderer renderer;
	
	protected bool isVisible = true;
	protected int num = 0;
	
	//public Design design;

	public virtual void Start() {

	}
	// Use this for initialization
	public override void poolStart () {
		if(!filter)
			filter = gameObject.GetComponent<MeshFilter> ();
		if(!collide)
			collide = gameObject.GetComponent<MeshCollider> ();
		if(!renderer)
			renderer = gameObject.GetComponent<MeshRenderer>();		
	}
	
	 /*protected void AddToParent() {
		short [,,] iGrid = generateIGrid();
		for( int x = 0; x<chunkWidth; x++ ) 
			for ( int y = 0; y<chunkHeight; y++ )
				for(int z = 0; x<chunkDepth; z++ )
					parentChunk.blockWorld[x,y,z] = iGrid[x,y,z];
	}
	
	protected short[,,] generateIGrid() {
		short [,,] iGrid = new short[chunkWidth,chunkHeight,chunkDepth];
		for(int x=0; x<chunkWidth; x++)
			for(int y=0; y<chunkHeight; y++)
				for(int z=0; z<chunkDepth; z++)
					if(blocks[x,y,z] == 0)
						iGrid[x,y,z] = -1;
					else
						iGrid[x,y,z] = index;
		return iGrid;
	}*/
	
	public void ReadyToGenerate() {
		waitingChunks.Add(this);
		if( waitingChunks[0] == this ) 
			StartCoroutine(Generate ());
	}
	
	public virtual IEnumerator Generate() {
		yield return 0;
	}

	public virtual IEnumerator ReDraw() {
		yield return 0;
	}

	public virtual IEnumerator renderMesh(ChunkMesh data) {
		yield return 0;
	}

	public bool addBlock( int x, int y, int z, short inBlock ) {
		if(state != 0 )
			updateChunk = true;
		blocks[x,y,z] = inBlock;		
		return true;
	}
	
	public virtual void Reset() {
		filter.mesh.Clear ();
		//collide.sharedMesh.Clear();
		ReturnToPool();
	}
	public Block getBlock( int x, int y, int z ) {
		//if (inRange (x, y, z))
		//	return BlockBin.GetBlock(blocks[x,y,z]);
		//else 
		return parentChunk.GetBlock(x,y,z);
	}

	public short getBlockNum( int x, int y, int z ) {
		if (inRange (x, y, z))
			return blocks[x,y,z];
		else return 0;
	}
	
	protected bool inRange( int x, int y, int z ) {
		bool t = false;
		if (x >= 0 && x < chunkWidth)
			if (y >= 0 && y < chunkHeight)
				if (z >= 0 && z < chunkDepth)
					t= true;
		
		return t;
	}

	// Update is called once per frame
	protected virtual void Update () {
		if(updateChunk) {
			updateChunk = false;
			StartCoroutine(ReDraw());
		}
	}
}
