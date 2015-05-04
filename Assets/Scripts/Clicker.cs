using UnityEngine;
using System.Collections;

public class Clicker : MonoBehaviour {

	public AudioClip click;

	public void PlayClick(){
		if(StaticClasses.muteFX == false){
		audio.PlayOneShot(click);
		}
	}
}
