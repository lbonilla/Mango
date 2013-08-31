using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TimerScript : MonoBehaviour {
public float startTime;
public float restSeconds;
public int roundedRestSeconds;
private float displaySeconds;
private float displayMinutes;
public int CountDownSeconds=5;
public float Timeleft;
string timetext;
 
public bool isComplete = false;
 
// Use this for initialization
 
void Start () 
{
    startTime=Time.deltaTime;
 
}
 
	void Update()
	{
 
		if(isComplete)
			return;

		Timeleft = Time.time - startTime;
		restSeconds = CountDownSeconds - (Timeleft);
	
		roundedRestSeconds = Mathf.CeilToInt(restSeconds);
	//displaySeconds = roundedRestSeconds % 60;
	//displayMinutes = (roundedRestSeconds / 60)%60;
	
//	timetext = (displayMinutes.ToString()+":");
//
//	if (displaySeconds > 9)
//	{
//		timetext = timetext + displaySeconds.ToString();
//	}
//	else 
//	{
//		timetext = timetext + "0" + displaySeconds.ToString();
//	}
	
	guiText.text = roundedRestSeconds+"";
	//GUI.Label(new Rect(650.0f, 0.0f, 100.0f, 75.0f), timetext);
	if(roundedRestSeconds == 0){
		startTime=Time.deltaTime;
		Debug.Log("Completed");
		isComplete = true;
		Reset();
	}
	
	}

	void Reset ()
	{

		//isComplete = false;
		Timeleft=0;
		restSeconds = 5;
		CountDownSeconds=5;
		roundedRestSeconds=5;
	}
}