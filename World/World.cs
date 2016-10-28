using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class World : MonoBehaviour {
	public Chunk [] WorldChunks;
	
	protected ChunkBuilder Builder = new ChunkBuilder();
	
	public int chunkWidth;
	public int chunkHeight;
	public int chunkDepth;
	
	public int amount;
	
	public CameraControl cam;
	
	public Biome biome;
	
	public Architect master;
	public LoadingScreen loading;
	
	protected int state = 0;
	
	public bool Regen = false;
	
	protected Dictionary<Vector3, Chunk> AllChunks= new Dictionary<Vector3,Chunk>();
	// Use this for initialization
	protected virtual void Start () {
		loading.WakeUp();
		master.world = this;
		master.Generate();
		
		loading.SetTextState(0);
	}
	
	protected void CheckState() {
		if(state == 0) {
			if(SubChunk.waitingChunks.Count <= 0) {
				state = 1;
				loading.SetTextState(state);
			}
		} else if(state == 1) {
			if(SubChunk.renderChunks.Count <= 0) {
				state = 2;
				loading.SetTextState(state);
			}
		}
	}
		
	// Update is called once per frame
	protected virtual void Update () {
		CheckState();
		if(Regen) {
			Regen = false;
			Regenerate();
		}
	}
	
	public void AddChunk( Vector3 key, Chunk chunk ) {
		AllChunks.Add(key,chunk);
	}
	
	public Block GetBlock( int x, int y, int z, Chunk asking ) {
         
         int posX = Mathf.FloorToInt((x+asking.position.x) / chunkWidth ) * chunkWidth;
         int posY = Mathf.FloorToInt((y+asking.position.y) / chunkHeight ) * chunkHeight;
         int posZ = Mathf.FloorToInt((z+asking.position.z) / chunkDepth ) * chunkDepth;
         Chunk tempChunk = null;
         if(AllChunks.TryGetValue(new Vector3(posX,posY,posZ), out tempChunk)) {
			 if(tempChunk == asking)
				return BlockBin.Air;
			 else {
				return tempChunk.GetBlock((int)((x+asking.position.x)-tempChunk.position.x),(int)((y+asking.position.y)-tempChunk.position.y),(int)((z+asking.position.z)-tempChunk.position.z));	
			}
		 }
		else return BlockBin.Solid; 
	}
	
	public void Regenerate() {
		foreach(KeyValuePair<Vector3, Chunk> entry in AllChunks) {
			entry.Value.Delete();
		}
		AllChunks.Clear();
		master.Generate();
	}
}
