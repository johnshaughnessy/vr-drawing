using UnityEngine;

public class RotationController : MonoBehaviour
{
	[SerializeField] private GameObject rotation2DOFSrc;
	[SerializeField] private GameObject up3DOFSrc;
	[SerializeField] private GameObject right3DOFSrc;
	[SerializeField] private Transform t;
	[SerializeField] [Range(1.0f, 5.0f)] private float angularSpeed;

	private I2DOF rotation2DOF;
	private I3DOF up3DOF;
	private I3DOF right3DOF;

	void Awake()
	{
		rotation2DOF = rotation2DOFSrc.GetComponent<I2DOF>();
		up3DOF = up3DOFSrc.GetComponent<I3DOF>();
		right3DOF = right3DOFSrc.GetComponent<I3DOF>();
	}
	
	void Update ()
	{
		var rotation = rotation2DOF.GetAxes();
		var up = up3DOF.GetAxes();
		var right = right3DOF.GetAxes();
		t.rotation = Time.frameCount%2 == 0
			? Quaternion.AngleAxis(rotation.x * angularSpeed, up)*t.rotation
			: Quaternion.AngleAxis(rotation.y * angularSpeed, right)*t.rotation;
	}
}
