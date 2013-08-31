using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// File: World
// Project:
// Description:
// Author:Esteban Padilla
// Email: 
// Copyright (C) 2013,  (R). All rights reserved.  

public class World : MonoBehaviour {
#region Enums
#endregion

#region Delegates
#endregion

#region Constants
#endregion

#region Public Variables
	public float speed = 1.0f;
	public GameObject slot;
	public List<GameObject> slots = new List<GameObject>();
#endregion

#region Private Variables
	private int slotAvailable = 40;
	private float angle = 0;
#endregion

#region Properties
#endregion

#region Constructors
#endregion

#region Unity Methods
	// Use this for initialization
	void Start () {
		float xpos = transform.position.x;
		float ypos = transform.position.y;
		float radius = 7.8f;

		float buildingXPos = 0;
		float buildingYPos = -10;

		GameObject go = null;
		for(int i = 0; i < slotAvailable; i++){	

			buildingXPos = GetXPosWithAngleAndRadius(angle, radius);
			buildingYPos = GetYPosWithAngleAndRadius(angle, radius);// + ypos;					

			//slots.Add(new WorldSlot(new Vector3((xpos - buildingXPos), (buildingYPos + ypos), 0f), angle, i));
			
			Vector3 pos = new Vector3((xpos - buildingXPos), (buildingYPos + ypos), 0f);
			go = Instantiate(slot, pos, Quaternion.identity) as GameObject;
			go.name = "slot_" + i;
			go.transform.Rotate(new Vector3(0, 0, 1), angle);				
			go.gameObject.transform.parent = this.transform;
			slots.Add(go);				

			go.GetComponent<WorldSlot>().Position = pos;
			go.GetComponent<WorldSlot>().IsFree = true;
			go.GetComponent<WorldSlot>().Id = i;
			go.GetComponent<WorldSlot>().Angle = angle;				
			
			angle += 9f;
		}	
	}

	// Update is called once per frame
	void Update () {
		gameObject.transform.RotateAround(gameObject.transform.position, Vector3.forward, speed * Time.deltaTime);
	}

	void OnTriggerEnter(Collider other) {		 
		Destroy(other.gameObject);
    }
#endregion

#region Game Methods
	private float Sine(float angle){
		float sin = Mathf.Sin((Mathf.PI / 180)* angle);
		return sin;
	}
	
	private float Cosine(float angle){
		float cosine = Mathf.Cos((Mathf.PI / 180) * angle);
		return cosine;
	}

	private float GetXPosWithAngleAndRadius(float angle, float radius){
		float xpos = Sine(angle) * radius;
		return xpos;
	}
	
	private float GetYPosWithAngleAndRadius(float angle, float radius){
		float xpos = Cosine(angle) * radius;
		return xpos;
	}

	private float GetAngleFromPosition(float x1, float y1, float x2, float y2){
 		float o = 0;
		float a = 0;
		bool doingA = false;
		bool doingB = false;
		bool doingC = false;
		bool doingD = false;

		if(x1 >= x2 && y1 <= y2){//set for A
			o = x1 - x2;
			a = y2 - y1;
			doingA = true;
		}else if(x1 >= x2 && y1 >= y2) { // set for B
			a = x1 - x2;
			o = y1 - y2;
			doingB = true;
		}else if(x1 <= x2 && y1 >= y2){//set for C
			o = x2 - x1;
			a = y1 - y2;
			doingC = true;
		}else if( x1 <= x2 && y1 <= y2){//set for D 
			o = y2 - y1;
			a = x2 -x1;
			doingD = true;
		}

//		print("o: " + o);
//		print("a: " + a);

		float angle = Mathf.Rad2Deg*Mathf.Atan(o / a);
		angle = Mathf.Ceil(angle);
		
		if(doingB){ angle += 90; }
		else if (doingC) { angle += 180; }		
		else if (doingD) { angle += 270; }

		return angle;
	}
	
	public WorldSlot GetNextSlot(){
		WorldSlot sl = null;
		foreach(GameObject ws in slots){
			if(ws.GetComponent<WorldSlot>().IsFree){
				ws.GetComponent<WorldSlot>().IsFree = false;
				print(ws.GetComponent<WorldSlot>().Id);
				print(ws.GetComponent<WorldSlot>().IsFree);
				sl = ws.GetComponent<WorldSlot>();
				sl.Position = ws.transform.position;
				break;
			}
		}
		return sl;
	}

	private bool CheckForFreeSlots(int index){
		if(slots[index].GetComponent<WorldSlot>().IsFree){
			return true;
		}else{
			if(index == (slotAvailable - 1)){ 
				print("Not Slots available");
				return false; 
			} else { 
				index++;
				return CheckForFreeSlots(index); 
			} 
		}
	}

	public WorldSlot GetFreeSlot(int value){
		if(!CheckForFreeSlots(0)){ return null; }		

		if(value == slotAvailable){ value = 0;}

		if(slots[value].GetComponent<WorldSlot>().IsFree){
			slots[value].GetComponent<WorldSlot>().IsFree = false;
			WorldSlot slot = slots[value].GetComponent<WorldSlot>();
			slot.Position = slots[value].transform.position;
			slot.Angle = GetAngleFromPosition(transform.position.x, transform.position.y, slot.Position.x, slot.Position.y);
			return slot;
		}else{
			value++;
			return GetFreeSlot(value);
		}
	}
#endregion

}
