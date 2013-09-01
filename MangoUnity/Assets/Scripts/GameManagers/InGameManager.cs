using UnityEngine;
using System.Collections;
public enum Players{Player1, Player2}


public class InGameManager : MonoBehaviour {
	
	public enum FacilityType{ building, missileDefender, energyPlant,	woodMill };
	public enum PlayerType{ player1 = 1, player2 = 2 };

	public Camera gameCamera;	
	
	public GameObject building;
	public GameObject energyPlant;
	public GameObject factory;
	public GameObject lab;
	public GameObject missile;
	public GameObject missileDefender;
	public GameObject missileLauncher;
	public GameObject quarry;
	public GameObject woodMill;
	public GameObject metalFactory;

	public GameObject p1World;
	public GameObject p2World;
	
	private IGMControllerManager controllerManager;
	private bool canAddMissile = true;
	private Player player1;
	private Player player2;
	

	// Use this for initialization
	void Start () {
		Data data = new Data();
		controllerManager = GameObject.FindGameObjectWithTag("IGMControllerManager").GetComponent<IGMControllerManager>();
		player1 = new Player(this);
		player1.Type = Players.Player1;
		player2 = new Player(this);
		player2.Type = Players.Player2;
		Invoke("UpdatePlayersOnInit", 0.1f);
	}
	
	void UpdatePlayersOnInit(){
		UpdatePlayer(player1);
		UpdatePlayer(player2);

		AddEnergyPlant(Players.Player1);
		AddBuilding(Players.Player1);
		AddWoodMill(Players.Player1);
		AddQuarry(Players.Player1);
		AddMetalFactory(Players.Player1);
		
		AddEnergyPlant(Players.Player2);
		AddBuilding(Players.Player2);
		AddWoodMill(Players.Player2);
		AddQuarry(Players.Player2);
		AddMetalFactory(Players.Player2);
		
	}

	private void SetWinner (){

		if(player1.Citizens > 0){
			EndGame();	
			Data.winner = "Player 1 Wins!";
		}else if(player2.Citizens > 0){
			EndGame();
			Data.winner = "Player 2 Wins!";
		}
	}

	private void EndGame () {
		controllerManager.ShutDown();
		Application.LoadLevel("menuScreen");
	}

