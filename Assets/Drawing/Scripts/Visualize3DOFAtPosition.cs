using UnityEngine;

public class Visualize3DOFAtPosition : MonoBehaviour
{
	[SerializeField] private GameObject vis3DOFSrcGO;
	[SerializeField] private GameObject position3DOFSrcGO;
	private I3DOF visSrc;
	private I3DOF positionSrc;

	[SerializeField] private Transform start;
	[SerializeField] private Transform end;

	void Start ()
	{
		visSrc = vis3DOFSrcGO.GetComponent<I3DOF>();
		positionSrc = position3DOFSrcGO.GetComponent<I3DOF>();
	}
	
	void Update ()
	{
		var position = positionSrc.GetAxes();
		var vis = visSrc.GetAxes();
		start.position = position;
		end.position = position + vis;
	}
}
