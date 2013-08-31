using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RotateCube : MonoBehaviour {
		

	void Update()
	{
		this.gameObject.transform.Rotate(0, 1, 0);
	}
}
