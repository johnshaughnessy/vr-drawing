using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class VisibleLineWithProceduralMesh : Line
{
	[SerializeField] private bool useMinDistanceHeuristic;
	[SerializeField] [Range(0.0f, 1.0f)] private float minDistance;
	[SerializeField] [Range(0.0f, 0.01f)] private float lineWidth;
	private List<Vector3> triangles = new List<Vector3>();
	private List<Vector3> curve = new List<Vector3>();
	private List<Vector3> vertices = new List<Vector3>();
	private Mesh mesh;

	void Awake()
	{
		mesh = new Mesh();
		mesh.name = "Procedural Line";
		GetComponent<MeshFilter>().mesh = mesh;
	}

	public override void AddPoint(Vector3 p)
	{
		base.AddPoint(p);
		if (curve.Count == 0)
		{
			GenerateInitialMesh(p);
			UpdateMesh();
		}
		else
		{
			var withinMinDistance = Vector3.Distance(curve[curve.Count - 1], p) < minDistance;
			if (useMinDistanceHeuristic && withinMinDistance)
			{
				return;
			}
			AddToMesh(p);
			UpdateMesh();
		}
	}

	private void AddToMesh(Vector3 p)
	{
		if (vertices.Count < 2)
		{
			Debug.LogError("Can't add to mesh until you've generated the inital vertices.");
			return;
		}
		curve.Add(p);
		var offset = Vector3.up * lineWidth / 2;
		vertices.Add(p + offset);
		vertices.Add(p - offset);
		var currHigh = vertices.Count - 2;
		var currLow = vertices.Count - 1;
		var prevLow = triangles[triangles.Count - 1].z;
		var prevHigh = triangles[triangles.Count - 1].y;
		// First Side 
		triangles.Add(new Vector3(prevLow, currHigh, prevHigh));
		triangles.Add(new Vector3(prevLow, currLow, currHigh));
		// Second Side
		triangles.Add(new Vector3(prevLow, prevHigh, currHigh));
		triangles.Add(new Vector3(prevLow, currHigh, currLow));
	}

	private void UpdateMesh()
	{
		mesh.vertices = vertices.ToArray();
		mesh.triangles = ToIntArray(triangles);
	}

	public static int[] ToIntArray(List<Vector3> tris)
	{
		var ret = new int[tris.Count * 3];
		for (var i=0; i<tris.Count; i++)
		{
			var v = tris[i];
			ret[3 * i] = (int) v.x;
			ret[(3 * i) + 1] = (int)v.y;
			ret[(3 * i) + 2] = (int)v.z;
		}
		return ret;
	}

	private void GenerateInitialMesh(Vector3 p)
	{
		curve.Add(p);
		var offset = Vector3.up * lineWidth / 2;
		vertices.Add(p - offset);
		vertices.Add(p + offset);
		vertices.Add(p - offset);
		vertices.Add(p + offset);
		triangles.Add(new Vector3(0, 1, 3));
		triangles.Add(new Vector3(0, 2, 3));
	}
}
