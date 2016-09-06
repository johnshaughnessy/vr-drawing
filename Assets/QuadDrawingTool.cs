using UnityEngine;
using VRTK;
using System.Collections.Generic;

public class QuadDrawingTool : MonoBehaviour
{
	[SerializeField]
	private VRTK_ControllerEvents leftController;
	[SerializeField]
	private VRTK_ControllerEvents rightController;
	private List<VRTK_ControllerEvents> controllers;

	[SerializeField]
	private GameObject vertexPrefab;
	private GameObject leftPreview;
	private GameObject rightPreview;

	[SerializeField]
	private GameObject quadPrefab;
	private Quad quad;

	void Start()
	{
		quad = Instantiate(quadPrefab).GetComponent<Quad>();
		quad.DidIt += MakeANewQuad;

		controllers = new List<VRTK_ControllerEvents> { leftController, rightController };
		foreach (var controller in controllers)
		{
			controller.TouchpadTouchStart += (sender, _) => { SetPreviewActive(sender, true); };
			controller.TouchpadReleased += (sender, _) => { SetPreviewActive(sender, false); }; ;
			controller.TouchpadPressed += PlaceVertex;
		}

		leftPreview = Instantiate(vertexPrefab, leftController.transform) as GameObject;
		leftPreview.transform.localPosition = Vector3.zero;
		leftPreview.SetActive(false);

		rightPreview = Instantiate(vertexPrefab, rightController.transform) as GameObject;
		rightPreview.transform.localPosition = Vector3.zero;
		rightPreview.SetActive(false);
	}

	private void MakeANewQuad()
	{
		quad.DidIt -= MakeANewQuad;

		quad = Instantiate(quadPrefab).GetComponent<Quad>();
		quad.DidIt += MakeANewQuad;
	}

	private void PlaceVertex(object sender, ControllerInteractionEventArgs e)
	{
		var events = (VRTK_ControllerEvents)sender;
		var vertex = Instantiate(vertexPrefab) as GameObject;
		vertex.transform.position = events.transform.position;

		quad.AddVertex(sender == leftController, vertex.transform.position);
	}

	private void SetPreviewActive(object sender, bool active)
	{
		if (sender == leftController)
		{
			leftPreview.SetActive(active);
		}
		else if (sender == rightController)
		{
			rightPreview.SetActive(active);
		}
	}
}
