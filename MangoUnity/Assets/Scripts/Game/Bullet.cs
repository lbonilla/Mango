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
	private float speed = 15.0f;
#endregion

#region Properties
#endregion

// if this class inherits from MonoBehaviour remove constructor and deconstructor.
#region Constructors

//	Bullet(){ // constructor
//		// initialize object here
//	}
//	
//	~Bullet(){// destructor
//		// cleanup statements...
//	}
#endregion

#region Unity Methods

	// Use this for initialization
	void Start () {
		Destroy(this.gameObject, Random.Range(0.5f, 0.75f));
	}
	
	// Update is called once per frame
	void Update () {
		
		this.gameObject.transform.Translate (new Vector3(0, speed * Time.deltaTime, 0), Space.Self);
	}

#endregion

#region Game Methods
	public void SetRotation(float value){
		this.transform.Rotate(0, 0, value);
		//this.transform.Rotate(new Vector3(0, 0, 1), value);		
	}

    void OnTriggerEnter(Collider other) {
//		Debug.Log ("Destroy  missile");
		Destroy(this.gameObject);
		
		Destroy(other.gameObject);
				
//		Debug.Log(other.gameObject.name);
//	
//		if( other.gameObject.name != "p1m"){
//			DestroyObject (this.gameObject);
//		}
//
//		if(other.gameObject.GetComponent<Facility>() is Facility){
//			other.gameObject.GetComponent<Facility>().ReduceLife(destructionPower);
//		}
    }
	
#endregion

}
