using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainArchitect : Architect {
	
	public override void Generate() {
		TerrainGen.setSeed();
		world.biome = GenerateBiome(world.biome);
		for(int x=0; x<world.amount; x++ )
			for(int z = 0; z<world.amount; z++ )
				CreateChunk<TerrainChunk> (x*world.chunkWidth,0,z*world.chunkDepth,world.WorldChunks[0]);
	}	
	
	public override Biome GenerateBiome(Biome biome) {
		biome.mountainValue = Math.randomf(0.02f,0.05f);
		biome.blobValue = Math.randomf(0.01f,0.035f);
		biome.scoopValue = Math.randomf(0.0015f,0.005f);
		biome.Factor = Math.random(3,6);
		biome.treeThreshold = Math.randomf(0.9f,0.925f);
		biome.detailValue = Math.randomf(0.2f,0.225f);
		biome.grassThreshold = Math.randomf(0.45f,0.55f);
		return biome;
	}
	
}
