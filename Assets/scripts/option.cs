using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using  UnityEngine.SceneManagement;
using System;
using  UnityEditor;

public class option : MonoBehaviour
{

	public Transform pos1;

	public Transform pos2;

	public int choice = 1;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
		if (Input.GetKeyDown(KeyCode.UpArrow))
			{
				choice = 1;
				transform.position = pos1.position;
			}
			if (Input.GetKeyDown(KeyCode.DownArrow))
			{
				choice = 2;
				transform.position = pos2.position;
			}
	
			if (choice == 1 && Input.GetKeyDown("c"))//开始游戏
			{
				SceneManager.LoadScene(2);
			}
		   if (choice == 2 && Input.GetKeyDown("c"))//退出
			   Application.Quit();
	}
	
	
}
