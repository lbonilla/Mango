using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// File: MetalFactory
// Project:
// Description:
// Author:Esteban Padilla
// Email: 
// Copyright (C) 2013,  (R). All rights reserved.  

public class MetalFactory : Facility {
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
	private ProductionTimer timer;
	private bool isOn = true;
#endregion

#region Properties
#endregion

// if this class inherits from MonoBehaviour remove constructor and deconstructor.
#region Constructors
	MetalFactory(){ // constructor
		this.Life      		= Data.metalFactory.life;
		this.Citizen 		= Data.metalFactory.citizen;
		this.Worker			= Data.metalFactory.worker;	
		this.EnergyRequired = Data.metalFactory.energyRequired;
		this.EnergyProduced = Data.metalFactory.energyProduced;
		this.Wood 			= Data.metalFactory.wood;
		this.Metal 			= Data.metalFactory.metal;
		this.Stone 			= Data.metalFactory.stone;
		this.Product   		= Data.metalFactory.product;
		this.ProductionTime = Data.metalFactory.productionTime;
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
			gameObject.transform.FindChild("metalFactory_mod").renderer.material.mainTexture = onTexture;
		}else{
			gameObject.transform.FindChild("metalFactory_mod").renderer.material.mainTexture = offTexture;
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
		print(this.Life);
		if(this.Life  < 0 ){
			GameObject.FindGameObjectWithTag("InGameManager").GetComponent<InGameManager>().RemoveFacility(this, Owner);
			Destroy(this.gameObject);
		}
	}
	override public void CompletedProduct(){
		timer.Play(); 
		this.Owner.Metal += this.Product;
		this.Owner.UpdateData();
	}
#endregion
}
