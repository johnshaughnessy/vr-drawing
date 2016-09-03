using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CaptureScreenshot : MonoBehaviour
{
	public enum ImageFormat
	{
		PNG,
		JPG
	}

	public static byte[] Capture(Camera cam, ImageFormat format, int resWidth=1024, int resHeight=1024)
	{
		var rt = new RenderTexture(resWidth, resHeight, 24);
		cam.targetTexture = rt;
		var screenShot = new Texture2D(resWidth, resHeight, TextureFormat.RGB24, false);
		cam.Render();
		RenderTexture.active = rt;
		screenShot.ReadPixels(new Rect(0, 0, resWidth, resHeight), 0, 0);
		cam.targetTexture = null;
		RenderTexture.active = null; //http://answers.unity3d.com/questions/22954/how-to-save-a-picture-take-screenshot-from-a-camer.html
		Destroy(rt);
		return format == ImageFormat.PNG ? screenShot.EncodeToPNG() : screenShot.EncodeToJPG();
	}
}
