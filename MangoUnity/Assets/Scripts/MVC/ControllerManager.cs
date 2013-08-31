using UnityEngine;
using System.Collections;

public class ControllerManager : MonoBehaviour {

	private ViewManager viewManager = null;
	private GameManager gameManager = null;
	
	// Use this for initialization
	void Start () {
		viewManager = GameObject.FindGameObjectWithTag("ViewManager").GetComponent<ViewManager>();
		gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
	}
	
	public void OnButtonDown(string pButtonName){
		print(pButtonName);
		switch (pButtonName) {
			case "idleBlueBtn_tex":
				gameManager.PlayButtonHandler();
			break;
			default:
			break;
		}
	}

	public void updateViewLabelText (){
		
	}

	public void ShutDown () {
		viewManager.ShutDown();
	}

	public void ShowWinner () {
		if(viewManager != null){
			viewManager.ShowWinner();
		}
	}
}
