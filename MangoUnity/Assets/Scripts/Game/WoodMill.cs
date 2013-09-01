using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// File: WoodMill
// Project:
// Description:
// Author:Esteban Padilla
// Email: 
// Copyright (C) 2013,  (R). All rights reserved.  

public class WoodMill : Facility {
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


#region Constructors
	WoodMill(){
		this.Life     	 	=  Data.woodMill.life;
		this.Citizen 		=  Data.woodMill.citizen;
		this.Worker			=  Data.woodMill.worker;
		this.EnergyRequired =  Data.woodMill.energyRequired;
		this.EnergyProduced =  Data.woodMill.energyProduced;
		this.Wood 			=  Data.woodMill.wood;
		this.Metal 			=  Data.woodMill.metal;
		this.Stone 			=  Data.woodMill.stone;
		this.Product   		=  Data.woodMill.product;
		this.ProductionTime =  Data.woodMill.productionTime;
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
			gameObject.transform.FindChild("woodMill_mod").renderer.material.mainTexture = onTexture;
		}else{
			gameObject.transform.FindChild("woodMill_mod").renderer.material.mainTexture = offTexture;
		}
	}

	void OnTriggerEnter(Collider other) {
		ReduceLife(other.gameObject.GetComponent<Missile>().DestructionPower);		
		Destroy(other.gameObject);
    }

#endregion

#region Game Methods	
	override public void ReduceLife(float value){
		this.Life  -= value;
		if(this.Life  < 0 ){
			GameObject.FindGameObjectWithTag("InGameManager").GetComponent<InGameManager>().RemoveFacility(this, Owner);
			Destroy(this.gameObject);
		}
	}

	override public void CompletedProduct(){
		timer.Play(); 
		this.Owner.Wood += this.Product;
		this.Owner.UpdateData();
	}
#endregion

}
