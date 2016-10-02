using UnityEngine;

public class Square1DOF : MonoBehaviour, I1DOF
{
	[SerializeField] private GameObject src1DOFGO;
	private I1DOF src;

	[SerializeField] private bool preserveSign;

	void Start()
	{
		src = src1DOFGO.GetComponent<I1DOF>();
	}

	public float GetAxis()
	{
		var input = src.GetAxis();
		var output = Mathf.Pow(input, 2);
		output = preserveSign && input < 0 ? -output : output;
		return output;
	}
}
