using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// File: Missile
// Project:
// Description:
// Author:Esteban Padilla
// Email: 
// Copyright (C) 2013,  (R). All rights reserved.  

public class Missile : MonoBehaviour {
#region Enums
#endregion

#region Delegates
#endregion

#region Constants
#endregion

#region Public Variables
#endregion

#region Private Variables
	private float destructionPower = 7.0f;
	private float speed = 2.0f;
#endregion

#region Properties
	public float DestructionPower { get { return destructionPower; } set { destructionPower = value; } }
#endregion

#region Constructors
#endregion

#region Unity Methods

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//TODO: add animation 
		this.gameObject.transform.Translate (0, speed * Time.deltaTime, 0);	
	}

	void OnCollisionEnter(Collision collision) {
		GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>().PlayAudio("missionExplotion");
	}


    void OnTriggerEnter(Collider other) {
		GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>().PlayAudio("missionExplotion");
    }
#endregion

#region Game Methods
#endregion

}