	public void CheckPlayerResources (Players pPlayer){
	
		switch(pPlayer){
			case Players.Player1:
			{
				//checking on building
				if(player1.Wood >= Data.building.wood 
					&& player1.Stone >= Data.building.stone
					&& player1.Metal >= Data.building.metal
					&& ((player1.EnergyAvailable - Data.building.energyRequired) >= 0)){
					controllerManager.SetButtonState(player1, "building", true);
				}else{
					controllerManager.SetButtonState(player1, "building", false);
				}
		
				//checkin for energyPlant
				if(player1.Wood >= Data.energyPlant.wood 
					&& player1.Stone >= Data.energyPlant.stone 
					&& player1.Metal >= Data.energyPlant.metal ){
					controllerManager.SetButtonState(player1, "energy", true);
				}else{
					controllerManager.SetButtonState(player1, "energy", false);
				}
				
				//checking on WoodMiil
				if(player1.Wood >= Data.woodMill.wood 
					&& player1.Stone >= Data.woodMill.stone
					&& player1.Metal >= Data.woodMill.metal
					&& ((player1.EnergyAvailable - Data.woodMill.energyRequired) >= 0)
					&& ((player1.Citizens - Data.woodMill.worker) >= 0)) {
					controllerManager.SetButtonState(player1, "wood", true);
				}else{
					controllerManager.SetButtonState(player1, "wood", false);
				}
		
				//checking on Quarry
				if(player1.Wood >= Data.quarry.wood 
					&& player1.Stone >= Data.quarry.stone
					&& player1.Metal >= Data.quarry.metal
					&& ((player1.EnergyAvailable - Data.quarry.energyRequired) >= 0)
					&& ((player1.Citizens - Data.quarry.worker) >= 0)) {
					controllerManager.SetButtonState(player1, "stone", true);
				}else{
					controllerManager.SetButtonState(player1, "stone", false);
				}
		
				//checking on MetalFactory
				if(player1.Wood >= Data.metalFactory.wood 
					&& player1.Stone >= Data.metalFactory.stone
					&& player1.Metal >= Data.metalFactory.metal
					&& ((player1.EnergyAvailable - Data.metalFactory.energyRequired) >= 0)
					&& ((player1.Citizens - Data.metalFactory.worker) >= 0)) {
					controllerManager.SetButtonState(player1, "metal", true);
				}else{
					controllerManager.SetButtonState(player1, "metal", false);
				}
		
				//checking on Missile Launcher
				if(player1.Wood >= Data.missileLauncher.wood 
					&& player1.Stone >= Data.missileLauncher.stone
					&& player1.Metal >= Data.missileLauncher.metal
					&& ((player1.EnergyAvailable - Data.missileLauncher.energyRequired) >= 0)
					&& ((player1.Citizens - Data.missileLauncher.worker) >= 0)) {	
					controllerManager.SetButtonState(player1, "missile", true);
				}else{
					controllerManager.SetButtonState(player1, "missile", false);
				}
		
				//checking on Factory
				if(player1.Wood >= Data.factory.wood 
					&& player1.Stone >= Data.factory.stone
					&& player1.Metal >= Data.factory.metal
					&& ((player1.EnergyAvailable - Data.factory.energyRequired) >= 0)
					&& ((player1.Citizens - Data.factory.worker) >= 0)) {
					controllerManager.SetButtonState(player1, "factory", true);
				}else{
					controllerManager.SetButtonState(player1, "factory", false);
				}
		
				//checking on Missile Defender
				if(player1.Wood >= Data.missileDefender.wood 
					&& player1.Stone >= Data.missileDefender.stone
					&& player1.Metal >= Data.missileDefender.metal
					&& ((player1.EnergyAvailable - Data.missileDefender.energyRequired) >= 0)
					&& ((player1.Citizens - Data.missileDefender.worker) >= 0)) {
					controllerManager.SetButtonState(player1, "defender", true);
				}else{
					controllerManager.SetButtonState(player1, "defender", false);
				}
		
				//checking on Missile Lab
				if(player1.Wood >= Data.lab.wood 
					&& player1.Stone >= Data.lab.stone
					&& player1.Metal >= Data.lab.metal
					&& ((player1.EnergyAvailable - Data.lab.energyRequired) >= 0)
					&& ((player1.Citizens - Data.lab.worker) >= 0)) {
					controllerManager.SetButtonState(player1, "lab", true);
				}else{
					controllerManager.SetButtonState(player1, "lab", false);
				}
			}
			break;
			case Players.Player2:
			{
				//checking on building
				if(player2.Wood >= Data.building.wood 
					&& player2.Stone >= Data.building.stone
					&& player2.Metal >= Data.building.metal
					&& ((player2.EnergyAvailable - Data.building.energyRequired) >= 0)){
					controllerManager.SetButtonState(player2, "building", true);
				}else{
					controllerManager.SetButtonState(player2, "building", false);
				}
		
				//checkin for energyPlant
				if(player2.Wood >= Data.energyPlant.wood 
					&& player2.Stone >= Data.energyPlant.stone 
					&& player2.Metal >= Data.energyPlant.metal 
					&& (player2.Citizens - Data.energyPlant.worker >= 0)){
					controllerManager.SetButtonState(player2, "energy", true);
				}else{
					controllerManager.SetButtonState(player2, "energy", false);
				}
				
				//checking on WoodMiil
				if(player2.Wood >= Data.woodMill.wood 
					&& player2.Stone >= Data.woodMill.stone
					&& player2.Metal >= Data.woodMill.metal
					&& ((player2.EnergyAvailable - Data.woodMill.energyRequired) >= 0)){
					controllerManager.SetButtonState(player2, "wood", true);
				}else{
					controllerManager.SetButtonState(player2, "wood", false);
				}
		
				//checking on Quarry
				if(player2.Wood >= Data.quarry.wood 
					&& player2.Stone >= Data.quarry.stone
					&& player2.Metal >= Data.quarry.metal
					&& ((player2.EnergyAvailable - Data.quarry.energyRequired) >= 0)){
					controllerManager.SetButtonState(player2, "stone", true);
				}else{
					controllerManager.SetButtonState(player2, "stone", false);
				}
		
				//checking on MetalFactory
				if(player2.Wood >= Data.metalFactory.wood 
					&& player2.Stone >= Data.metalFactory.stone
					&& player2.Metal >= Data.metalFactory.metal
					&& ((player2.EnergyAvailable - Data.metalFactory.energyRequired) >= 0)){
					controllerManager.SetButtonState(player2, "metal", true);
				}else{
					controllerManager.SetButtonState(player2, "metal", false);
				}
		
				//checking on Missile Launcher
				if(player2.Wood >= Data.missileLauncher.wood 
					&& player2.Stone >= Data.missileLauncher.stone
					&& player2.Metal >= Data.missileLauncher.metal
					&& ((player2.EnergyAvailable - Data.missileLauncher.energyRequired) >= 0)){
					controllerManager.SetButtonState(player2, "missile", true);
				}else{
					controllerManager.SetButtonState(player2, "missile", false);
				}
		
				//checking on Factory
				if(player2.Wood >= Data.factory.wood 
					&& player2.Stone >= Data.factory.stone
					&& player2.Metal >= Data.factory.metal
					&& ((player2.EnergyAvailable - Data.factory.energyRequired) >= 0)){
					controllerManager.SetButtonState(player2, "factory", true);
				}else{
					controllerManager.SetButtonState(player2, "factory", false);
				}
		
				//checking on Missile Defender
				if(player2.Wood >= Data.missileDefender.wood 
					&& player2.Stone >= Data.missileDefender.stone
					&& player2.Metal >= Data.missileDefender.metal
					&& ((player2.EnergyAvailable - Data.missileDefender.energyRequired) >= 0)){
					controllerManager.SetButtonState(player2, "defender", true);
				}else{
					controllerManager.SetButtonState(player2, "defender", false);
				}
		
				//checking on Missile Lab
				if(player2.Wood >= Data.lab.wood 
					&& player2.Stone >= Data.lab.stone
					&& player2.Metal >= Data.lab.metal
					&& ((player2.EnergyAvailable - Data.lab.energyRequired) >= 0)){
					controllerManager.SetButtonState(player2, "lab", true);
				}else{
					controllerManager.SetButtonState(player2, "lab", false);
				}
			}
			break;
			default:
			break;
		}
	}


