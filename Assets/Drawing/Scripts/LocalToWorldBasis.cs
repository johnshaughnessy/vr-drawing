using System;
using JetBrains.Annotations;
using UnityEngine;

public interface IBool
{
	bool GetBool();
}

public struct Basis
{
	public Vector3 up;
	public Vector3 right;
	public Vector3 forward;

	public Basis(Vector3 up, Vector3 right, Vector3 forward)
	{
		this.up = up;
		this.right = right;
		this.forward = forward;
	}
}

public interface IBasis
{
	Basis GetBasis();
}

public class LocalToWorldBasis : MonoBehaviour, IBasis
{
	[SerializeField] private GameObject localUp3DOFSrc;
	[SerializeField] private GameObject localRight3DOFSrc;
	[SerializeField] private GameObject localForward3DOFSrc;
	[SerializeField] private GameObject isLocalBoolSrc;

	private I3DOF upSrc;
	private I3DOF rightSrc;
	private I3DOF forwardSrc;
	private IBool isLocalSrc;

	private Basis output;

	void Start()
	{
		upSrc = localUp3DOFSrc.GetComponent<I3DOF>();
		rightSrc = localRight3DOFSrc.GetComponent<I3DOF>();
		forwardSrc = localForward3DOFSrc.GetComponent<I3DOF>();
		isLocalSrc = isLocalBoolSrc.GetComponent<IBool>();
	}

	void Update()
	{
		var forward = forwardSrc.GetAxes();
		var up = upSrc.GetAxes();
		var right = rightSrc.GetAxes();
		var isLocal = isLocalSrc.GetBool();

		output.right = isLocal ? right : Vector3.right;
		output.up = isLocal ? up : Vector3.up;
		output.forward = isLocal ? forward : Vector3.forward;
	}

	public Basis GetBasis()
	{
		return output;
	}
}

