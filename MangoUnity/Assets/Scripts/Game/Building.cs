using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// File: Building
// Project:
// Description:
// Author:Esteban Padilla
// Email: 
// Copyright (C) 2013,  (R). All rights reserved.  

public class Building : Facility {
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

	Building(){ // constructor
		this.Life			= Data.building.life;
		this.Citizen 		= Data.building.citizen;
		this.Worker     	= Data.building.worker;
		this.EnergyRequired	= Data.building.energyRequired;
		this.EnergyProduced = Data.building.energyProduced;
		this.Wood 			= Data.building.wood;
		this.Metal 			= Data.building.metal;
		this.Stone 			= Data.building.stone;
		this.Product   		= Data.building.product;
	}
#endregion

#region Unity Methods
#endregion

#region Game Methods
	override public void ReduceLife(float value){
		this.Life  -= value;
		print(this.Life);
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
