using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ViewManager : MonoBehaviour {

	private ControllerManager controllerManager;

	private FButton playBtn;
	private FLabel titleLbl;
	private FLabel descriptionLbl;
	private FLabel winnerLbl;
	private FStage stage;

	void Start(){	

		FutileParams fparams = new FutileParams (false, false, true, true);
		
		if(Screen.height == 2048){
			fparams.AddResolutionLevel (Screen.width, 2.0f, 1.0f, "");
		}else{
			fparams.AddResolutionLevel (Screen.width, 1.0f, 1.0f, "");
		}

		fparams.origin = new Vector2 (0, 0.5f);
		Futile.instance.Init (fparams);
		stage = Futile.stage;
		Futile.atlasManager.LoadAtlas ("Atlases/bocaraButtons");
		Futile.atlasManager.LoadFont("AbadiBlue", "AbadiBlue", "Atlases/AbadiBlue", 0.0f, 0.0f);
		Futile.atlasManager.LoadFont("AbadiRed", "AbadiRed", "Atlases/AbadiRed", 0.0f, 0.0f);
		Futile.atlasManager.LoadFont("Abadi55", "Abadi55", "Atlases/Abadi55", 0.0f, 0.0f);

		controllerManager = GameObject.FindGameObjectWithTag("ControllerManager").GetComponent<ControllerManager>();

		//1.Create futile layer.
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

		int xpos = (int)Futile.screen.width / 2;
		int ypos = 0;		
		
		ypos += 50;
		titleLbl = new FLabel("AbadiRed", "Welcome Bobies" );
		titleLbl.x = xpos;
		titleLbl.y = ypos;
		titleLbl.alignment = FLabelAlignment.Center;
		stage.AddChild(titleLbl);
		
		ypos = 0;
		descriptionLbl = new FLabel("AbadiBlue", "On this game player need to manage the world resources\nwhile trying to destroy the other players buildings and weapons.");
		descriptionLbl.x = xpos;
		descriptionLbl.y = ypos;
		descriptionLbl.alignment = FLabelAlignment.Center;
		stage.AddChild(descriptionLbl);

		ypos -= 75;
		playBtn = new FButton("idleBlueBtn_tex", "overBlueBtn_tex");
		playBtn.AddLabel("AbadiBlue", "PLAY", Color.white);
		playBtn.x = xpos;
		playBtn.y = ypos;
		playBtn.SignalRelease += OnButtonHandle;
		stage.AddChild(playBtn);
	}

	void OnButtonHandle (FButton button){
		controllerManager.OnButtonDown(button.sprite.element.name);
	}
	
	public void ShutDown (){
		Futile.RemoveStage(stage);
	}

	public void ShowWinner () {
		winnerLbl = new FLabel("Abadi55", Data.winner.ToString());
		winnerLbl.x = ( Screen.width / 2 ) - 100;
		winnerLbl.y = 225;
		winnerLbl.alignment = FLabelAlignment.Center;
		stage.AddChild(winnerLbl);
	}
}
