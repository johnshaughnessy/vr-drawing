using UnityEngine;

public class WatsonScreenShotter : MonoBehaviour
{
	[SerializeField]
	private LayerMask screenshotCullingMask;
	[SerializeField]
	private LayerMask defaultCullingMask;
	[SerializeField]
	private CameraClearFlags screenshotClearFlags;
	[SerializeField]
	private CameraClearFlags defaultClearFlags;
	private Camera cam;
	private Color defaultBackgroundColor;

	void Awake()
	{
		cam = GetComponent<Camera>();
		defaultBackgroundColor = cam.backgroundColor;
	}

	public byte[] WatsonScreenShot(CaptureScreenshot.ImageFormat imageFormat)
	{
		cam.cullingMask = screenshotCullingMask;
		cam.clearFlags = screenshotClearFlags;
		cam.backgroundColor = Color.black;

		var bytes = CaptureScreenshot.Capture(cam, imageFormat);

		cam.cullingMask = defaultCullingMask;
		cam.clearFlags = defaultClearFlags;
		cam.backgroundColor = defaultBackgroundColor;

		return bytes;
	}

	public static string TargetDirectory(string className, bool pass)
	{
		var subDir = className + (pass ? "_positive_examples/" : "_negative_examples/");
		return System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop) + "/WatsonDatasets/" + subDir;
	}

	public static string ScreenShotName(CaptureScreenshot.ImageFormat format)
	{
		return Random.value + (format == CaptureScreenshot.ImageFormat.PNG ? ".png" : ".jpg");
	}
}
