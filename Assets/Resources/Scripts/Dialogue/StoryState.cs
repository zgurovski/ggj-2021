using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryState : MonoBehaviour
{
	// Start is called before the first frame update
	public STORYSTATE currentState = STORYSTATE.BEGIN;

	public enum STORYSTATE
	{
		CINEMATIC_INTRO,
		BEGIN,
		FIRST_TALK_WITH_THE_ELDER
	};
}
