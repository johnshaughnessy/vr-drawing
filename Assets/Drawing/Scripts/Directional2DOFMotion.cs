using UnityEngine;

public class Directional2DOFMotion : MonoBehaviour, I3DOF
{
	[SerializeField] private GameObject forward3DOF; // Stupid requirement to get an interface off the object
	[SerializeField] private GameObject right3DOF; 
	[SerializeField] private GameObject motion2DOF;

	private I3DOF forwardSrc;
	private I3DOF rightSrc;
	private I2DOF motionSrc;

	private Vector3 force;

	void Start()
	{
		forwardSrc = forward3DOF.GetComponent<I3DOF>();
		rightSrc = right3DOF.GetComponent<I3DOF>();
		motionSrc = motion2DOF.GetComponent<I2DOF>();
	}

	void Update()
	{
		var right = rightSrc.GetAxes();
		var forward = forwardSrc.GetAxes();
		var motion = motionSrc.GetAxes();
		force = Time.frameCount%2==0? right*motion.x : forward*motion.y;
	}

	public Vector3 GetAxes()
	{
		return force;
	}
}
