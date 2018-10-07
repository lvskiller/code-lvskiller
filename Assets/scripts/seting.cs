using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using  UnityEditor;
public class seting : MonoBehaviour
{

	private bool paused=false;
	void Start () {
		
	}
	void Update () {
		if (Input.GetKey(KeyCode.P))
			paused =!paused;
		if (paused) Time.timeScale = 0;
		else Time.timeScale = 1;
		if(Input.GetKey("q"))
			Application.Quit();
	}
	
}
