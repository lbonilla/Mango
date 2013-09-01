using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class IGMViewManager : MonoBehaviour {

	private IGMControllerManager controllerManager;

	private FButton buildingRedBtn;
	private FButton energyRedBtn;
	private FButton woodRedBtn;
	private FButton stoneRedBtn;
	private FButton metalRedBtn;
	private FButton missileRedBtn;
	private FButton factoryRedBtn;
	private FButton defenderRedBtn;
	private FButton labRedBtn;

	private FLabel citizenRedLbl;
	private FLabel energyRedLbl;
	private FLabel woodRedLbl;
	private FLabel stoneRedLbl;
	private FLabel metalRedLbl;
	private FLabel missileRedLbl;

	private FButton buildingBlueBtn;
	private FButton energyBlueBtn;
	private FButton woodBlueBtn;
	private FButton stoneBlueBtn;
	private FButton metalBlueBtn;
	private FButton missileBlueBtn;
	private FButton factoryBlueBtn;
	private FButton defenderBlueBtn;
	private FButton labBlueBtn;

	private FLabel citizenBlueLbl;
	private FLabel energyBlueLbl;
	private FLabel woodBlueLbl;
	private FLabel stoneBlueLbl;
	private FLabel metalBlueLbl;
	private FLabel missileBlueLbl;
	private FStage stage;

	void Start(){	

		FutileParams fparams = new FutileParams (false, false, true, true);

		if(Screen.height == 2048){
			fparams.AddResolutionLevel (Screen.width, 2.0f, 1.0f, "");
		}else{
			fparams.AddResolutionLevel (Screen.width, 0.5f, 1.0f, "");
		}

		fparams.origin = new Vector2 (0, 0.5f);
		Futile.instance.Init (fparams);
		stage = Futile.stage;
		Futile.atlasManager.LoadAtlas ("Atlases/bocaraButtons");
		Futile.atlasManager.LoadFont("AbadiBlue", "AbadiBlue", "Atlases/AbadiBlue", 0.0f, 0.0f);
		Futile.atlasManager.LoadFont("AbadiRed", "AbadiRed", "Atlases/AbadiRed", 0.0f, 0.0f);

		AddRedPlayerUI();
		AddBluePlayerUI();

		controllerManager = GameObject.FindGameObjectWithTag("IGMControllerManager").GetComponent<IGMControllerManager>();

		//1.Create Futile layer.
		//2.Set the Futile object to use the Futile new layer.
		//3. Add lines to Futile.cs line 122
			//Esteban: to use Futile as UI
			//_camera.cullingMask = (1 << 11);
		//4. Comment the line on Futile.cs
			//_camera.clearFlags = CameraClearFlags.SolidColor;
		//5. Uncomment the line on Futile.cs
			//_camera.clearFlags = CameraClearFlags.Depth; //TODO: check if this is faster or not?
		//6. Add to FFacetRenderLayer line 60
			//_gameObject.layer = 11;
			//_stage.layer = 11;
	}

	void AddRedPlayerUI (){

		int xpos = 30;
		int ypos = 0;
		buildingRedBtn = new FButton("buildingRedBtn_tex");
		buildingRedBtn.x = xpos;
		buildingRedBtn.y = ypos;
		buildingRedBtn.SignalRelease += OnButtonHandle;
		stage.AddChild(buildingRedBtn);	

		ypos -= 45;
		energyRedBtn = new FButton("energyRedBtn_tex");
		energyRedBtn.x = xpos;
		energyRedBtn.y = ypos;
		energyRedBtn.SignalRelease += OnButtonHandle;
		stage.AddChild(energyRedBtn);	

		ypos -= 45;
		woodRedBtn = new FButton("woodRedBtn_tex");
		woodRedBtn.x = xpos;
		woodRedBtn.y = ypos;
		woodRedBtn.SignalRelease += OnButtonHandle;
		stage.AddChild(woodRedBtn);

		ypos -= 45;
		stoneRedBtn = new FButton("stoneRedBtn_tex");
		stoneRedBtn.x = xpos;
		stoneRedBtn.y = ypos;
		stoneRedBtn.SignalRelease += OnButtonHandle;
		stage.AddChild(stoneRedBtn);

		ypos -= 45;
		metalRedBtn = new FButton("metalRedBtn_tex");
		metalRedBtn.x = xpos;
		metalRedBtn.y = ypos;
		metalRedBtn.SignalRelease += OnButtonHandle;
		stage.AddChild(metalRedBtn);

		ypos -= 45;
		missileRedBtn = new FButton("missileRedBtn_tex");
		missileRedBtn.x = xpos;
		missileRedBtn.y = ypos;
		missileRedBtn.SignalRelease += OnButtonHandle;
		stage.AddChild(missileRedBtn);

		ypos -= 45;
		factoryRedBtn = new FButton("factoryRedBtn_tex");
		factoryRedBtn.x = xpos;
		factoryRedBtn.y = ypos;
		factoryRedBtn.SignalRelease += OnButtonHandle;
		stage.AddChild(factoryRedBtn);

		ypos -= 45;
		defenderRedBtn = new FButton("defenderRedBtn_tex");
		defenderRedBtn.x = xpos;
		defenderRedBtn.y = ypos;
		defenderRedBtn.SignalRelease += OnButtonHandle;
		stage.AddChild(defenderRedBtn);

		ypos -= 45;
		labRedBtn = new FButton("labRedBtn_tex");
		labRedBtn.x = xpos;
		labRedBtn.y = ypos;
		labRedBtn.SignalRelease += OnButtonHandle;
		stage.AddChild(labRedBtn);

		xpos = 55;
		ypos = 0;
		citizenRedLbl = new FLabel("AbadiRed", "12231");
		citizenRedLbl.alignment = FLabelAlignment.Left;
		citizenRedLbl.x = xpos;
		citizenRedLbl.y = ypos;
		stage.AddChild(citizenRedLbl);

		ypos -= 45;
		energyRedLbl = new FLabel("AbadiRed", "0");
		energyRedLbl.alignment = FLabelAlignment.Left;
		energyRedLbl.x = xpos;
		energyRedLbl.y = ypos;
		stage.AddChild(energyRedLbl);

		ypos -= 45;
		woodRedLbl = new FLabel("AbadiRed", "0");
		woodRedLbl.alignment = FLabelAlignment.Left;
		woodRedLbl.x = xpos;
		woodRedLbl.y = ypos;
		stage.AddChild(woodRedLbl);

		ypos -= 45;
		stoneRedLbl = new FLabel("AbadiRed", "0");
		stoneRedLbl.alignment = FLabelAlignment.Left;
		stoneRedLbl.x = xpos;
		stoneRedLbl.y = ypos;
		stage.AddChild(stoneRedLbl);

		ypos -= 45;
		metalRedLbl = new FLabel("AbadiRed", "0");
		metalRedLbl.alignment = FLabelAlignment.Left;
		metalRedLbl.x = xpos;
		metalRedLbl.y = ypos;
		stage.AddChild(metalRedLbl);

		ypos -= 45;
		missileRedLbl = new FLabel("AbadiRed", "0");
		missileRedLbl.alignment = FLabelAlignment.Left;
		missileRedLbl.x = xpos;
		missileRedLbl.y = ypos;
		stage.AddChild(missileRedLbl);
	}

	void AddBluePlayerUI (){

		int xpos = (int)Futile.screen.width - 30;
		int ypos = 0;
		buildingBlueBtn = new FButton("buildingBlueBtn_tex");
		buildingBlueBtn.x = xpos;
		buildingBlueBtn.y = ypos;
		buildingBlueBtn.rotation = 180;
		buildingBlueBtn.SignalRelease += OnButtonHandle;
		stage.AddChild(buildingBlueBtn);	
		
		ypos += 45;
		energyBlueBtn = new FButton("energyBlueBtn_tex");
		energyBlueBtn.x = xpos;
		energyBlueBtn.y = ypos;
		energyBlueBtn.rotation = 180;
		energyBlueBtn.SignalRelease += OnButtonHandle;
		stage.AddChild(energyBlueBtn);	

		ypos += 45;
		woodBlueBtn = new FButton("woodBlueBtn_tex");
		woodBlueBtn.x = xpos;
		woodBlueBtn.y = ypos;
		woodBlueBtn.rotation = 180;
		woodBlueBtn.SignalRelease += OnButtonHandle;
		stage.AddChild(woodBlueBtn);

		ypos += 45;
		stoneBlueBtn = new FButton("stoneBlueBtn_tex");
		stoneBlueBtn.x = xpos;
		stoneBlueBtn.y = ypos;
		stoneBlueBtn.rotation = 180;
		stoneBlueBtn.SignalRelease += OnButtonHandle;
		stage.AddChild(stoneBlueBtn);

		ypos += 45;
		metalBlueBtn = new FButton("metalBlueBtn_tex");
		metalBlueBtn.x = xpos;
		metalBlueBtn.y = ypos;
		metalBlueBtn.rotation = 180;
		metalBlueBtn.SignalRelease += OnButtonHandle;
		stage.AddChild(metalBlueBtn);

		ypos += 45;
		missileBlueBtn = new FButton("missileBlueBtn_tex");
		missileBlueBtn.x = xpos;
		missileBlueBtn.y = ypos;
		missileBlueBtn.rotation = 180;
		missileBlueBtn.SignalRelease += OnButtonHandle;
		stage.AddChild(missileBlueBtn);

		ypos += 45;
		factoryBlueBtn = new FButton("factoryBlueBtn_tex");
		factoryBlueBtn.x = xpos;
		factoryBlueBtn.y = ypos;
		factoryBlueBtn.rotation = 180;
		factoryBlueBtn.SignalRelease += OnButtonHandle;
		stage.AddChild(factoryBlueBtn);

		ypos += 45;
		defenderBlueBtn = new FButton("defenderBlueBtn_tex");
		defenderBlueBtn.x = xpos;
		defenderBlueBtn.y = ypos;
		defenderBlueBtn.rotation = 180;
		defenderBlueBtn.SignalRelease += OnButtonHandle;
		stage.AddChild(defenderBlueBtn);

		ypos += 45;
		labBlueBtn = new FButton("labBlueBtn_tex");
		labBlueBtn.x = xpos;
		labBlueBtn.y = ypos;
		labBlueBtn.rotation = 180;
		labBlueBtn.SignalRelease += OnButtonHandle;
		stage.AddChild(labBlueBtn);

		xpos = (int)Futile.screen.width - 55;
		ypos = 0;
		citizenBlueLbl = new FLabel("AbadiBlue", "1123sd");
		citizenBlueLbl.alignment = FLabelAlignment.Left;
		citizenBlueLbl.x = xpos;
		citizenBlueLbl.y = ypos;
		citizenBlueLbl.rotation = 180;
		stage.AddChild(citizenBlueLbl);

		ypos += 45;
		energyBlueLbl = new FLabel("AbadiBlue", "345");
		energyBlueLbl.alignment = FLabelAlignment.Left;
		energyBlueLbl.x = xpos;
		energyBlueLbl.y = ypos;
		energyBlueLbl.rotation = 180;
		stage.AddChild(energyBlueLbl);

		ypos += 45;
		woodBlueLbl = new FLabel("AbadiBlue", "9");
		woodBlueLbl.alignment = FLabelAlignment.Left;
		woodBlueLbl.x = xpos;
		woodBlueLbl.y = ypos;
		woodBlueLbl.rotation = 180;
		stage.AddChild(woodBlueLbl);

		ypos += 45;
		stoneBlueLbl = new FLabel("AbadiBlue", "0");
		stoneBlueLbl.alignment = FLabelAlignment.Left;
		stoneBlueLbl.x = xpos;
		stoneBlueLbl.y = ypos;
		stoneBlueLbl.rotation = 180;
		stage.AddChild(stoneBlueLbl);

		ypos += 45;
		metalBlueLbl = new FLabel("AbadiBlue", "0");
		metalBlueLbl.alignment = FLabelAlignment.Left;
		metalBlueLbl.x = xpos;
		metalBlueLbl.y = ypos;
		metalBlueLbl.rotation = 180;
		stage.AddChild(metalBlueLbl);

		ypos += 45;
		missileBlueLbl = new FLabel("AbadiBlue", "0");
		missileBlueLbl.alignment = FLabelAlignment.Left;
		missileBlueLbl.x = xpos;
		missileBlueLbl.y = ypos;
		missileBlueLbl.rotation = 180;
		stage.AddChild(missileBlueLbl);
	}	

	void OnButtonHandle (FButton button){
		controllerManager.OnButtonDown(button.sprite.element.name);
	}

	public void updateLabelText (Players pPlayer, string pLabelName, float value){
		switch(pPlayer){
			case Players.Player1:
			{
				switch(pLabelName){
					case "citizen":
						citizenRedLbl.text = value.ToString();
					break;
					case "energy":
						energyRedLbl.text = value.ToString();
					break;
					case "wood":
						woodRedLbl.text = value.ToString();
					break;
					case "stone":
						stoneRedLbl.text = value.ToString();
					break;
					case "metal":
						metalRedLbl.text = value.ToString();
					break;
					case "missiles":
						missileRedLbl.text = value.ToString();
					break;
					default:
					break;
				}
			}
			break;
			case Players.Player2:
			{
				switch(pLabelName){
					case "citizen":
						citizenBlueLbl.text = value.ToString();
					break;
					case "energy":
						energyBlueLbl.text = value.ToString();
					break;
					case "wood":
						woodBlueLbl.text = value.ToString();
					break;
					case "stone":
						stoneBlueLbl.text = value.ToString();
					break;
					case "metal":
						metalBlueLbl.text = value.ToString();
					break;
					case "missiles":
						missileBlueLbl.text = value.ToString();
					break;
					default:
					break;
				}
			}
			break;
			default:
			break;
		}
	}
	
	public void SetButtonState(Players pPlayer, string pButton, bool value){
		switch(pPlayer){
			case Players.Player1:
			{
				switch(pButton){
					case "building":
						buildingRedBtn.ButtonEnabled = value;
					break;
					case "energy":
						energyRedBtn.ButtonEnabled = value;
					break;
					case "wood":
						woodRedBtn.ButtonEnabled = value;
					break;
					case "stone":
						stoneRedBtn.ButtonEnabled = value;
					break;
					case "metal":
						metalRedBtn.ButtonEnabled = value;
					break;
					case "missile":
						missileRedBtn.ButtonEnabled = value;
					break;
					case "factory":
						factoryRedBtn.ButtonEnabled = value;
					break;
					case "defender":
						defenderRedBtn.ButtonEnabled = value;
					break;
					case "lab":
						labRedBtn.ButtonEnabled = value;
					break;
					default:
					break;
				}
			}
			break;
			case Players.Player2:
			{
				switch(pButton){
					case "building":
						buildingBlueBtn.ButtonEnabled = value;
					break;
					case "energy":
						energyBlueBtn.ButtonEnabled = value;
					break;
					case "wood":
						woodBlueBtn.ButtonEnabled = value;
					break;
					case "stone":
						stoneBlueBtn.ButtonEnabled = value;
					break;
					case "metal":
						metalBlueBtn.ButtonEnabled = value;
					break;
					case "missile":
						missileBlueBtn.ButtonEnabled = value;
					break;
					case "factory":
						factoryBlueBtn.ButtonEnabled = value;
					break;
					case "defender":
						defenderBlueBtn.ButtonEnabled = value;
					break;
					case "lab":
						labBlueBtn.ButtonEnabled = value;
					break;
					default:
					break;
				}
			}
			break;
			default:
			break;
		}
	}

	public void ShutDown () {
		Futile.RemoveStage(stage);
	}
}
