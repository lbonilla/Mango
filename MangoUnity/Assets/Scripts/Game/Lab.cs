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
	private bool isOn = true;
	public Texture onTexture;
 	public Texture offTexture;
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
	override public void OnUpdate(){	
	
	}
	
	void OnMouseDown(){
		isOn = !isOn;
		if(isOn){
			gameObject.transform.FindChild("lab_mod").renderer.material.mainTexture = onTexture;
		}else{
			gameObject.transform.FindChild("lab_mod").renderer.material.mainTexture = offTexture;
		}
	}


	void OnTriggerEnter(Collider other) {
		Owner.ReceiveDamage(this,other.gameObject.GetComponent<Missile>().DestructionPower);
		Destroy(other.gameObject);		
    }
#endregion
}
