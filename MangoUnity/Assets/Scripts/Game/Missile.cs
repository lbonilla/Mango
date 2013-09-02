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
	public float curveSpeed = 5;
	public float curveRange = 1;
    public float speed = 0.0001f;
    private float fTime = 0;
	private float fSpeed = 0;
	private float randonDirection;
	private float destructionPower = 2f;
	//private Vector3 lastPos = Vector3.zero;
#endregion

#region Properties
	public float DestructionPower { get { return destructionPower; } set { destructionPower = value; } }
#endregion

#region Constructors
#endregion

#region Unity Methods

	// Use this for initialization
	void Start () {
		//lastPos = transform.position;
		curveSpeed = Random.Range(8, 10);
        curveRange = Random.Range(0.01f, 0.03f);
		speed = Random.Range(0.015f, 0.02f);
		randonDirection = Random.Range(0.1f, 0.3f);//scatters missiles on open range
	}
	
	// Update is called once per frame
	void Update () {

		//this.gameObject.transform.Translate (0, speed * Time.deltaTime, 0);	
 		//lastPos = transform.position;//to draw reference line
		
       	fTime += (Time.deltaTime * curveSpeed) * randonDirection;
		fSpeed += Time.deltaTime * speed;
	
       	Vector3 vSin = new Vector3((Mathf.Sin(fTime)* curveRange), fSpeed, 0);
   
       	//transform.position += vSin * Time.deltaTime;
		transform.Translate(vSin);
 
       	//Debug.DrawLine(lastPos, transform.position, Color.green, 100);
	}

	void OnCollisionEnter(Collision collision) {
		//GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>().PlayAudio("missionExplotion");
	}


    void OnTriggerEnter(Collider other) {
		GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>().PlayExplotion();
    }
#endregion

#region Game Methods
#endregion

}
