using UnityEngine;
using VRTK;
using System.Collections.Generic;

[RequireComponent(typeof(VRTK_ControllerEvents))]
public class ViveControllerDrawingTool: MonoBehaviour, DrawingTool3D
{
	private VRTK_ControllerEvents events;
	[SerializeField]
	private Layer layer;
	[SerializeField]
	private GameObject VisibleLinePrefab;

	private Line currLine;
	private List<Line> lines = new List<Line>();
	private GameObject debugDrawPoint;
	private bool isDrawing;
	void Awake()
	{
		RequireLine();

		events = GetComponent<VRTK_ControllerEvents>();
		events.TouchpadPressed += DrawStart;
		events.TouchpadReleased += DrawEnd;
		events.TriggerPressed += EraseDrawing;
	}

	private void RequireLine()
	{
		var line = Instantiate(VisibleLinePrefab).GetComponent<Line>();
		if (line == null)
		{
			Debug.LogError("Did not provide a visible line.");
			DestroyImmediate(this);
		}
		DestroyImmediate(line.gameObject);
	}

	private void EraseDrawing(object sender, ControllerInteractionEventArgs e)
	{
		EraseIt();
	}

	private void DrawStart(object sender, ControllerInteractionEventArgs e)
	{
		isDrawing = true;
		currLine = Instantiate(VisibleLinePrefab).GetComponent<Line>();
		currLine.gameObject.layer = (int)layer;
	}

	public void EraseIt()
	{
		for (var i = 0; i < lines.Count; i++)
		{
			DestroyImmediate(lines[i].gameObject);
		}
		lines.Clear();
	}

	private void DrawEnd(object sender, ControllerInteractionEventArgs e)
	{
		isDrawing = false;
		lines.Add(currLine);
	}

	void Update()
	{
		if (isDrawing)
		{
			currLine.AddPoint(GetDrawPoint());
		}
	}

	public Vector3 GetDrawPoint()
	{
		return transform.position;
	}
}
