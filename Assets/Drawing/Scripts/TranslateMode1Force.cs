using UnityEngine;

public interface I1DOF
{
	float GetAxis();
}

public class TranslateMode1Force : MonoBehaviour, I3DOF
{
	[SerializeField] private GameObject x1DOFSrcGO;
	[SerializeField] private GameObject y1DOFSrcGO;
	[SerializeField] private GameObject z1DOFSrcGO;

	private I1DOF xTranslationSrc;
	private I1DOF yTranslationSrc;
	private I1DOF zTranslationSrc;

	private Vector3 force;

	void Start ()
	{
		zTranslationSrc = z1DOFSrcGO.GetComponent<I1DOF>();
		xTranslationSrc = x1DOFSrcGO.GetComponent<I1DOF>();
		yTranslationSrc = y1DOFSrcGO.GetComponent<I1DOF>();
	}
	
	void Update ()
	{
		var x = xTranslationSrc.GetAxis(); 
		var y = yTranslationSrc.GetAxis(); 
		var z = zTranslationSrc.GetAxis(); 
		force = x*Vector3.right + y*Vector3.up + z*Vector3.forward;
	}

	public Vector3 GetAxes()
	{
		return force;
	}
}
