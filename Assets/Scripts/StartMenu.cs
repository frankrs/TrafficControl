using UnityEngine;
using System.Collections;

public class StartMenu : MonoBehaviour {

	public void LoadLevel (string name){
		Application.LoadLevel(name);
	}
	public void QuitRequest(){
		print ("quit requested");
		Application.Quit ();
		}
	void Start () {
	
	}
	

	void Update () {
	
	}
}


[System.Serializable]
public class StartMenuElements {

}