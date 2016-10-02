using UnityEngine;

public class RotateAroundPoint : MonoBehaviour
{
	[SerializeField] private GameObject rotation1DOFSrcGO;
	[SerializeField] private GameObject point3DOFSrcGO;

	[SerializeField] private Transform t;
	[SerializeField] [Range(0.1f, 3.0f)] private float topAngularSpeed;

	private I1DOF rotationSrc;
	private I3DOF pointSrc;

	void Start()
	{
		rotationSrc = rotation1DOFSrcGO.GetComponent<I1DOF>();
		pointSrc = point3DOFSrcGO.GetComponent<I3DOF>();
	}

	void Update()
	{
		var point = pointSrc.GetAxes();
		var rotation = rotationSrc.GetAxis()*topAngularSpeed*10;
		t.RotateAround(point, Vector3.up, rotation);
	}


}
