using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// File: Bullet
// Project:
// Description:
// Author:Esteban Padilla
// Email: 
// Copyright (C) 2013,  (R). All rights reserved.  

public class Bullet : MonoBehaviour {
#region Enums
#endregion

#region Delegates
#endregion

#region Constants
#endregion

#region Public Variables
#endregion

#region Private Variables
	private float destructionPower = 3.0f;
	private float speed = 30.0f;
#endregion

#region Properties
#endregion

#region Constructors
#endregion

#region Unity Methods

	// Use this for initialization
	void Start () {
		Destroy(this.gameObject, Random.Range(0.25f, 0.5f));
	}
	
	// Update is called once per frame
	void Update () {
		this.gameObject.transform.Translate (new Vector3(0, speed * Time.deltaTime, 0), Space.Self);
	}

#endregion

#region Game Methods
	public void SetRotation(float value){
		this.transform.Rotate(0, 0, value);
	}

    void OnTriggerEnter(Collider other) {
		Destroy(this.gameObject);
		Destroy(other.gameObject);
    }
#endregion
}
