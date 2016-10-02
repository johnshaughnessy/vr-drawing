using UnityEngine;

public class Square3DOF : MonoBehaviour , I3DOF
{
	[SerializeField] private GameObject src3DOFGO;
	private I3DOF src;

	void Start()
	{
		src = src3DOFGO.GetComponent<I3DOF>();
	}

	public Vector3 GetAxes()
	{
		var axes = src.GetAxes();
		return axes*axes.sqrMagnitude;
	}
	
}
