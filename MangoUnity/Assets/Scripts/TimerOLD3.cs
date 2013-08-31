using UnityEngine;
using System.Collections;

// File:Timer.cs
// Project: 
// Description: This class manages the game time.
// Author: Esteban Padilla
// Email: ep@estebanpadilla.com
// Copyright (C) 2013, Ludusy (R). All rights reserved. 

public class TimerOLD3 : MonoBehaviour {
	
#region Public Variables	
	public GUIText timerTime;
	public GUIText initialTimeText;
	public GUIText secondsText;
	public GUIText msjText;
#endregion
	
#region Private Variables
	private float initialTime, currentTime, gameTime, playingTime = 1;
	public int timerLimit = 5;
	public int seconds;
	private bool play = false;
	private bool isTimeReach = false;

	private int startTime=0;
	private int timePass = 0;
#endregion
	
#region Properties
#endregion
	
#region Constructors
#endregion
	
#region Unity Methods

	void OnGUI(){
		if(GUI.Button(new Rect(100, 100, 100, 50), "play")){
			Play();
		}

		if(GUI.Button(new Rect(100, 300, 100, 50), "restart")){
			Restart();
		}

	}


	void Awake () {

	}
	
	/// <summary>
	/// Elapsed time
	/// </summary>
	void Update(){
		
		guiText.text = "TIME: " + (int)(Time.time);
		initialTimeText.text = "Initial Time: " + (int)initialTime;
		secondsText.text = "Seconds: " + seconds;

		if(!play)
		{
			//Add comment
			return;
		}

		if( play ){
			//inGameManager.GameTime = Time.time - initialTime;
			seconds = (int)(Time.time - initialTime);	
			
		}
		
		if(seconds == timerLimit){
			Complete();
		}
	}	

#endregion
	
#region Game Methods
	private void Complete(){
		play = false;
		msjText.text = "Time reached";
		Play();
	}
	
	public void Play(){
		play = true;
		seconds = 0;	
		initialTime = Time.time;
		msjText.text = "counting";		
	}
		
	public void Restart(){

	}

#endregion
}
