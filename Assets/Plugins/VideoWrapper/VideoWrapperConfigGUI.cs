/* ========================================================================
 * PROJECT: Unity AR Tookit (UART)
 * ========================================================================
 *
 * (C) 2010 by Blair MacIntyer and Georgia Tech Research Corporation
 *
 * ========================================================================
 ** @author   Alex Hill (ahill@gatech.edu)
 *
 * This software is licensed for commercial use.
 *
 * For licensing and support contact Blair MacIntyer (blair@cc.gatech.edu)
 *
 * ========================================================================
 *
 * VideoWrapperConfigGUI.cs
 *
 * Usage: Add this script to the loading scene to select cameras
 * 
 *
 * Notes:
 *
 **********************************************************************************/
 
using UnityEngine;
using System.Collections;

public class VideoWrapperConfigGUI : MonoBehaviour
{
	
	//CHANGEABLE
	public static string DropDownEntry = "vc: 0 320x240 30 MJPG 0";
	#if UNITY_IPHONE
	public static bool WindowVisible = false;
	#else
	public static bool WindowVisible = true;
	#endif
		
	//CONSTANT
	private string LabelString = 
	"\t[lib]: [id] [Width](xHeight) [FPS] [PixelFormat] [Bigger] (opt args)\n" +
	"\n"+
	"\t [lib] -> Mac use qt, Windows should use vc\n";

	private Vector2 ListScrollPos;
	
	//We need to manually position our list, because the dropdown will appear over other controls
	private Rect windowRect = new Rect (50,150,500,120);
	
	private Rect LabelRect = new Rect(25, 50, 450, 55);
	private Rect DropDownRect = new Rect(25, 25, 450, 25);
	private bool DropdownVisible = false;

	private ArrayList MyListOfStuff; //Declare our list of stuff
	
	void Start()
	{
		if(WindowVisible == true)
		{	
			//SETUP the camera
			VideoCamera.Initialize();
			
			string[] properties = VideoCamera.getAvailablePropertyStrings();
			//MyListOfStuff = new List<string>(); //Initialize our list of stuff
			MyListOfStuff = new ArrayList(); //Initialize our list of stuff
			for (int i = 0; i < properties.Length; i++)//Fill it with some stuff
			{
				MyListOfStuff.Add(properties[i]);
			}
		}
	}

	void OnGUI()
	{

		GUILayout.FlexibleSpace();
		
		GUIStyle leftAlignedButton = new GUIStyle( GUI.skin.GetStyle( "Button" ) );
		leftAlignedButton.alignment = TextAnchor.UpperLeft;
		//Show the dropdown list if required (make sure any controls that should appear behind the list are before this block)
		if (DropdownVisible)
		{
			GUILayout.BeginArea(new Rect(DropDownRect.xMin, DropDownRect.yMin + DropDownRect.height, 450, 225), "", "box");
			if (MyListOfStuff.Count > 10) {
				 ListScrollPos = GUILayout.BeginScrollView(ListScrollPos, false, true);
			   GUILayout.BeginVertical(GUILayout.Width(220));
			} else {
			   GUILayout.BeginVertical();
			}
			for (int i = 0; i < MyListOfStuff.Count; i++)
			{
					if (GUILayout.Button((string)MyListOfStuff[i],leftAlignedButton))
					{
						DropDownEntry = (string)MyListOfStuff[i];//Turn on the item we clicked
						DropdownVisible = false; //Hide the list
					}
			}
			GUILayout.EndVertical();
			if (MyListOfStuff.Count > 10) {
			   GUILayout.EndScrollView();
			}
			GUILayout.EndArea();
		}
		//Draw the label
		if(!DropdownVisible)
		{
			GUILayout.BeginArea(LabelRect, "", "box");
			GUILayout.BeginHorizontal();
			GUILayout.Label(LabelString);
			GUILayout.EndHorizontal();
			GUILayout.EndArea();
		}
		//Draw the dropdown control
		GUILayout.BeginArea(DropDownRect, "", "box");
		GUILayout.BeginHorizontal();
		string ButtonText = (DropdownVisible) ? "<<" : ">>";
		//DropDownEntry = GUILayout.TextField(DropDownEntry);
		GUILayout.Label(DropDownEntry);
		DropdownVisible = GUILayout.Toggle(DropdownVisible, ButtonText, "button", GUILayout.Width(32), GUILayout.Height(20));
		GUILayout.EndHorizontal();
		GUILayout.EndArea();

	}	
}