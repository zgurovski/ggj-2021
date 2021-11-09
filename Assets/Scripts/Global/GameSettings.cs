using System.Collections.Generic;
using UnityEngine;

public class GameSettings : ScriptableObject
{
	[Header("Application Settings")]
	public int framerate = 60;
	public float timeScale = 1f;

	[Header("Combat Settings")]
	// The maximum number of enemies that can attack the player simultaneously 
	public int MaxAttackers = 3;
}
