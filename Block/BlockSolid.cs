using UnityEngine;
using System.Collections;

public class BlockSolid : Block {
	public BlockSolid () : base () {
	}

	public override void testPrint() {
		Debug.Log ("Solid");
	}
}