	// Update is called once per frame
	void Update () {
		
        Ray ray = gameCamera.ScreenPointToRay(Input.mousePosition);
		
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 1000)){
            Debug.DrawLine(ray.origin, hit.point, Color.red, 20.0f, true);
			//Debug.Log(hit.collider.gameObject.name);
    	}

		if (Input.GetMouseButton(0) && canAddMissile){
			//Debug.Log("Pressed left click.");
			//Debug.Log("x: "+ ray.origin.x);
			//Debug.Log("y: "+ ray.origin.y);
			//canAddMissile = false;
			//AddMissile(new Vector3(ray.origin.x, ray.origin.y, 17.0f));
		}

	}

	public void AddBuilding (Players pPlayer){	
		int slotPosition = 0;
		GameObject go;
		WorldSlot slot = null;
		Vector3 worldRotation = Vector3.zero;
		
		switch (pPlayer) {
			case Players.Player1:
			{
				worldRotation = p1World.transform.rotation.eulerAngles;
				slotPosition = (int)(360 - worldRotation.z) / 9;	
				slot = p1World.GetComponent<World>().GetFreeSlot(slotPosition);

				if(slot != null){
					go = Instantiate(building, slot.Position, Quaternion.identity) as GameObject;
					go.name = "p1_building_pref" + Facility.id;		
					go.transform.Rotate(new Vector3(0, 0, 1), slot.Angle);
					go.gameObject.transform.parent = p1World.transform;
					AddFacility(go.GetComponent<Facility>(), pPlayer);
				}
			}
			break;
			case Players.Player2:
			{
				worldRotation = p2World.transform.rotation.eulerAngles;
				slotPosition = (int)(360 - worldRotation.z) / 9;
				
				//add to the index and start adding facilities 180 degrees down
				if(slotPosition < 20){
					slotPosition += 20;
				}else{
					slotPosition -= 20;
				}				

				slot = p2World.GetComponent<World>().GetFreeSlot(slotPosition);

				if(slot != null){
					go = Instantiate(building, slot.Position, Quaternion.identity) as GameObject;
					go.name = "p2_building_pref" + Facility.id;				
					go.transform.Rotate(new Vector3(0, 0, 1), slot.Angle);
					go.gameObject.transform.parent = p2World.transform;
					AddFacility(go.GetComponent<Facility>(), pPlayer);
				}
			}
			break;
			default:
			break;
		}
	}


	public void AddEnergyPlant(Players pPlayer){

		int slotPosition = 0;
		GameObject go;
		WorldSlot slot = null;
		Vector3 worldRotation = Vector3.zero;

		switch (pPlayer) {
			case Players.Player1:
			{
				worldRotation = p1World.transform.rotation.eulerAngles;
				slotPosition = (int)(360 - worldRotation.z) / 9;	
				slot = p1World.GetComponent<World>().GetFreeSlot(slotPosition);

				if(slot != null){
					go = Instantiate(energyPlant, slot.Position, Quaternion.identity) as GameObject;
					go.transform.parent = p1World.transform;
					go.name = "p1_energyPlant_" + Facility.id;
					go.transform.Rotate(new Vector3(0, 0, 1), slot.Angle);
					AddFacility(go.GetComponent<Facility>(), pPlayer);
				}
			}
			break;
			case Players.Player2:
			{
				worldRotation = p2World.transform.rotation.eulerAngles;
				slotPosition = (int)(360 - worldRotation.z) / 9;
				
				//add to the index and start adding facilities 180 degrees down
				if(slotPosition < 20){
					slotPosition += 20;
				}else{
					slotPosition -= 20;
				}				

				slot = p2World.GetComponent<World>().GetFreeSlot(slotPosition);

				if(slot != null){
					go = Instantiate(energyPlant, slot.Position, Quaternion.identity) as GameObject;
					go.transform.Rotate(new Vector3(0, 0, 1), slot.Angle);
					go.transform.parent = p2World.transform;
					go.name = "p2_energyPlant_" + Facility.id;
					AddFacility(go.GetComponent<Facility>(), pPlayer);
				}	
			}
			break;
			default:
			break;
		}

	}


	public void AddWoodMill(Players pPlayer){
		int slotPosition = 0;
		GameObject go;
		WorldSlot slot = null;
		Vector3 worldRotation = Vector3.zero;

		switch (pPlayer) {
			case Players.Player1:
			{
				worldRotation = p1World.transform.rotation.eulerAngles;
				slotPosition = (int)(360 - worldRotation.z) / 9;	
				slot = p1World.GetComponent<World>().GetFreeSlot(slotPosition);

				if(slot != null){
					go = Instantiate(woodMill, slot.Position, Quaternion.identity) as GameObject;
					go.transform.parent = p1World.transform;
					go.name = "p1_woodMill_" + Facility.id;
					go.transform.Rotate(new Vector3(0, 0, 1), slot.Angle);
					AddFacility(go.GetComponent<Facility>(), pPlayer);
				}
			}
			break;
			case Players.Player2:
			{
				worldRotation = p2World.transform.rotation.eulerAngles;
				slotPosition = (int)(360 - worldRotation.z) / 9;
				
				//add to the index and start adding facilities 180 degrees down
				if(slotPosition < 20){
					slotPosition += 20;
				}else{
					slotPosition -= 20;
				}				

				slot = p2World.GetComponent<World>().GetFreeSlot(slotPosition);

				if(slot != null){
					go = Instantiate(woodMill, slot.Position, Quaternion.identity) as GameObject;
					go.transform.Rotate(new Vector3(0, 0, 1), slot.Angle);
					go.transform.parent = p2World.transform;
					go.name = "p2_woodMill_" + Facility.id;
					AddFacility(go.GetComponent<Facility>(), pPlayer);
				}	
			}
			break;
			default:
			break;
		}
	}
	
	public void AddQuarry(Players pPlayer){
		int slotPosition = 0;
		GameObject go;
		WorldSlot slot = null;
		Vector3 worldRotation = Vector3.zero;

		switch (pPlayer) {
			case Players.Player1:
			{
				worldRotation = p1World.transform.rotation.eulerAngles;
				slotPosition = (int)(360 - worldRotation.z) / 9;	
				slot = p1World.GetComponent<World>().GetFreeSlot(slotPosition);

				if(slot != null){
					go = Instantiate(quarry, slot.Position, Quaternion.identity) as GameObject;
					go.transform.parent = p1World.transform;
					go.name = "p1_quarry_" + Facility.id;
					go.transform.Rotate(new Vector3(0, 0, 1), slot.Angle);
					AddFacility(go.GetComponent<Facility>(), pPlayer);
				}
			}
			break;
			case Players.Player2:
			{
				worldRotation = p2World.transform.rotation.eulerAngles;
				slotPosition = (int)(360 - worldRotation.z) / 9;
				
				//add to the index and start adding facilities 180 degrees down
				if(slotPosition < 20){
					slotPosition += 20;
				}else{
					slotPosition -= 20;
				}				

				slot = p2World.GetComponent<World>().GetFreeSlot(slotPosition);

				if(slot != null){
					go = Instantiate(quarry, slot.Position, Quaternion.identity) as GameObject;
					go.transform.Rotate(new Vector3(0, 0, 1), slot.Angle);
					go.transform.parent = p2World.transform;
					go.name = "p2_quarry_" + Facility.id;
					AddFacility(go.GetComponent<Facility>(), pPlayer);
				}	
			}
			break;
			default:
			break;
		}	
	}


	public void AddMetalFactory(Players pPlayer){
		int slotPosition = 0;
		GameObject go;
		WorldSlot slot = null;
		Vector3 worldRotation = Vector3.zero;

		switch (pPlayer) {
			case Players.Player1:
			{
				worldRotation = p1World.transform.rotation.eulerAngles;
				slotPosition = (int)(360 - worldRotation.z) / 9;	
				slot = p1World.GetComponent<World>().GetFreeSlot(slotPosition);

				if(slot != null){
					go = Instantiate(metalFactory, slot.Position, Quaternion.identity) as GameObject;
					go.transform.parent = p1World.transform;
					go.name = "p1_metalFactory_" + Facility.id;
					go.transform.Rotate(new Vector3(0, 0, 1), slot.Angle);
					AddFacility(go.GetComponent<Facility>(), pPlayer);
				}
			}
			break;
			case Players.Player2:
			{
				worldRotation = p2World.transform.rotation.eulerAngles;
				slotPosition = (int)(360 - worldRotation.z) / 9;
				
				//add to the index and start adding facilities 180 degrees down
				if(slotPosition < 20){
					slotPosition += 20;
				}else{
					slotPosition -= 20;
				}				

				slot = p2World.GetComponent<World>().GetFreeSlot(slotPosition);

				if(slot != null){
					go = Instantiate(metalFactory, slot.Position, Quaternion.identity) as GameObject;
					go.transform.Rotate(new Vector3(0, 0, 1), slot.Angle);
					go.transform.parent = p2World.transform;
					go.name = "p2_metalFactory_" + Facility.id;
					AddFacility(go.GetComponent<Facility>(), pPlayer);
				}	
			}
			break;
			default:
			break;
		}	
	}
	
	
	public void AddFactory(Players pPlayer){
		int slotPosition = 0;
		GameObject go;
		WorldSlot slot = null;
		Vector3 worldRotation = Vector3.zero;

		switch (pPlayer) {
			case Players.Player1:
			{
				worldRotation = p1World.transform.rotation.eulerAngles;
				slotPosition = (int)(360 - worldRotation.z) / 9;	
				slot = p1World.GetComponent<World>().GetFreeSlot(slotPosition);

				if(slot != null){
					go = Instantiate(factory, slot.Position, Quaternion.identity) as GameObject;
					go.transform.parent = p1World.transform;
					go.name = "p1_factory_" + Facility.id;
					go.transform.Rotate(new Vector3(0, 0, 1), slot.Angle);
					AddFacility(go.GetComponent<Facility>(), pPlayer);
				}
			}
			break;
			case Players.Player2:
			{
				worldRotation = p2World.transform.rotation.eulerAngles;
				slotPosition = (int)(360 - worldRotation.z) / 9;
				
				//add to the index and start adding facilities 180 degrees down
				if(slotPosition < 20){
					slotPosition += 20;
				}else{
					slotPosition -= 20;
				}				

				slot = p2World.GetComponent<World>().GetFreeSlot(slotPosition);

				if(slot != null){
					go = Instantiate(factory, slot.Position, Quaternion.identity) as GameObject;
					go.transform.Rotate(new Vector3(0, 0, 1), slot.Angle);
					go.transform.parent = p2World.transform;
					go.name = "p2_factory_" + Facility.id;
					AddFacility(go.GetComponent<Facility>(), pPlayer);
				}	
			}
			break;
			default:
			break;
		}	
	}

	public void AddLab(Players pPlayer){
		int slotPosition = 0;
		GameObject go;
		WorldSlot slot = null;
		Vector3 worldRotation = Vector3.zero;

		switch (pPlayer) {
			case Players.Player1:
			{
				worldRotation = p1World.transform.rotation.eulerAngles;
				slotPosition = (int)(360 - worldRotation.z) / 9;	
				slot = p1World.GetComponent<World>().GetFreeSlot(slotPosition);

				if(slot != null){
					go = Instantiate(lab, slot.Position, Quaternion.identity) as GameObject;
					go.transform.parent = p1World.transform;
					go.name = "p1_lab_" + Facility.id;
					go.transform.Rotate(new Vector3(0, 0, 1), slot.Angle);
					AddFacility(go.GetComponent<Facility>(), pPlayer);
				}
			}
			break;
			case Players.Player2:
			{
				worldRotation = p2World.transform.rotation.eulerAngles;
				slotPosition = (int)(360 - worldRotation.z) / 9;
				
				//add to the index and start adding facilities 180 degrees down
				if(slotPosition < 20){
					slotPosition += 20;
				}else{
					slotPosition -= 20;
				}				

				slot = p2World.GetComponent<World>().GetFreeSlot(slotPosition);

				if(slot != null){
					go = Instantiate(lab, slot.Position, Quaternion.identity) as GameObject;
					go.transform.Rotate(new Vector3(0, 0, 1), slot.Angle);
					go.transform.parent = p2World.transform;
					go.name = "p2_lab_" + Facility.id;
					AddFacility(go.GetComponent<Facility>(), pPlayer);
				}	
			}
			break;
			default:
			break;
		}	
	}

	public void AddMissileDefender(Players pPlayer){
		int slotPosition = 0;
		GameObject go;
		WorldSlot slot = null;
		Vector3 worldRotation = Vector3.zero;

		switch (pPlayer) {
			case Players.Player1:
			{
				worldRotation = p1World.transform.rotation.eulerAngles;
				slotPosition = (int)(360 - worldRotation.z) / 9;	
				slot = p1World.GetComponent<World>().GetFreeSlot(slotPosition);

				if(slot != null){
					go = Instantiate(missileDefender, slot.Position, Quaternion.identity) as GameObject;
					go.transform.parent = p1World.transform;
					go.name = "p1_missileDefender_" + Facility.id;
					go.transform.Rotate(new Vector3(0, 0, 1), slot.Angle);
					go.GetComponent<MissileDefender>().MissileName = "p2m";
					AddFacility(go.GetComponent<Facility>(), pPlayer);
				}
			}
			break;
			case Players.Player2:
			{
				worldRotation = p2World.transform.rotation.eulerAngles;
				slotPosition = (int)(360 - worldRotation.z) / 9;
				
				//add to the index and start adding facilities 180 degrees down
				if(slotPosition < 20){
					slotPosition += 20;
				}else{
					slotPosition -= 20;
				}				

				slot = p2World.GetComponent<World>().GetFreeSlot(slotPosition);

				if(slot != null){
					go = Instantiate(missileDefender, slot.Position, Quaternion.identity) as GameObject;
					go.transform.Rotate(new Vector3(0, 0, 1), slot.Angle);
					go.transform.parent = p2World.transform;
					go.name = "p2_missileDefender_" + Facility.id;
					go.GetComponent<MissileDefender>().MissileName = "p1m";
					AddFacility(go.GetComponent<Facility>(), pPlayer);
				}	
			}
			break;
			default:
			break;
		}	
	}

	public void AddMissileLauncher(Players pPlayer){

		int slotPosition = 0;
		GameObject go;
		WorldSlot slot = null;
		Vector3 worldRotation = Vector3.zero;

		switch (pPlayer) {
			case Players.Player1:
			{
				worldRotation = p1World.transform.rotation.eulerAngles;
				slotPosition = (int)(360 - worldRotation.z) / 9;	
				slot = p1World.GetComponent<World>().GetFreeSlot(slotPosition);

				if(slot != null){
					go = Instantiate(missileLauncher, slot.Position, Quaternion.identity) as GameObject;
					go.transform.parent = p1World.transform;
					go.name = "p1_missileLauncher_" + Facility.id;
					go.transform.Rotate(new Vector3(0, 0, 1), slot.Angle);
					AddFacility(go.GetComponent<Facility>(), pPlayer);
				}
			}
			break;
			case Players.Player2:
			{
				worldRotation = p2World.transform.rotation.eulerAngles;
				slotPosition = (int)(360 - worldRotation.z) / 9;
				
				//add to the index and start adding facilities 180 degrees down
				if(slotPosition < 20){
					slotPosition += 20;
				}else{
					slotPosition -= 20;
				}				

				slot = p2World.GetComponent<World>().GetFreeSlot(slotPosition);

				if(slot != null){
					go = Instantiate(missileLauncher, slot.Position, Quaternion.identity) as GameObject;
					go.transform.Rotate(new Vector3(0, 0, 1), slot.Angle);
					go.transform.parent = p2World.transform;
					go.name = "p2_missileLauncher_" + Facility.id;
					AddFacility(go.GetComponent<Facility>(), pPlayer);
				}	
			}
			break;
			default:
			break;
		}
	
	}

	private void AddFacility(Facility pFacility, Players pPlayer){	
		switch(pPlayer){
			case Players.Player1:
				pFacility.Owner = player1;
				player1.Citizens 		+= pFacility.Citizen;
				player1.Citizens    	-= pFacility.Worker;
				player1.EnergyAvailable += pFacility.EnergyProduced;
				player1.EnergyAvailable -= pFacility.EnergyRequired;
				player1.Wood 			-= pFacility.Wood;
				player1.Metal    		-= pFacility.Metal;
				player1.Stone    		-= pFacility.Stone;
				UpdatePlayer(player1);
			break;
			case Players.Player2:
				pFacility.Owner = player2;
				player2.Citizens 		+= pFacility.Citizen;
				player2.Citizens    	-= pFacility.Worker;
				player2.EnergyAvailable += pFacility.EnergyProduced;
				player2.EnergyAvailable -= pFacility.EnergyRequired;
				player2.Wood 			-= pFacility.Wood;
				player2.Metal    		-= pFacility.Metal;
				player2.Stone    		-= pFacility.Stone;
				UpdatePlayer(player2);
			break;
			default:
			break;
		}
		
		CheckPlayerResources(pPlayer);
	}

	public void RemoveFacility(Facility pFacility, Player pPlayer){
		
		switch(pPlayer.Type){
			case Players.Player1:
				player1.Citizens 		-= pFacility.Citizen;
				player1.Citizens    	+= pFacility.Worker;
				player1.EnergyAvailable	 -= pFacility.EnergyProduced;
				player1.EnergyAvailable  += pFacility.EnergyRequired;
				//player1.Wood 			+= pFacility.Wood;
				//player1.Metal    		+= pFacility.Metal;
				//player1.Stone    		+= pFacility.Stone;
				UpdatePlayer(player1);
				
			break;
			case Players.Player2:
				player2.Citizens 		 -= pFacility.Citizen;
				player2.Citizens    	 += pFacility.Worker;
				player2.EnergyAvailable	 -= pFacility.EnergyProduced;
				player2.EnergyAvailable  += pFacility.EnergyRequired;
				//player2.Wood 			+= pFacility.Wood;
				//player2.Metal    		+= pFacility.Metal;
				//player2.Stone    		+= pFacility.Stone;
				UpdatePlayer(player2);
			break;
			default:
			break;
		}

		CheckPlayerResources(pPlayer.Type);
		SetWinner();		
	}

	private void AddMissile(Vector3 pPosition){
		GameObject m = Instantiate(missile, pPosition, new Quaternion(0, 0, 0,0)) as GameObject;
		m.name = "p1m";
		Invoke("EnableAddingMissile", 0.1f);
	}
	
	private void EnableAddingMissile(){
		canAddMissile = true;
	}
	
	public void UpdatePlayer(Player pPlayer){
		controllerManager.updateViewLabelText(pPlayer);
	}
}
