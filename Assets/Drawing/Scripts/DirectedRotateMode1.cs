using UnityEngine;

public class DirectedRotateMode1 : MonoBehaviour
{
	[SerializeField] private GameObject rotation1DOFSrcGO;
	[SerializeField] private Transform t;
	[SerializeField] [Range(0.1f, 3.0f)] private float topAngularSpeed;

	[SerializeField] private Transform headMirror;

	private I1DOF rotationSrc;

	void Start()
	{
		rotationSrc = rotation1DOFSrcGO.GetComponent<I1DOF>();
	}

	void Update()
	{
		t.RotateAround(headMirror.position, Vector3.up, rotationSrc.GetAxis()*topAngularSpeed*20);
	}


}
