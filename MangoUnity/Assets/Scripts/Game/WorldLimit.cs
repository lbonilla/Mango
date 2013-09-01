using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// File: WorldLimit
// Project:
// Description:
// Author:Esteban Padilla
// Email: 
// Copyright (C) 2013,  (R). All rights reserved.  

public class WorldLimit : MonoBehaviour {
#region Enums
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

#region Constructors
#endregion

#region Unity Methods
	void OnTriggerEnter(Collider other) {		 
		Destroy(other.gameObject);
    }
#endregion

#region Game Methods
#endregion

}
