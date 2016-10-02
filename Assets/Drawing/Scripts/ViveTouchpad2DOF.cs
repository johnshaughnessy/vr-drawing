using UnityEngine;
using VRTK;

public interface I2DOF
{
	Vector2 GetAxes();
}

public class ViveTouchpad2DOF : MonoBehaviour, I2DOF
{
	[SerializeField] private VRTK_ControllerEvents controller;
	private Vector2 axes;

	void Update()
	{
		axes = controller.GetTouchpadAxis();
	}

	public Vector2 GetAxes()
	{
		return axes;
	}
}

