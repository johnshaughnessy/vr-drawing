using UnityEngine;

public class TranslationController : MonoBehaviour
{
	[SerializeField] private GameObject velocity3DOFSrcGO;
	private I3DOF velocitySrc;
	[SerializeField] private Rigidbody rigidbody;
	[SerializeField] [Range(0.0f, 200.0f)] private float topSpeed;
	[SerializeField] private bool forceIsLocal;

	void Start()
	{
		velocitySrc = velocity3DOFSrcGO.GetComponent<I3DOF>();
	}

	void Update ()
	{
		Debug.DrawLine(transform.position, transform.position + velocitySrc.GetAxes(), Color.blue);
		var velocity = velocitySrc.GetAxes() * topSpeed;
		if (forceIsLocal)
		{
			velocity = rigidbody.transform.rotation*velocity;
		}
		rigidbody.velocity = velocity;
	}
}
