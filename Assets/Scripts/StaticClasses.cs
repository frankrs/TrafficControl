using UnityEngine;
using System.Collections;

public static class StaticClasses {
	public static bool mute = false;
	public static bool muteFX = false;
	public static GameMode gameMode;
}

[System.Serializable]
public enum GameMode {normal,random};