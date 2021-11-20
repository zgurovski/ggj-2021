using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryState : MonoBehaviour
{
	// Start is called before the first frame update
	public STORYSTATE currentState = STORYSTATE.CINEMATIC_INTRO;

	public enum STORYSTATE
	{
		CINEMATIC_INTRO,
		FIRST_TALK_WITH_THE_ELDER
	};
}
