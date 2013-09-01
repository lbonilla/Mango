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
	private bool isOn = true;
	public Texture onTexture;
 	public Texture offTexture;
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
		override public void OnUpdate(){
			
		}
	
		void OnMouseDown(){
			isOn = !isOn;
			if(isOn){
				gameObject.transform.FindChild("energyPlant_mod").renderer.material.mainTexture = onTexture;
			}else{
				gameObject.transform.FindChild("energyPlant_mod").renderer.material.mainTexture = offTexture;
			}
		}

		void OnTriggerEnter(Collider other) {
			ReduceLife(other.gameObject.GetComponent<Missile>().DestructionPower);	
			Destroy(other.gameObject);	
	    }
#endregion

#region Game Methods
	override public void ReduceLife(float value){
		this.Life -= value;
		if(this.Life  < 0 ){
			GameObject.FindGameObjectWithTag("InGameManager").GetComponent<InGameManager>().RemoveFacility(this, Owner);
			Destroy(this.gameObject);
		}
	}
#endregion
}
