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
	public float CurveSpeed = 5;
	public float CurveRange = 1;
    public float MoveSpeed = 0.0001f;
    private float fTime = 0;
	private float fSpeed = 0;
    private Vector3 lastPos = Vector3.zero;
	private float randonDirection;

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
		lastPos = transform.position;
		CurveSpeed = Random.Range(8, 10);
        CurveRange = Random.Range(0.01f, 0.03f);
		MoveSpeed = Random.Range(0.02f, 0.04f);
		randonDirection = Random.Range(0.1f, 0.3f);

	}
	
	// Update is called once per frame
	void Update () {
		//TODO: add animation 
		//this.gameObject.transform.Translate (0, speed * Time.deltaTime, 0);	
 		lastPos = transform.position;
		
       	fTime += (Time.deltaTime * CurveSpeed) * randonDirection;
		fSpeed += Time.deltaTime * MoveSpeed;
	
       	Vector3 vSin = new Vector3((Mathf.Sin(fTime)* CurveRange), fSpeed, 0);
   
       	//transform.position += vSin * Time.deltaTime;
		transform.Translate(vSin);
 
       	Debug.DrawLine(lastPos, transform.position, Color.green, 100);
	}

	void OnCollisionEnter(Collision collision) {
		
		//GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>().PlayAudio("missionExplotion");
	}


    void OnTriggerEnter(Collider other) {
		GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>().PlayAudio("missionExplotion");
    }
#endregion

#region Game Methods
#endregion

}
