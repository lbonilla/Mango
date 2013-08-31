using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// File: FacilityData
// Project:
// Description:
// Author:Esteban Padilla
// Email: 
// Copyright (C) 2013,  (R). All rights reserved.  

public class Data {
#region Structs
public struct FacilityData { public int life, citizen, worker, energyRequired, energyProduced, wood, metal, stone, product, productionTime, missiles; }
public static FacilityData player;
public static FacilityData building;
public static FacilityData energyPlant;
public static FacilityData woodMill;
public static FacilityData quarry;
public static FacilityData metalFactory;	
public static FacilityData missileLauncher;
public static FacilityData factory;
public static FacilityData missileDefender;
public static FacilityData lab;

public static string winner = "";

#endregion

#region Delegates
#endregion
#region Constants
#endregion

#region Public Variables
#endregion

#region Private Variables
#endregion

#region Properties
#endregion

// if this class inherits from MonoBehaviour remove constructor and deconstructor.
#region Constructors
	public Data(){ // constructor
		//Facility Settings
		//Player
		player.life				= 0;
		player.citizen 			= 5;
		player.worker     		= 0;
		player.energyRequired 	= 0;
		player.energyProduced 	= 5;
		player.wood 			= 30;
		player.stone 			= 30;
		player.metal 			= 35;
		player.product   		= 0;
		player.productionTime   = 0;
		player.missiles         = 10;

		//Building
		building.life			= 15;
		building.citizen 		= 15;
		building.worker     	=  0;
		building.energyRequired	=  5;
		building.energyProduced =  0;
		building.wood 			=  5;
		building.metal 			=  7;
		building.stone 			=  5;
		building.product   		=  0;
		building.productionTime =  0;

		//Energy Plant
		energyPlant.life      		= 15;
		energyPlant.citizen 	 	=  0;
		energyPlant.worker         	=  0;	
		energyPlant.energyRequired 	=  0;
		energyPlant.energyProduced 	= 15;
		energyPlant.wood 			=  5;
		energyPlant.metal 			=  7;
		energyPlant.stone 			=  5;
		energyPlant.product   		=  0;
		energyPlant.productionTime  =  0;

		//WoodMill
		woodMill.life      		= 20;
		woodMill.citizen 	 	=  0;
		woodMill.worker         =  2;
		woodMill.energyRequired =  4;
		woodMill.energyProduced =  0;
		woodMill.wood 			=  4;
		woodMill.metal 			=  6;
		woodMill.stone 			=  2;
		woodMill.product   		=  1;
		woodMill.productionTime =  3;

		//Quarry
		quarry.life      		= 20;
		quarry.citizen 	 		=  0;
		quarry.worker         	=  2;
		quarry.energyRequired 	=  4;
		quarry.energyProduced 	=  0;
		quarry.wood 			=  5;
		quarry.metal 			=  7;
		quarry.stone 			=  3;
		quarry.product   		=  1;
		quarry.productionTime   =  3;

		//Metal Factory
		metalFactory.life      		= 20;
		metalFactory.citizen 	 	=  0;
		metalFactory.worker         =  2;
		metalFactory.energyRequired =  4;
		metalFactory.energyProduced =  0;
		metalFactory.wood 			=  5;
		metalFactory.metal 			=  7;
		metalFactory.stone 			=  3;
		metalFactory.product   		=  1;
		metalFactory.productionTime =  3;

		//Missile Launcher
		missileLauncher.life      		= 20;
		missileLauncher.citizen 	 	=  0;
		missileLauncher.worker         	=  2;
		missileLauncher.energyRequired 	=  4;
		missileLauncher.energyProduced 	=  0;
		missileLauncher.wood 			=  5;
		missileLauncher.metal 			=  7;
		missileLauncher.stone 			=  3;
		missileLauncher.product   		=  1;
		missileLauncher.productionTime  =  0;

		//Factory
		factory.life      		= 20;
		factory.citizen 	 	=  0;
		factory.worker          =  2;
		factory.energyRequired  =  4;
		factory.energyProduced  =  0;
		factory.wood 			=  5;
		factory.metal 			=  7;
		factory.stone 			=  3;
		factory.product   		=  1;
		factory.productionTime  =  4;

		//Missile Defender
		missileDefender.life      		= 20;
		missileDefender.citizen 	 	=  0;
		missileDefender.worker         	=  2;
		missileDefender.energyRequired 	=  4;
		missileDefender.energyProduced 	=  0;
		missileDefender.wood 			=  5;
		missileDefender.metal 			=  7;
		missileDefender.stone 			=  3;
		missileDefender.product   		=  1;
		missileDefender.productionTime  =  0;

		//Lab
		lab.life      		= 20;
		lab.citizen 	 	=  0;
		lab.worker         	=  2;
		lab.energyRequired 	=  4;
		lab.energyProduced 	=  0;
		lab.wood 			=  5;
		lab.metal 			=  7;
		lab.stone 			=  3;
		lab.product   		=  1;
		lab.productionTime  =  0;
	}
#endregion

#region Unity Methods
#endregion

#region Game Methods
#endregion

}
