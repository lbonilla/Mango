using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// File: ProductionTimer
// Project:
// Description:
// Author:Esteban Padilla
// Email: 
// Copyright (C) 2013,  (R). All rights reserved.  

public class ProductionTimer {
#region Enums
#endregion

#region Delegates
#endregion

#region Constants
#endregion

#region Public Variables
#endregion

#region Private Variables
	private int seconds, productionTime = 5;	
	private float initialTime;	
	private bool play = false;
	private Facility myFacility;
#endregion

#region Properties
	public int ProductionTime { get { return productionTime; } set { productionTime = value; } }
	public Facility MyFacility { get { return myFacility; } set { myFacility = value; }}
#endregion

#region Constructors	
	public ProductionTimer(Facility pFacility){
		this.myFacility = pFacility;	
	}
#endregion

#region Unity Methods
	public void Tick () {
		if(!play) { return; }
		if( play ){ seconds = (int)(Time.time - initialTime); }
		if(seconds == productionTime){ Complete(); }
	}
#endregion

#region Game Methods
	private void Complete(){
		play = false;
		//tell the facility to do something when complete
		myFacility.CompletedProduct();
	}
	
	public void Play(){
		play = true;
		seconds = 0;	
		initialTime = Time.time;	
	}
#endregion
}
