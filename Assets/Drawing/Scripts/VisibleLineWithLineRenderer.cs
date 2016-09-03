using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class VisibleLineWithLineRenderer : Line
{
	[SerializeField] [Range(0.001f, 0.1f)] private float lineWidth;
	private LineRenderer rend;

	void Awake()
	{
		rend = gameObject.GetComponent<LineRenderer>();
		rend.SetVertexCount(100); // ... this gets reset all the time so.....
		rend.SetWidth(lineWidth, lineWidth);
	}

	public override void AddPoint(Vector3 p)
	{
		base.AddPoint(p);
		rend.SetVertexCount(points.Count);
		rend.SetPosition(points.Count-1, p);
	}
}
