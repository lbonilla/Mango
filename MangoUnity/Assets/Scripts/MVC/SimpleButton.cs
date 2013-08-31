using UnityEngine;
using System.Collections;

public class SimpleButton : MonoBehaviour {

	public MissileLauncher missileLauncher;
	private InGameManager inGameManager;

	// Use this for initialization
	void Start () {
		inGameManager = GameObject.FindGameObjectWithTag ("InGameManager").GetComponent<InGameManager> ();
	}

	void OnMouseDown(){
		//ViewManager.ButtonDown(buttonName.text);
		print("Shoot");
	}

	void OnMouseOver() {
				
    }

    void OnMouseExit() {
        
    }
    
}
