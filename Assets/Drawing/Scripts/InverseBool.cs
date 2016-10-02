using UnityEngine;

class InverseBool : MonoBehaviour, IBool
{
	[SerializeField] private GameObject origSrcGO;
	private IBool origSrc;
	void Start()
	{
		origSrc = origSrcGO.GetComponent<IBool>();
	}

	public bool GetBool()
	{
		return !origSrc.GetBool();
	}
}
