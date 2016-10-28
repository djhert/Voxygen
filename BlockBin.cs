using UnityEngine;
using System.Collections;

public static class BlockBin {
	public static BlockGrass Grass = new BlockGrass();
	public static BlockDirt Dirt = new BlockDirt();
	public static BlockStone Stone= new BlockStone();
	public static BlockWood Wood = new BlockWood();
	public static BlockLeaves Leaves = new BlockLeaves();
	public static TallGrassBlock TallGrass = new TallGrassBlock();
	public static BlockWater Water = new BlockWater();
	public static BlockAir Air = new BlockAir();
	public static BlockSolid Solid = new BlockSolid();
	public static BlockColor Color = new BlockColor();

	public static void Create() {
		
	}
	
	public static Block GetBlock( short i ) {
		if( i == 0 )
			return Air;
		else if( i == 2 ) 
			return Grass;
		else if( i == 3 )
			return Dirt;
		else if( i == 4 )
			return Stone;
		else if( i == 1 ) 
			return Solid;
		else if( i == 5 ) 
			return Color;
		else if(i == 6 )
			return TallGrass;
		else if(i == 7 )
			return Wood;
		else if(i == 8 )
			return Leaves;
		else if(i == 9 )
			return Water;
		else
			return Air;
	}
}
