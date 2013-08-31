using UnityEngine;
using System.Collections;

public class Missile : MonoBehaviour {

	private float destructionPower = 7.0f;
	private float speed = 2.0f;

	public float DestructionPower {
		get {
			return destructionPower;
		}
		set {
			destructionPower = value;
		}
	}

	void Start () {
		
	}
	
	void Update () {
		//TODO: add animation 
		this.gameObject.transform.Translate (0, speed * Time.deltaTime, 0);
	
	}

	void OnCollisionEnter(Collision collision) {
		GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>().PlayAudio("missionExplotion");
	}


    void OnTriggerEnter(Collider other) {
		
		GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>().PlayAudio("missionExplotion");
    }
}
