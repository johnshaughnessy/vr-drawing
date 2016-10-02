using UnityEngine;
using VRTK;

public interface IEvent
{
	event Event ev;
}

public delegate void Event();

public class ViveControllerTriggerPressed : MonoBehaviour, IEvent
{
	public event Event ev;
	[SerializeField] private VRTK_ControllerEvents controller;

	void Start()
	{
		controller.TriggerPressed += (_, __) =>
		{
			if (ev != null)
			{
				ev();
			}
		};
	}
}
