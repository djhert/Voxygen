using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlphaSubChunk : SolidSubChunk {

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
