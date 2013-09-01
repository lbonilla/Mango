using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// File: Player
// Project:
// Description:
// Author:Esteban Padilla
// Email: 
// Copyright (C) 2013,  (R). All rights reserved.  

public class Player:MonoBehaviour {
#region Enums

#endregion

#region Delegates
#endregion

#region Constants
#endregion

#region Public Variables
#endregion

#region Private Variables
	private int citizensToReduce;
	private int citizensLimit;	
	private int citizensAvailable;	
	private int energyRequired;
	private int energyAvailable;
	private int wood;
	private int metal;
	private int stone;
	private int missiles;
	private Players type;
	private InGameManager inGameManager;
#endregion

#region Properties
	public int CitizensAvailable{get{return citizensAvailable; } 
		set{
			citizensAvailable = value;
			citizensLimit= value;
		}
	}		
	public int CitizensLimit{get{return citizensLimit;} set{citizensLimit=value;}}
	public int CitizensToReduce{get{return citizensToReduce;} set {citizensToReduce= value;}}
	public int EnergyRequired { get { return energyRequired; } set { energyRequired = value; } }
	public int EnergyAvailable { get { return energyAvailable; } set { energyAvailable = value; }}
	public int Wood { get { return wood; } set { wood = value; }}
	public int Metal { get { return metal; } set { metal = value; } }
	public int Stone { get { return stone; } set { stone = value; } }
	public int Missiles { get { return missiles; } set { missiles = value; } }
	public Players Type { get { return type; } set { type = value; } }
	public InGameManager InGameManager { get { return inGameManager; } set { inGameManager = value; }}
	
#endregion

// if this class inherits from MonoBehaviour remove constructor and deconstructor.
#region Constructors
//	public Player(InGameManager pInGameManager){
//		this.inGameManager   = pInGameManager;
//		this.citizensAvailable = Data.player.citizen;		
//		this.energyAvailable = Data.player.energyProduced;
//		this.wood  			 = Data.player.wood;
//		this.stone 			 = Data.player.stone;
//		this.metal 			 = Data.player.metal;
//		this.missiles		 = Data.player.missiles;
//		this.citizensLimit   = this.citizensAvailable;
//		this.citizensToReduce = 0;		
//	}

#endregion

#region Unity Methods
	void Start(){
//		this.inGameManager   = GameObject.FindGameObjectWithTag("InGameManager").GetComponent<InGameManager>();
//		this.citizensAvailable = Data.player.citizen;		
//		this.energyAvailable = Data.player.energyProduced;
//		this.wood  			 = Data.player.wood;
//		this.stone 			 = Data.player.stone;
//		this.metal 			 = Data.player.metal;
//		this.missiles		 = Data.player.missiles;
//		this.citizensLimit   = this.citizensAvailable;
//		this.citizensToReduce = 0;	
	}
#endregion
	
#region Game Methods
	public void InitPlayer(){
		this.inGameManager   = GameObject.FindGameObjectWithTag("InGameManager").GetComponent<InGameManager>();
		this.citizensAvailable = Data.player.citizen;		
		this.energyAvailable = Data.player.energyProduced;
		this.wood  			 = Data.player.wood;
		this.stone 			 = Data.player.stone;
		this.metal 			 = Data.player.metal;
		this.missiles		 = Data.player.missiles;
		this.citizensLimit   = this.citizensAvailable;
		this.citizensToReduce = 0;	
	
	}
	
	public void UpdateData(){	
		inGameManager.CheckPlayerResources(type);
		inGameManager.UpdatePlayer(this);
		
	}	
	/// <summary>
	/// When a Facility receives the damage.
	/// </summary>
	/// <param name='pFacility'>
	/// Facility
	/// </param>
	/// <param name='ppowerDame'>
	/// Power damage receive
	/// </param>
	public void ReceiveDamage(Facility pFacility , float ppowerDame) {
		pFacility.Life  -= ppowerDame;
		if(pFacility.Life  <= 0 ){
			//If the facility is a building reduce the workers
			if (typeof(Building).Equals(pFacility.GetType())){
				citizensToReduce += pFacility.Citizen;
				citizensLimit -= pFacility.Citizen;
			}else
			{
				Debug.Log("Is not building");
				if(citizensToReduce >= pFacility.Worker){
					citizensToReduce-= pFacility.Worker;
					Debug.Log("Citizens to reduce up than worker: "+citizensToReduce);
				}
				
				else
				{					
					if(citizensToReduce<0)
						citizensToReduce=0;
					citizensLimit += pFacility.Worker - citizensToReduce;
					citizensAvailable = citizensLimit;
					citizensToReduce=0;
				}
			}
			UpdateCitizens();
			InGameManager.RemoveFacility(pFacility, this);						
			Destroy(pFacility.gameObject);			
		}		
	}
	
	/// <summary>
	/// Updates the citizens.
	/// </summary>
	private void UpdateCitizens(){
		if(citizensToReduce >= 0){
			citizensAvailable--;
			citizensToReduce--;
			inGameManager.UpdatePlayer(this);
			if(!IsInvoking("UpdateCitizens"))
			{
				Invoke("UpdateCitizens", 2f);
			}
		}
	}
	
	/// <summary>
	/// Addeds the building.
	/// </summary>
	/// <param name='pCapacity'>
	/// Capacity of citizens of the building
	/// </param>
	public void AddedBuilding(int pCapacity)
	{
		if(citizensToReduce>0)
			if(citizensToReduce>pCapacity)
				citizensToReduce-=pCapacity;
			else
				citizensToReduce= 0;
	}
	
#endregion
	
}
