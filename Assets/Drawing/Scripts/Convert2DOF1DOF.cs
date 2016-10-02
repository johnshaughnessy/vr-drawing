using UnityEngine;

public enum Axis
{
	X,
	Y,
	Z
}

public class Convert2DOF1DOF : MonoBehaviour, I1DOF
{
	[SerializeField] private GameObject src2DOFGO;
	private I2DOF src;
	[SerializeField] private Axis axis;
	private float val;

	void Start()
	{
		src = src2DOFGO.GetComponent<I2DOF>();
	}

	void Update()
	{
		val = axis == Axis.X ? src.GetAxes().x : src.GetAxes().y;
	}

	public float GetAxis()
	{
		return val;
	}
}
