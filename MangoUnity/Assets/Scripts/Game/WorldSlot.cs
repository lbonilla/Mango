using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// File: WorldSlot
// Project:
// Description:
// Author:Esteban Padilla
// Email: 
// Copyright (C) 2013,  (R). All rights reserved.  

public class WorldSlot: MonoBehaviour {
#region Enums
#endregion

#region Delegates
#endregion

#region Constants
#endregion

#region Public Variables
#endregion

#region Private Variables
	private Vector3 position;
	public bool isFree = true;
	public float angle = 0;
	private int id;
#endregion

#region Properties

	public int Id {
		get {
			return id;
		}
		set {
			id = value;
		}
	}

	public Vector3 Position {
		get {
			return position;
		}
		set {
			position = value;
		}
	}

	public bool IsFree {
		get {
			return isFree;
		}
		set {
			isFree = value;
		}
	}

	public float Angle {
		get {
			return angle;
		}
		set {
			angle = value;
		}
	}

#endregion

// if this class inherits from MonoBehaviour remove constructor and deconstructor.
#region Constructors

//	public WorldSlot(Vector3 pPosition, float pAngle, int pId){ // constructor
//		// initialize object here
//		this.position = pPosition;
//		this.angle = pAngle;
//		this.id = pId;
//	}
//	
//	~WorldSlot(){// destructor
//		// cleanup statements...
//	}
#endregion

#region Unity Methods
	void Start(){
		isFree = true;
		position = transform.position;
		
	}
#endregion

#region Game Methods
#endregion

}
