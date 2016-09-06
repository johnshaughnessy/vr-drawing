using System;
using System.IO;
using UnityEngine;
using VRTK;

[RequireComponent(typeof(VRTK_ControllerEvents))]
public class DatasetBuilder : MonoBehaviour
{
	public event Action AddedPositiveExample;
	public event Action AddedNegativeExample;

	[SerializeField]
	private string className;
	[SerializeField]
	private WatsonScreenShotter screenShotter;

	private static readonly CaptureScreenshot.ImageFormat format = CaptureScreenshot.ImageFormat.JPG;

	void Awake()
	{
		var events = GetComponent<VRTK_ControllerEvents>();
		events.TouchpadPressed += AddToDataset;
	}

	private void AddToDataset(object sender, ControllerInteractionEventArgs e)
	{
		var up = e.touchpadAxis.y > 0;
		var dir = WatsonScreenShotter.TargetDirectory(className, up);
		var filename = WatsonScreenShotter.ScreenShotName(format);
		var screenshot = screenShotter.WatsonScreenShot(format);
		if (!Directory.Exists(dir))
		{
			Directory.CreateDirectory(dir);
		}
		File.WriteAllBytes(dir + filename, screenshot);

		Debug.Log("Added " + (up ? "positive" : "negative") + " example to " + className + " dataset.");
		var ev = up ? AddedPositiveExample : AddedNegativeExample;
		if (ev != null) { ev(); }
	}
}
