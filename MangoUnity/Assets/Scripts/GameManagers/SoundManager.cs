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
		
	}
	

#endregion

#region Game Methods
	public void PlayAudio(string value){
		audioSources[value].Play();
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
