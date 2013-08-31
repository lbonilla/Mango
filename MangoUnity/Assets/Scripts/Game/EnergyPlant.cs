using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// File: EnergyPlant
// Project:
// Description:
// Author:Esteban Padilla
// Email: 
// Copyright (C) 2013,  (R). All rights reserved.  

public class EnergyPlant : Facility {
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

	EnergyPlant(){ // constructor
		this.Life      		= Data.energyPlant.life;
		this.Citizen 	 	= Data.energyPlant.citizen;
		this.Worker         = Data.energyPlant.worker;
		this.EnergyRequired = Data.energyPlant.energyRequired;
		this.EnergyProduced = Data.energyPlant.energyProduced;
		this.Wood 			= Data.energyPlant.wood;
		this.Metal 			= Data.energyPlant.metal;
		this.Stone 			= Data.energyPlant.stone;
		this.Product   		= Data.energyPlant.product;
	}
	
	~EnergyPlant(){// destructor
		// cleanup statements...
	}
#endregion

#region Unity Methods
#endregion

#region Game Methods
	override public void OnUpdate(){
		
	}
	
	override public void ReduceLife(float value){
		this.Life -= value;
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
