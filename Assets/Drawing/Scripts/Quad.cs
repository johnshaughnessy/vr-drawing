using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class Quad : MonoBehaviour
{
	public event System.Action DidIt;
	private Mesh mesh;
	private Vector3[] vertices = new Vector3[4];
	private List<Vector3> triangles = new List<Vector3>();

	private Vector3? left1;
	private Vector3? left2;
	private Vector3? right1;
	private Vector3? right2;

	private bool youHave;

	void Awake()
	{
		mesh = new Mesh();
		GetComponent<MeshFilter>().mesh = mesh;
	}

	public void AddVertex(bool isLeft, Vector3 v)
	{
		if (isLeft)
		{
			if (left1 == null)
			{
				left1 = v;
			}
			else if (left2 == null)
			{
				left2 = v;
			}
		}
		else
		{
			if (right1 == null)
			{
				right1 = v;
			}
			else if (right2 == null)
			{
				right2 = v;
			}
		}
	}

	void Update()
	{
		if (IsReady() && !youHave)
		{
			BuildTheMesh();
			youHave = true;
			if (DidIt != null)
			{
				DidIt();
			}
		}
	}

	private bool IsReady()
	{
		return left1 != null 
			&& left2 != null 
			&& right1 != null
			&& right2 != null;
	}

	private void BuildTheMesh()
	{
		vertices = new Vector3[] {
			(Vector3) left1,
			(Vector3) left2,
			(Vector3) right1,
			(Vector3) right2
		};
		triangles = new List<Vector3>();
		triangles.Add(new Vector3(0,1,2));
		triangles.Add(new Vector3(0,2,1));
		triangles.Add(new Vector3(1,2,3));
		triangles.Add(new Vector3(1,3,2));

		mesh.vertices = vertices;
		mesh.triangles = VisibleLineWithProceduralMesh.ToIntArray(triangles);
	}
}
