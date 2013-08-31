using UnityEngine;
using System.Collections;

public class IGMControllerManager : MonoBehaviour {

	private IGMViewManager viewManager;
	private InGameManager inGameManager;
	
	// Use this for initialization
	void Start () {
		viewManager = GameObject.FindGameObjectWithTag("IGMViewManager").GetComponent<IGMViewManager>();
		inGameManager = GameObject.FindGameObjectWithTag("InGameManager").GetComponent<InGameManager>();
	}
	
	public void OnButtonDown(string pButtonName){
		print(pButtonName);
		switch (pButtonName) {
			case "buildingRedBtn_tex":
				inGameManager.AddBuilding(Players.Player1);
			break;
			case "buildingBlueBtn_tex":
				inGameManager.AddBuilding(Players.Player2);
			break;
			case "factoryRedBtn_tex":
				inGameManager.AddFactory(Players.Player1);
			break;
			case "factoryBlueBtn_tex":
				inGameManager.AddFactory(Players.Player2);
			break;
			case "energyRedBtn_tex":
				inGameManager.AddEnergyPlant(Players.Player1);
			break;
			case "energyBlueBtn_tex":
				inGameManager.AddEnergyPlant(Players.Player2);
			break;
			case "labRedBtn_tex":
				inGameManager.AddLab(Players.Player1);
			break;
			case "labBlueBtn_tex":
				inGameManager.AddLab(Players.Player2);
			break;
			case "defenderRedBtn_tex":
				inGameManager.AddMissileDefender(Players.Player1);
			break;
			case "defenderBlueBtn_tex":
				inGameManager.AddMissileDefender(Players.Player2);
			break;
			case "missileRedBtn_tex":
				inGameManager.AddMissileLauncher(Players.Player1);
			break;
			case "missileBlueBtn_tex":
				inGameManager.AddMissileLauncher(Players.Player2);
			break;
			case "stoneRedBtn_tex":
				inGameManager.AddQuarry(Players.Player1);
			break;
			case "stoneBlueBtn_tex":
				inGameManager.AddQuarry(Players.Player2);
			break;
			case "metalRedBtn_tex":
				inGameManager.AddMetalFactory(Players.Player1);
			break;
			case "metalBlueBtn_tex":
				inGameManager.AddMetalFactory(Players.Player2);
			break;
			case "woodRedBtn_tex":
				inGameManager.AddWoodMill(Players.Player1);
			break;
			case "woodBlueBtn_tex":
				inGameManager.AddWoodMill(Players.Player2);
			break;
			default:
			break;
		}
	}

	public void updateViewLabelText (Player pPlayer){
		viewManager.updateLabelText(pPlayer.Type, "citizen", pPlayer.Citizens);
		int value = pPlayer.EnergyAvailable - pPlayer.EnergyRequired;
		viewManager.updateLabelText(pPlayer.Type, "energy", value);
		viewManager.updateLabelText(pPlayer.Type, "wood", pPlayer.Wood);
		viewManager.updateLabelText(pPlayer.Type, "stone", pPlayer.Stone);
		viewManager.updateLabelText(pPlayer.Type, "metal", pPlayer.Metal);
		viewManager.updateLabelText(pPlayer.Type, "missiles", pPlayer.Missiles);
	}

	public void SetButtonState (Player pPlayer, string pButton, bool value)
	{
		viewManager.SetButtonState(pPlayer.Type, pButton, value);
	}

	public void ShutDown () {
		viewManager.ShutDown();
	}
}
