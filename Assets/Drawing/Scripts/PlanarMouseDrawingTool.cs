using UnityEngine;

public interface DrawingTool3D
{
	Vector3 GetDrawPoint();
}

public class PlanarMouseDrawingTool : MonoBehaviour, DrawingTool3D {
	[SerializeField] private LayerMask drawingMask;

	private Vector3 prevPoint = Vector3.zero;
	public Vector3 GetDrawPoint()
	{
		var mousePos3D = Input.mousePosition;
		mousePos3D.z = 10;
		var ray = Camera.main.ScreenPointToRay(mousePos3D);
		RaycastHit hit;
		if (Physics.Raycast(ray, out hit, 100.0f, (int) drawingMask, QueryTriggerInteraction.Collide))
		{
			prevPoint = hit.point + (Vector3.up* 0.1f);
		}
		return prevPoint;
	}
}
