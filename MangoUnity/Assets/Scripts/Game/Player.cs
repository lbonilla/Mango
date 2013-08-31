using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// File: Player
// Project:
// Description:
// Author:Esteban Padilla
// Email: 
// Copyright (C) 2013,  (R). All rights reserved.  

public class Player {
#region Enums

#endregion

#region Delegates
#endregion

#region Constants
#endregion

#region Public Variables
#endregion

#region Private Variables
	private int citizens;	
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
	public int Citizens { get { return citizens; } set { citizens = value; }}
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
	public Player(InGameManager pInGameManager){
		this.inGameManager   = pInGameManager;
		this.citizens 		 = Data.player.citizen;
		this.energyAvailable = Data.player.energyProduced;
		this.wood  			 = Data.player.wood;
		this.stone 			 = Data.player.stone;
		this.metal 			 = Data.player.metal;
		this.missiles		 = Data.player.missiles;
	}

#endregion

#region Unity Methods
#endregion

#region Game Methods
	public void UpdateData(){
		inGameManager.CheckPlayerResources(type);
		inGameManager.UpdatePlayer(this);
	}
#endregion

}
