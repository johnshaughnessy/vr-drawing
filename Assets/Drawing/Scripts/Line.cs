using UnityEngine;
using System.Collections.Generic;

public abstract class Line : MonoBehaviour
{
	protected List<Vector3> points = new List<Vector3>();

	public virtual void AddPoint(Vector3 p)
	{
		points.Add(p);
	}
}


