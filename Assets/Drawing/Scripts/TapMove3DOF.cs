using UnityEngine;

public class TapMove3DOF : MonoBehaviour , I3DOF
{
	[SerializeField] private GameObject move3DOFSrcGO;
	[SerializeField] private GameObject tapDownEventSrcGO;
	[SerializeField] private GameObject tapUpEventSrcGO;

	private I3DOF moveSrc;
	private IEvent tapDownSrc;
	private IEvent tapUpSrc;

	private Vector3 startPoint;
	private Vector3 endPoint;
	private bool isDrawing;

	void Start()
	{
		moveSrc = move3DOFSrcGO.GetComponent<I3DOF>();
		tapDownSrc = tapDownEventSrcGO.GetComponent<IEvent>();
		tapUpSrc = tapUpEventSrcGO.GetComponent<IEvent>();
		tapDownSrc.ev += () =>
		{
			isDrawing = true;
			startPoint = moveSrc.GetAxes();
		};
		tapUpSrc.ev += () =>
		{
			isDrawing = false;
			endPoint = startPoint;
		};
	}

	void Update()
	{
		if (isDrawing)
		{
			endPoint = moveSrc.GetAxes();
		}
	}

	public Vector3 GetAxes()
	{
		return endPoint - startPoint;
	}
}
