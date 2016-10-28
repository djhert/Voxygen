using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Design {
	public int Width;
	public int Height;
	public int Depth;
	
	public Architect master;
	
	public Chunk chunk;
	
	public virtual Blueprint GenerateDesign() {
		return new Blueprint();
	}
	
	public virtual void BuildWord() {
	 
	}
}
