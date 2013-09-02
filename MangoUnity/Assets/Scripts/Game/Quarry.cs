using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// File: Quarry
// Project:
// Description:
// Author:Esteban Padilla
// Email: 
// Copyright (C) 2013,  (R). All rights reserved.  

public class Quarry : Facility {
#region Enums
#endregion

#region Delegates
#endregion

#region Constants
#endregion

#region Public Variables
	public Texture onTexture;
 	public Texture offTexture;
#endregion

#region Private Variables
	private bool isOn = true;
	private ProductionTimer timer;
#endregion

#region Properties
#endregion

// if this class inherits from MonoBehaviour remove constructor and deconstructor.
#region Constructors

	Quarry(){ // constructor
		this.Life      		= Data.quarry.life;
		this.Citizen 		= Data.quarry.citizen;
		this.Worker			= Data.quarry.worker;
		this.EnergyRequired = Data.quarry.energyRequired;
		this.EnergyProduced = Data.quarry.energyProduced;
		this.Wood 			= Data.quarry.wood;
		this.Stone 			= Data.quarry.stone;
		this.Metal 			= Data.quarry.metal;
		this.Product   		= Data.quarry.product;
		this.ProductionTime = Data.quarry.productionTime;
		timer = new ProductionTimer(this);
		timer.ProductionTime = this.ProductionTime;
		timer.Play();
	}
#endregion

#region Unity Methods
	override public void OnUpdate(){
		if(isOn){
			timer.Tick();
		}
	}
	
	void OnMouseDown(){
		isOn = !isOn;
		
		if(isOn){
			gameObject.transform.FindChild("quarry_mod").renderer.material.mainTexture = onTexture;
			Owner.CitizensAvailable -= Worker;
			Owner.EnergyAvailable += EnergyProduced;
			Owner.EnergyAvailable -= EnergyRequired;
		}else{
			gameObject.transform.FindChild("quarry_mod").renderer.material.mainTexture = offTexture;
			Owner.CitizensAvailable += Worker;
			Owner.EnergyAvailable -= EnergyProduced;
			Owner.EnergyAvailable += EnergyRequired;
		}
		Owner.UpdateData();
	}

	void OnTriggerEnter(Collider other) {
		Owner.ReceiveDamage(this,other.gameObject.GetComponent<Missile>().DestructionPower);
		Destroy(other.gameObject);	
    }

#endregion

#region Game Methods

	override public void CompletedProduct(){
		timer.Play(); 
		this.Owner.Stone += this.Product;
		this.Owner.UpdateData();
	}
#endregion

}
