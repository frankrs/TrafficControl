using UnityEngine;
using UnityEditor;
using System.Collections;

public class ResetKeys : EditorWindow {

	[MenuItem("Custom/ResetKeys")]

	public static void  ShowWindow () {
		EditorWindow.GetWindow(typeof(ResetKeys));
	}
	
	void OnGUI () {
		if(GUI.Button(new Rect(50,50,150,50),"ResetKeys")){
			PlayerPrefs.DeleteAll();
		}
	}

}
