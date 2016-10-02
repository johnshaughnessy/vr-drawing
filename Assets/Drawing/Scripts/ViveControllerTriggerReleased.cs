using UnityEngine;
using VRTK;

public class ViveControllerTriggerReleased : MonoBehaviour, IEvent
{
	public event Event ev;
	[SerializeField] private VRTK_ControllerEvents controller;
	void Start()
	{
		controller.TriggerReleased += (_, __) =>
		{
			if (ev != null)
			{
				ev();
			}
		};
	}

}
