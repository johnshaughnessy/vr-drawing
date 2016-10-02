using UnityEngine;

public class BasisProxy : MonoBehaviour
{

	[SerializeField] private GameObject basisSrcGO;
	private IBasis basisSrc;

	[SerializeField] private Transform up;
	[SerializeField] private Transform right;
	[SerializeField] private Transform forward; 

	void Start ()
	{
		basisSrc = basisSrcGO.GetComponent<IBasis>();
	}
	
	void Update ()
	{
		var basis = basisSrc.GetBasis();
		up.forward = basis.up;
		right.forward = basis.right;
		forward.forward = basis.forward;
	}
}
