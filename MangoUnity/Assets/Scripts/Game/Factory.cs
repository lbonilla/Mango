using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// File: Factory
// Project:
// Description:
// Author:Esteban Padilla
// Email: 
// Copyright (C) 2013,  (R). All rights reserved.  

public class Factory : Facility {
#region Enums
#endregion

#region Delegates
#endregion

#region Constants
#endregion

#region Public Variables
#endregion

#region Private Variables
	private ProductionTimer timer;
	private int missileCost = 1;
#endregion

#region Properties
	
#endregion


// if this class inherits from MonoBehaviour remove constructor and deconstructor.
#region Constructors

	Factory(){ // constructor
		this.Life      		= Data.factory.life;
		this.Citizen 		= Data.factory.citizen;
		this.Worker         = Data.factory.worker;
		this.EnergyRequired = Data.factory.energyRequired;
		this.EnergyProduced = Data.factory.energyProduced;
		this.Wood 			= Data.factory.wood;
		this.Metal 			= Data.factory.metal;
		this.Stone 			= Data.factory.stone;
		this.Product   		= Data.factory.product;
		this.ProductionTime = Data.factory.productionTime;
		timer = new ProductionTimer(this);
		timer.ProductionTime = this.ProductionTime;	
		timer.Play();
		
	}
#endregion

#region Unity Methods
#endregion

#region Game Methods
	override public void OnUpdate(){	
		timer.Tick();	
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

	override public void CompletedProduct(){
		Produce();
	}

	public void Produce(){
		timer.Play(); 
		if(Owner.Metal > 0) {
			Owner.Metal -= missileCost;
			this.Owner.Missiles += this.Product;
			this.Owner.UpdateData();
		}	
	}
#endregion

}
