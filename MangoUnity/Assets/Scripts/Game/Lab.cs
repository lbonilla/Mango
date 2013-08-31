using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// File: Lab
// Project:
// Description:
// Author:Esteban Padilla
// Email: 
// Copyright (C) 2013,  (R). All rights reserved.  

public class Lab : Facility {
#region Enums
#endregion

#region Delegates
#endregion

#region Constants
#endregion

#region Public Variables
#endregion

#region Private Variables

#endregion

#region Properties
#endregion

// if this class inherits from MonoBehaviour remove constructor and deconstructor.
#region Constructors

	Lab(){ // constructor
		this.Life      		= Data.lab.life;
		this.Citizen 		= Data.lab.citizen;
		this.Worker			= Data.lab.worker;
		this.EnergyRequired = Data.lab.energyRequired;
		this.EnergyProduced = Data.lab.energyProduced;
		this.Wood 			= Data.lab.wood;
		this.Metal 			= Data.lab.metal;
		this.Stone 			= Data.lab.stone;
		this.Product   		= Data.lab.product;
	}

#endregion

#region Unity Methods

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

#endregion

#region Game Methods
	override public void OnUpdate(){
	
	}
	
	override public void ReduceLife(float value){
		this.Life  -= value;
		if(this.Life  < 0 ){
			GameObject.FindGameObjectWithTag("InGameManager").GetComponent<InGameManager>().RemoveFacility(this, Owner);
			Destroy(this.gameObject);
		}
	}

	void OnTriggerEnter(Collider other) {
		ReduceLife(other.gameObject.GetComponent<Missile>().DestructionPower);
		Destroy(other.gameObject);		
    }
#endregion

}
