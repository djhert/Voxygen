using UnityEngine;
using System.Collections;
using SimplexNoise;

public static class TerrainGen {

	private static int seed = 0;
	
	static Vector3 offset0;
	static Vector3 offset1;
	static Vector3 offset2;
	static Vector3 offset3;
	
	public static void setSeed() {
		////seed = synthSeed (System.DateTime.Now.Millisecond);
		TerrainGen.seed = Random.Range(0, int.MaxValue);
		Random.seed = seed;
		offset0 = new Vector3(Random.value*10000,Random.value*10000,Random.value*10000);
		offset1 = new Vector3(Random.value*10000,Random.value*10000,Random.value*10000);
		offset2 = new Vector3(Random.value*10000,Random.value*10000,Random.value*10000);
		offset3 = new Vector3(Random.value*10000,Random.value*10000,Random.value*10000);
	}
	
	public static Chunk genTop( float x, float z, Chunk chunk ) {
		Biome biome = chunk.world.biome;		
		float heightSwing = biome.Height - biome.baseHeight;		
		
		float blobValue;
		float mountainValue;
		float scoopValue;
		float detailValue;
		
		bool found = false;
		float y = biome.Height;
		while(!found && y >=0) {			
			Vector3 blockPos = new Vector3( chunk.position.x+x,y,chunk.position.z+z );
			
			mountainValue = CalcNoiseValue( blockPos, offset0, biome.mountainValue) ;
			blobValue = CalcNoiseValue(blockPos, offset1, biome.blobValue);
			scoopValue = CalcNoiseValue(blockPos,offset2, biome.scoopValue);
			
			//mountainValue = Mathf.Sqrt(mountainValue);
			mountainValue = Mathf.Pow(mountainValue,heightSwing);
			mountainValue += biome.baseHeight*2;
						
			mountainValue += blobValue*biome.Factor;	
			mountainValue -= scoopValue*biome.Factor;
			
					
			if(mountainValue >= blockPos.y ) { //This is the top of the terrain, build from here
				chunk = genCol((int)x,y,(int)z,chunk);
				detailValue = CalcNoiseValue(blockPos,offset3, biome.detailValue);
				//Debug.Log("Detail Value " + detailValue);
				//treeValue = scoopValue*biome.treeValue;
				if( detailValue >= biome.treeThreshold ) {
					if(x>=2&&x<chunk.chunkWidth-2&&z>=2&&z<chunk.chunkDepth-2) {
						found = true;
						chunk = genTree((int)x,y,(int)z,chunk);
					}
					found = false;
				}
				if( detailValue+blobValue-scoopValue > biome.grassThreshold && !found ) {
					chunk.addBlock((int)x,Mathf.FloorToInt(y)+1,(int)z,6,1);
					//Debug.Log("Detail Value " + detailValue);
				}
				found = true;
				break;
			} else 
				y--;
			if(y < biome.baseHeight && !found) {
				chunk= genWaterCol((int)x,biome.baseHeight,(int)z,chunk);
				found = true;
				break;
			}
		}
		return chunk;
	}
	
	public static Chunk genCol( int x, float y, int z, Chunk chunk ) {
		int tempY = Mathf.FloorToInt(y);
		while(tempY>=0) {
			if(tempY == Mathf.FloorToInt(y)) 
				chunk.addBlock(x,tempY,z,2,0);
			else if(tempY == 1) 
				chunk.addBlock(x,tempY,z,4,0);
			else if(tempY == 0)
				chunk.addBlock(x,tempY,z,1,0);
			else 
				chunk.addBlock(x,tempY,z,3,0);
			tempY--;
		}
		
		return chunk;
	}
	public static Chunk genWaterCol( int x, float y, int z, Chunk chunk ) {
		int tempY = Mathf.FloorToInt(y);
		while(tempY>0) {
			if(tempY == 1) 
				chunk.addBlock(x,tempY,z,4,0);
			else
				chunk.addBlock(x,tempY,z,9,1);
				
			tempY--;
		}
		
		return chunk;
	}
	
	public static Chunk genTree( int x, float y, int z, Chunk chunk ) {
		int tempY = Mathf.FloorToInt(y)+1;
		int trunkSize = Math.random(3,6);
		
		for(int t = x-1; t<x+2; t++ ) 
			for(int u = (tempY+trunkSize)-1; u<(tempY+trunkSize)+2; u++ ) 
				for(int v = z-1; v<z+2; v++ ) 
						chunk.addBlock(t,u,v,8,1);
		for(int i = tempY; i<tempY+trunkSize; i++ )
			chunk.addBlock(x,i,z,7,0);

		return chunk;
	}

	public static Chunk GenerateTerrain( Chunk chunk ) {
		
		for(int x = 0; x < chunk.chunkWidth; x++ ) {
			for( int z = 0; z< chunk.chunkHeight; z++ ) {
				chunk = genTop(x,z,chunk);
			}
		}
		return chunk;
	}
	
	public static float CalcNoiseValue( Vector3 pos, Vector3 offSet, float scale ) {
		float noiseX = Mathf.Abs((pos.x+offSet.x)*scale);
		float noiseY = Mathf.Abs((pos.y+offSet.y)*scale);
		float noiseZ = Mathf.Abs((pos.z+offSet.z)*scale);
		return Mathf.Max(0,Noise.Generate(noiseX,noiseY,noiseZ));
	}

}
