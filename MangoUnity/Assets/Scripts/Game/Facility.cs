using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// File: Facility
// Project:
// Description:
// Author:Esteban Padilla
// Email: 
// Copyright (C) 2013,  (R). All rights reserved.  

public class Facility : MonoBehaviour {
#region Enums
#endregion

#region Delegates
#endregion

#region Constants
#endregion

#region Public Variables
	public static int id = 0;
#endregion

#region Private Variables
	private int citizen;
	private int worker;	
	private int energyRequired;
	private int energyProduced;
	private int wood;
	private int metal;
	private int stone;
	private int product;
	private int productionTime;
	private float life;
	private Player owner;
#endregion

#region Properties
	public int Citizen 			{ get { return citizen; } set { citizen = value; } }
	public int Worker 			{ get { return worker; } set { worker = value; }}
	public int EnergyRequired 	{ get { return energyRequired; } set { energyRequired = value; } }
	public int EnergyProduced 	{ get { return energyProduced; } set { energyProduced = value; } }
	public int Wood 			{ get { return wood; } set { wood = value; } }
	public int Metal 			{ get { return metal; } set { metal = value; } }
	public int Stone 			{ get { return stone; } set { stone = value; } }
	public int Product 			{ get { return product; } set { product = value; } }
	public int ProductionTime 	{ get { return productionTime; } set { productionTime = value; } }
    public float Life 			{ get { return life; } set { life = value; } }
	public Player Owner 		{ get { return owner; } set { owner = value; } }
#endregion

#region Constructors
#endregion
	
#region Unity Methods
	// Use this for initialization
	void Start () {
		id++;
	}
	
	// Update is called once per frame
	void Update () {
		OnUpdate();//call OnUpdate on children
	}
#endregion

#region Game Methods
	public virtual void OnUpdate() { }
	public virtual void ReduceLife(float value) { }
	public virtual void CompletedProduct() { }
#endregion

}
