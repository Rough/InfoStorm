using UnityEngine;
using System.Collections;

public class InfoStormConfigGUI : MonoBehaviour
	{
	public static string hashTag = "default";

	void OnGUI()
		{
		GUILayout.BeginArea(new Rect(50, 120, Screen.width, 100));
		hashTag = GUILayout.TextField(hashTag, GUILayout.MaxWidth(200));
		if (GUILayout.Button("Start InfoStorm", GUILayout.MaxWidth(100)))
			Application.LoadLevel("SingleMarkerDemo");
		GUILayout.EndArea();
		}
	}