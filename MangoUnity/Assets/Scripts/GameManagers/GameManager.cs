using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	

	
	private ControllerManager controllerManager;

	// Use this for initialization
	void Start () {
		controllerManager = GameObject.FindGameObjectWithTag("ControllerManager").GetComponent<ControllerManager>();
		Invoke("ShowWinner", 0.1f);
	}
	
	private void ShowWinner(){
		controllerManager.ShowWinner();
	}

	public void PlayButtonHandler (){	
		controllerManager.ShutDown();
		Application.LoadLevel("gameScreen");
	}	
}
