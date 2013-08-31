using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// File: CosVSCurveTest
// Project:
// Description:
// Author:Esteban Padilla
// Email: 
// Copyright (C) 2013,  (R). All rights reserved.  

public class CosVSCurveTest : MonoBehaviour {
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

// if this class inherits from MonoBehaviour remove constructor and deconstructor.
#region Constructors

public Color c1 = Color.yellow;

    public Color c2 = Color.red;

    public int lengthOfLineRenderer = 20;

    void Start() {

        LineRenderer lineRenderer = gameObject.AddComponent<LineRenderer>();

        lineRenderer.material = new Material(Shader.Find("Particles/Additive"));

        lineRenderer.SetColors(c1, c2);

        lineRenderer.SetWidth(0.2F, 0.2F);

        lineRenderer.SetVertexCount(lengthOfLineRenderer);

    }

    void Update() {

        LineRenderer lineRenderer = GetComponent<LineRenderer>();

        int i = 0;

        while (i < lengthOfLineRenderer) {

            Vector3 pos = new Vector3(i * 0.5F, Mathf.Sin(i + Time.time), 0);

            lineRenderer.SetPosition(i, pos);

            i++;

        }

    }

#endregion

#region Game Methods
#endregion

}
