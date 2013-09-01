using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// File: MissileLauncher
// Project:
// Description:
// Author:Esteban Padilla
// Email: 
// Copyright (C) 2013,  (R). All rights reserved.  

public class MissileLauncher : Facility {
#region Enums
#endregion

#region Delegates
#endregion

#region Constants
#endregion

#region Public Variables
	public GameObject missile;
	public GameObject cannon1;
	public GameObject cannon2;
	public GameObject cannon3;
	public GameObject cannon4;
#endregion

#region Private Variables
	private bool canAddMissile = true;
#endregion

#region Properties
#endregion

// if this class inherits from MonoBehaviour remove constructor and deconstructor.
#region Constructors
	MissileLauncher(){ // constructor
		this.Life      		= Data.missileLauncher.life;
		this.Citizen 		= Data.missileLauncher.citizen;
		this.Worker			= Data.missileLauncher.worker;
		this.EnergyRequired = Data.missileLauncher.energyRequired;
		this.EnergyProduced = Data.missileLauncher.energyProduced;
		this.Wood 			= Data.missileLauncher.wood;
		this.Metal 			= Data.missileLauncher.metal;
		this.Stone 			= Data.missileLauncher.stone;
		this.Product   		= Data.missileLauncher.product;
	}
#endregion
	void OnTriggerEnter(Collider other) {
		ReduceLife(other.gameObject.GetComponent<Missile>().DestructionPower);		
		Destroy(other.gameObject);
    }

	void OnMouseDown(){
		if(canAddMissile){
			AddMissile();
		}
	}

	void OnMouseOver() {
				
    }

    void OnMouseExit() {
        
    }
#region Unity Methods

#endregion

#region Game Methods
	override public void OnUpdate(){
	
	}
	
	override public void ReduceLife(float value){
		this.Life  -= value;
		print(this.Life);
		if(this.Life  < 0 ){
			GameObject.FindGameObjectWithTag("InGameManager").GetComponent<InGameManager>().RemoveFacility(this, Owner);
			Destroy(this.gameObject);
		}
	}

	private void AddMissile(){
		if(Owner.Missiles > 0){
			canAddMissile = false;
			Owner.Missiles -= 4;	
			Owner.UpdateData();		

			GameObject m;
			Vector3 pos = transform.position;
	
			switch(Owner.Type){		
				case Players.Player1:
					pos.y += 1;
					m = Instantiate(missile, cannon1.transform.position, new Quaternion(0, 0, 0, 0)) as GameObject;
					m = Instantiate(missile, cannon2.transform.position, new Quaternion(0, 0, 0, 0)) as GameObject;
					m = Instantiate(missile, cannon3.transform.position, new Quaternion(0, 0, 0, 0)) as GameObject;
					m = Instantiate(missile, cannon4.transform.position, new Quaternion(0, 0, 0, 0)) as GameObject;
					m.name = "p1m";
				break;
				case Players.Player2:
					pos.y -= 1;
					m = Instantiate(missile, cannon1.transform.position, new Quaternion(0, 0, 180,0)) as GameObject;
					m = Instantiate(missile, cannon2.transform.position, new Quaternion(0, 0, 180, 0)) as GameObject;
					m = Instantiate(missile, cannon3.transform.position, new Quaternion(0, 0, 180, 0)) as GameObject;
					m = Instantiate(missile, cannon4.transform.position, new Quaternion(0, 0, 180, 0)) as GameObject;
					m.name = "p2m";
				break;
			
			}
			
			Invoke("EnableAddingMissile", 0.2f);
		}
	}
	
	private void EnableAddingMissile(){
		canAddMissile = true;
	}

	
#endregion

}
