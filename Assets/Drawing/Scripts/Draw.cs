using UnityEngine;
using System.Collections.Generic;

public enum Layer
{
	UserOnly = 8,
	CameraOnly = 9
}

public class Draw : MonoBehaviour
{
	[SerializeField]
	private Layer layer;
	[SerializeField]
	private GameObject VisibleLinePrefab;
	[SerializeField]
	private GameObject DrawingToolPrefab;
	private Line currLine;
	private List<Line> lines = new List<Line>();
	private GameObject debugDrawPoint;
	private DrawingTool3D drawingTool;
	private static readonly KeyCode drawKey = KeyCode.Mouse0;
	private static readonly List<KeyCode> eraseKeys = new List<KeyCode> { KeyCode.Mouse1, KeyCode.F, KeyCode.P };

	void Awake()
	{
		var line = Instantiate(VisibleLinePrefab).GetComponent<Line>();
		if (line == null)
		{
			Debug.LogError("Did not provide a visible line.");
		}
		DestroyImmediate(line.gameObject);
		drawingTool = Instantiate(DrawingToolPrefab).GetComponent<DrawingTool3D>();
		if (drawingTool == null)
		{
			Debug.LogError("Did not provide a drawing tool.");
		}
	}

	void Update()
	{
		foreach (var key in eraseKeys)
		{
			if (Input.GetKeyDown(key))
			{
				EraseIt();
			}
		}
		DrawIt();
		//ShowDebugDrawPoint();
	}

	private void EraseIt()
	{
		for (var i = 0; i < lines.Count; i++)
		{
			DestroyImmediate(lines[i].gameObject);
		}
		lines.Clear();
	}

	void DrawIt()
	{
		var startedDrawing = Input.GetKeyDown(drawKey);
		if (startedDrawing)
		{
			currLine = Instantiate(VisibleLinePrefab).GetComponent<Line>();
			currLine.gameObject.layer = (int)layer;
		}
		var isDrawing = Input.GetKey(drawKey);
		if (isDrawing)
		{
			currLine.AddPoint(drawingTool.GetDrawPoint());
		}
		var stoppedDrawing = Input.GetKeyUp(drawKey);
		if (stoppedDrawing)
		{
			lines.Add(currLine);
		}
	}

	private void ShowDebugDrawPoint()
	{
		if (!Input.GetKey(drawKey))
		{
			return;
		}
		if (debugDrawPoint == null)
		{
			debugDrawPoint = GameObject.CreatePrimitive(PrimitiveType.Sphere);
			debugDrawPoint.transform.localScale = Vector3.one * 0.5f;
		}
		debugDrawPoint.transform.position = drawingTool.GetDrawPoint();
	}
}
