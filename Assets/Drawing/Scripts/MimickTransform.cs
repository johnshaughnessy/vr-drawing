using UnityEngine;

public class MimickTransform : MonoBehaviour
{
	[SerializeField] private Transform target;
	void Update ()
	{
		transform.position = target.transform.position;
		transform.rotation = target.transform.rotation;
		transform.localScale = target.transform.localScale;
	}
}
