using UnityEngine;
using System.Collections;

public class ViewManagerOLD : MonoBehaviour {

	private IGMControllerManager controllerManager;

	public GUITexture p1_addEnegyBtn;
	public GUITexture p1_addFactoryBtn;
	public GUITexture p1_addLabBtn;
	public GUITexture p1_addMissileDefenderBtn;
	public GUITexture p1_addMissileLauncherBtn;
	public GUITexture p1_addQuarryBtn;
	public GUITexture p1_addWoodMillBtn;
	
	public GUIText p1_energy	;
	public GUIText p1_energyTitle;
	public GUIText p1_metal;
	public GUIText p1_metalTitle;
	public GUIText p1_population;
	public GUIText p1_populationTitle;
	public GUIText p1_stone;
	public GUIText p1_stoneTitle;
	public GUIText p1_wood;
	public GUIText p1_woodTitle;

	public GUITexture p1_addBuildingBtn;

	// Use this for initialization
	void Start () {
		controllerManager = GameObject.FindGameObjectWithTag("IGMControllerManager").GetComponent<IGMControllerManager>();
	}
	
	public void updateLabelText (string pLabelName, float value){
		switch (pLabelName) {
			case "p1_energy":
				p1_energy.GetComponent<GUIText>().text = value.ToString();
			break;
			case "p1_population":
				p1_population.GetComponent<GUIText>().text = value.ToString();
			break;
			case "p1_metal":
				p1_metal.GetComponent<GUIText>().text = value.ToString();
			break;
			case "p1_stone":
				p1_stone.GetComponent<GUIText>().text = value.ToString();
			break;
			case "p1_wood":
				p1_wood.GetComponent<GUIText>().text = value.ToString();
			break;
			default:
			break;
		}		
	}

	public void ButtonDown(string pButtonName){
		controllerManager.OnButtonDown(pButtonName);
	}
}
