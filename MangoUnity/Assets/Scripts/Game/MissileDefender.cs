using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// File: MissileDefender
// Project:
// Description:
// Author:Esteban Padilla
// Email: 
// Copyright (C) 2013,  (R). All rights reserved.  

public class MissileDefender : Facility {
#region Enums
#endregion

#region Delegates
#endregion

#region Constants
#endregion

#region Public Variables
	public GameObject top;
	public GameObject cannon1;
	public GameObject cannon2;
	public GameObject bullet;
	public Texture onTexture;
 	public Texture offTexture;
#endregion

#region Private Variables
	private bool isOn = true;
	private Missile missile = null;
	private bool shooting = false;
	private float range = 12.0f;
	private string missileName;
	private float shootingAngle;
#endregion

#region Properties

	public string MissileName {
		get {
			return missileName;
		}
		set {
			missileName = value;
		}
	}
#endregion

// if this class inherits from MonoBehaviour remove constructor and deconstructor.
#region Constructors

	MissileDefender(){ // constructor
		this.Life      		= Data.missileDefender.life;
		this.Citizen 		= Data.missileDefender.citizen;
		this.Worker			= Data.missileDefender.worker;
		this.EnergyRequired = Data.missileDefender.energyRequired;
		this.EnergyProduced = Data.missileDefender.energyProduced;
		this.Wood 			= Data.missileDefender.wood;
		this.Metal 			= Data.missileDefender.metal;
		this.Stone 			= Data.missileDefender.stone;
		this.Product   		= Data.missileDefender.product;
	}
	
	~MissileDefender(){// destructor
		// cleanup statements...
	}
#endregion

#region Unity Methods
	override public void OnUpdate(){
		
		if(shooting || !isOn){
			return;
		}

		RaycastHit hit;
	  	Vector3 fwd = top.transform.TransformDirection(Vector3.up);
					
	  	if (Physics.Raycast(top.transform.position, fwd, out hit, range)){
	    	//print("There is something in front of the object!");
	    	Debug.DrawLine(top.transform.position, hit.collider.gameObject.transform.position, Color.red);
			if(hit.collider.gameObject.name == missileName){	
				//Once a missile is detected follow and shot
				//top.animation.Stop();
				//if(missile == null){
					Debug.Log(hit.collider.gameObject.name);
					missile = hit.collider.gameObject.GetComponent<Missile>();
					//Debug.Log("Rotation Z: "+top.transform.rotation.z);
					
					ShootBullet();
					//shooting = true;
					//Invoke("ShootBullet", 0.1f);
				//}
			}			
	  	}
//		ShootBullet();
		
	  	//Debug.DrawLine(top.transform.position, fwd, Color.green);
	}

	void OnMouseDown(){
		isOn = !isOn;
		if(isOn){
			top.transform.FindChild("missileDefender_mod").renderer.material.mainTexture = onTexture;
			top.animation.Play();
		}else{
			top.transform.FindChild("missileDefender_mod").renderer.material.mainTexture = offTexture;
			top.animation.Stop();
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
			Destroy(this.gameObject);
			//TODO Tell IGM I was destroy
		}
	}

	private void ShootBullet(){
		shooting = true;
		audio.Play();
		GameObject b = Instantiate(bullet, cannon1.transform.position, Quaternion.identity) as GameObject;

		Vector3 q = cannon1.transform.rotation.eulerAngles;
		shootingAngle = q.z;							
		switch(Owner.Type){
			case Players.Player1:
				b.GetComponent<Bullet>().SetRotation(shootingAngle);
			break;
			case Players.Player2:
				b.GetComponent<Bullet>().SetRotation(shootingAngle);
			break;
			default:
			break;
		}
					
		Invoke("ShootBullet2", 0.05f);
	}

	private void ShootBullet2(){
		audio.Play();
		GameObject b = Instantiate(bullet, cannon2.transform.position, Quaternion.identity) as GameObject;

		//Vector3 q = cannon2.transform.rotation.eulerAngles;							
		switch(Owner.Type){
			case Players.Player1:
				b.GetComponent<Bullet>().SetRotation(shootingAngle);
			break;
			case Players.Player2:
				b.GetComponent<Bullet>().SetRotation(shootingAngle);
			break;
			default:
			break;
		}
		
		
		Invoke("Reset", 1.0f);
	}
		
	private void Reset(){
		shooting = false;
	}
	
#endregion

}
