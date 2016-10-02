using UnityEngine;

public class FixPositionToHead : MonoBehaviour
{
	[SerializeField] private Transform head;
	[SerializeField] private Transform room;

	void LateUpdate ()
	{
		transform.position = head.position;
		room.localPosition = -head.localPosition;
	}
}
