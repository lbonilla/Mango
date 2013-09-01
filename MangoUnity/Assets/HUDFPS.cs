﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// File: HUDFPS
// Project:
// Description:
// Author:Esteban Padilla
// Email: 
// Copyright (C) 2013,  (R). All rights reserved.  

// Attach this to a GUIText to make a frames/second indicator.
// It calculates frames/second over each updateInterval,
// so the display does not keep changing wildly.
// It is also fairly accurate at very low FPS counts (<10).
// We do this not by simply counting frames per interval, but
// by accumulating FPS for each frame. This way we end up with
// correct overall FPS even if the interval renders something like
// 5.5 frames.

public class HUDFPS : MonoBehaviour {
#region Enums
#endregion

#region Delegates
#endregion

#region Constants
#endregion

#region Public Variables
	public  float updateInterval = 0.5F;
#endregion

#region Private Variables
	private float accum   = 0; // FPS accumulated over the interval
	private int   frames  = 0; // Frames drawn over the interval
	private float timeleft; // Left time for current interval
#endregion

#region Properties
#endregion


#region Constructors

#endregion

#region Unity Methods

	// Use this for initialization
	void Start () {
	    if( !guiText ){
	        Debug.Log("UtilityFramesPerSecond needs a GUIText component!");
	        enabled = false;
	        return;
	    }

	    timeleft = updateInterval; 	
	}
	
	// Update is called once per frame
	void Update () {
	    timeleft -= Time.deltaTime;
	    accum += Time.timeScale/Time.deltaTime;
	    ++frames;
	 
	    // Interval ended - update GUI text and start new interval
	    if( timeleft <= 0.0 ){
		     // display two fractional digits (f2 format)
			float fps = accum/frames;
			string format = System.String.Format("{0:F2} FPS",fps);
			guiText.text = format;
		 
			if(fps < 30) {
				guiText.material.color = Color.yellow;
			} else {
				if(fps < 10) {
					guiText.material.color = Color.red;
				}else{
					guiText.material.color = Color.green;
				}
			//DebugConsole.Log(format,level);
	        timeleft = updateInterval;
	        accum = 0.0F;
	        frames = 0;
			}
	    }
	}

#endregion

#region Game Methods
#endregion

}
