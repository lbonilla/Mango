using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// File: Move
// Project:
// Description:
// Author:Esteban Padilla
// Email: 
// Copyright (C) 2013,  (R). All rights reserved.  

public class Move : MonoBehaviour {
#region Enums
#endregion

#region Delegates
#endregion

#region Constants
#endregion

#region Public Variables
	public float CurveSpeed = 5;
	public float CurveRange = 1;
    public float MoveSpeed = 1;
    private float fTime = 0;
	private float fSpeed = 0;
    private Vector3 lastPos = Vector3.zero;
	private float randonDirection;
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
	 	lastPos = transform.position;
        CurveRange = Random.Range(2, 5);
		MoveSpeed = Random.Range(8, 10);
		randonDirection = Random.Range(0.1f, 1f);
	}
	
	// Update is called once per frame
	void Update () {
	    lastPos = transform.position;
		
       	fTime += (Time.deltaTime * CurveSpeed) * randonDirection;
		fSpeed += Time.deltaTime * MoveSpeed;
	
       	Vector3 vSin = new Vector3((Mathf.Sin(fTime)* CurveRange), fSpeed, 0);
   
       	transform.position += vSin * Time.deltaTime;
 
       	Debug.DrawLine(lastPos, transform.position, Color.green, 100);
	}

#endregion

#region Game Methods
#endregion

}
