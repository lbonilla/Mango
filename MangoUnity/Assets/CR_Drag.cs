/// <summary>
/// Drag tutorial.
/// Copyright 2011 revelopment.co.uk
/// Created by Carlos Revelo
/// 2011
/// </summary>


using UnityEngine;
using System.Collections;

public class CR_Drag : MonoBehaviour {

   [SerializeField]
   float _horizontalLimit = 0, _verticalLimit = 0,    dragSpeed = 0.1f;
   Transform cachedTransform;
   Vector3 startingPos;

void Start () {
    //Make reference to transform
    cachedTransform = transform;

    //Save starting position
    startingPos = cachedTransform.position;
}

// Update is called once per frame
void Update () {
     if(Input.touchCount > 0)
     {

		
          	Vector2 deltaPosition = Input.GetTouch(0).deltaPosition;
			Debug.Log("x: " + Input.GetTouch(0).position.x );
			Debug.Log("y: " + Input.GetTouch(0).position.y );

         //Switch through touch events
         switch(Input.GetTouch(0).phase)
         {
	       case TouchPhase.Began:
	       break;
  	       case TouchPhase.Moved:
		    DragObject(deltaPosition);
	       break;
	       case TouchPhase.Ended:
	       break;
         }

     }
}

	/// <summary>
	/// Drags the object.
	/// </summary>
	/// <param name='deltaPosition'>
	/// Delta position.
	/// </param>
	void DragObject(Vector2 deltaPosition)
	{
		cachedTransform.position = new Vector3(	deltaPosition.x,
												deltaPosition.y,
												cachedTransform.position.z);
	}
}