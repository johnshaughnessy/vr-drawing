using UnityEngine;

public interface I3DOF
{
	Vector3 GetAxes();
}

public class Transform3DOF : MonoBehaviour, I3DOF
{
	[SerializeField] private Transform t;
	public Vector3 GetAxes()
	{
		return t.forward;
	}
}
