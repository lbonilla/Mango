using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// File: SoundManager
// Project:
// Description:
// Author:Esteban Padilla
// Email: 
// Copyright (C) 2013,  (R). All rights reserved.  

public class SoundManager : MonoBehaviour {
#region Enums
#endregion

#region Delegates
#endregion

#region Constants
#endregion

#region Public Variables
	 private Dictionary<string, AudioSource> audioSources = new Dictionary<string, AudioSource>();
#endregion

#region Private Variables

#endregion

#region Properties
#endregion

// if this class inherits from MonoBehaviour remove constructor and deconstructor.
#region Constructors
#endregion

#region Unity Methods

	// Use this for initialization
	void Start () {
		
		AudioClip clip = Resources.Load("Audio/missileExplotion") as AudioClip; 
		audioSources["missionExplotion"] = gameObject.AddComponent<AudioSource>() as AudioSource;
		audioSources["missionExplotion"].loop = false;
		audioSources["missionExplotion"].clip = clip;
		
		AudioClip clip1 = Resources.Load("Audio/missileExplotion1") as AudioClip; 
		audioSources["missionExplotion1"] = gameObject.AddComponent<AudioSource>() as AudioSource;
		audioSources["missionExplotion1"].loop = false;
		audioSources["missionExplotion1"].clip = clip1;

		AudioClip clip2 = Resources.Load("Audio/missileExplotion1") as AudioClip; 
		audioSources["missionExplotion2"] = gameObject.AddComponent<AudioSource>() as AudioSource;
		audioSources["missionExplotion2"].loop = false;
		audioSources["missionExplotion2"].clip = clip2;


		AudioClip clip3 = Resources.Load("Audio/missileExplotion1") as AudioClip; 
		audioSources["missionExplotion3"] = gameObject.AddComponent<AudioSource>() as AudioSource;
		audioSources["missionExplotion3"].loop = false;
		audioSources["missionExplotion3"].clip = clip3;
	
		AudioClip clip4 = Resources.Load("Audio/missileExplotion1") as AudioClip; 
		audioSources["missionExplotion4"] = gameObject.AddComponent<AudioSource>() as AudioSource;
		audioSources["missionExplotion4"].loop = false;
		audioSources["missionExplotion4"].clip = clip4;
	}
	

#endregion

#region Game Methods
	public void PlayAudio(string value){
		audioSources[value].Play();
	}

	public void PlayExplotion(){	
		int value = (int)Random.Range(0 , 5);
		print(value);
		switch(value){
			case 0:
				audioSources["missionExplotion"].Play();
			break;
			case 1:
				audioSources["missionExplotion1"].Play();
			break;
			case 2:
				audioSources["missionExplotion2"].Play();
			break;
			case 3:
				audioSources["missionExplotion3"].Play();
			break;
			case 4:
				audioSources["missionExplotion4"].Play();
			break;
			default:
			break;
		}

	}

	private void PlayIt(AudioClip p_sound, bool p_loop) {
// 
// 		foreach (AudioSource audio in audioSources) // Look for free ones
// 		{
//  			if (!audio.isPlaying) // Check if it is free
//  			{
//			   audio.loop = p_loop;
//			   audio.clip = p_sound;
//			   audio.Play();
//			   return;
//		  }
//	 }
//
//	 audioSources.Add(gameObject.AddComponent<AudioSource>());  // Make a new one of none found.
//	 audioSources[audioSources.Count-1].loop = p_loop;
//	 audioSources[audioSources.Count-1].clip = p_sound;
//	 audioSources[audioSources.Count-1].Play();
	
	} 
#endregion

}
