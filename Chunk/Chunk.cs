using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Chunk : PooledObject {
	
	public int chunkWidth = 20;
	public int chunkHeight = 8;
	public int chunkDepth = 20;
	public World world;
	
	public bool updateChunk = false;

	public List <SubChunk> subChunk = new List<SubChunk> ();	//SubChunks that are on this chunk.  Have the same index has their blockSub

	protected short[,,] blockWorld;

	public Vector3 position;
	
	// Use this for initialization
	public virtual void Start () {
		updateChunk = true;
	}
	public override void poolStart() {
		updateChunk = true;
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
	
	public bool addBlock( int x, int y, int z, short inBlock, int index ) {
		if( inRange(x,y,z) ) {
			updateChunk = false;
			subChunk[index].addBlock(x,y,z,inBlock);
			blockWorld[x,y,z] = (short)index;
			return true;
		} else return false;
		
	}
	
	
	public short getBlock( int x, int y, int z ) {
		if (inRange (x,y,z)) 
			return getChunkAtPosition(x,y,z).getBlockNum(x,y,z);
		else
			return 0;
	}
	
	public Block GetBlock( int x, int y, int z ) {
		if(inRange(x,y,z)) {
			SubChunk t = getChunkAtPosition(x,y,z);
			if( t != null )
				return BlockBin.GetBlock(t.getBlockNum(x,y,z));
			else 
				return BlockBin.Air;
		}
		else 
			//return BlockBin.Air;
			return world.GetBlock(x,y,z,this);
	}
			
	protected bool inRange( int x, int y, int z ) {
		bool t = false;
		if (x >= 0 && x < chunkWidth)
			if (y >= 0 && y < chunkHeight)
				if (z >= 0 && z < chunkDepth)
					t= true;
		
		return t;
		
	}

	public SubChunk getChunkAtIndex(int index) { 
		SubChunk subB = null;
		foreach (SubChunk sub in subChunk) {
			if (sub.index == index)
				subB = sub;
		}
		return subB;
	}
	
	public SubChunk getChunkAtPosition( int x, int y, int z ) {
		if(inRange(x,y,z)) {
			//Debug.Log(blockWorld[x,y,z] + " " + subChunk.Count);
			//return subChunk[0];
			return getChunkAtIndex(blockWorld[x,y,z]);
		}
		else 
			return null;
	}
		
	public void Delete() {
		ResetChunk();
		ReturnToPool();
	}		
	public virtual void ResetChunk() {
		foreach(SubChunk sc in subChunk) {
			sc.Reset();
		}
		subChunk.Clear();
	}
	
	protected void Purge() {
		for(int i =0; i<subChunk.Count; i++)
			subChunk[i].ReturnToPool();
		subChunk.Clear();
	}

	// Update is called once per frame
	protected virtual void Update () {
		if(updateChunk) {
			updateChunk = false;
			StartCoroutine(ReDraw());
		}
	}
}
