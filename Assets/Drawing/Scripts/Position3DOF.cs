using UnityEngine;

public class Position3DOF : MonoBehaviour, I3DOF
{
	[SerializeField] private Transform target;
	[SerializeField] private bool isLocal;
	public Vector3 GetAxes()
	{
		return isLocal ? target.localPosition : target.position;
	}
}
