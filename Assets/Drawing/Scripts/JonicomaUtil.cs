using System.Collections.Generic;
using UnityEngine;

public class JonicomaUtil : MonoBehaviour {
	private static readonly Dictionary<Color, string> Colors = new Dictionary<Color, string>()
	{
		{Color.blue, "blue"},
		{Color.green, "green"},
	}; 
	public static void LogColor(string msg, Color color)
	{
		var colorStr = Colors.ContainsKey(color) ? Colors[color] : "green";
		Debug.Log(string.Format("<color={0}>{1}</color>", colorStr, msg));
	}
}
