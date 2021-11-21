using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(AudioSource))]
public class AudioPlayer : MonoBehaviour {

	public AudioItem[] AudioList;
	private AudioSource source;
	private float musicVolume = 1f; //global volume multiplier
	private float sfxVolume = 1f; //global volume multiplier

	void Awake(){
		GlobalAudioPlayer.audioPlayer = this;
		source = GetComponent<AudioSource>();

		//set settings
		GameSettings settings = Resources.Load("GameSettings", typeof(GameSettings)) as GameSettings;
		if(settings != null){
			musicVolume = settings.MusicVolume;
			sfxVolume = settings.SFXVolume;
		}
	}

	public void playSFX(string name){
		//create a separate gameobject designated for playing music
		GameObject music = new GameObject();
		music.name = name;
		AudioSource AS = music.AddComponent<AudioSource>();

		//get music track from audiolist
		foreach (AudioItem s in AudioList)
		{
			if (s.name == name)
			{
				AS.clip = s.clip[0];
				AS.loop = false;
				AS.volume = s.volume * sfxVolume;
				AS.Play();
			}
		}
	}

	AudioSource backgroundMusicSource = null;
	public void playMusic(string name) {

		//create a separate gameobject designated for playing music
		GameObject music = new GameObject();
		music.name = name;

		if (backgroundMusicSource) {
			StartCoroutine(fadeAudioSource(backgroundMusicSource, backgroundMusicSource.volume, 0, .5f, 0));
		}

		AudioSource AS = music.AddComponent<AudioSource>();
		//get music track from audiolist
		foreach(AudioItem s in AudioList){
			if(s.name == name) {
				AS.clip = s.clip[0];
				AS.loop = true;

				StartCoroutine(fadeAudioSource(AS, 0, s.volume * musicVolume, 1f, 0.25f));
			}
		}
		backgroundMusicSource = AS;
	}


	IEnumerator fadeAudioSource(AudioSource audioSource, float volumeFrom, float volumeTo, float fadeDuration, float delay) {
		yield return new WaitForSeconds(delay);

		audioSource.volume = volumeFrom;
		if (volumeFrom < 0.01) {
			audioSource.Play();
		}

		var stepSize = (volumeTo - volumeFrom) / 5;
		var sleepTime = fadeDuration / 5;
		for (int i = 1; i <= 5; i++) {
			audioSource.volume = audioSource.volume + stepSize;
			yield return new WaitForSeconds(delay);
		}

		if (audioSource.volume < 0.01) {
			GameObject.Destroy(audioSource);
		}
	}
}
