using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

public class changnext : MonoBehaviour {
	private void OnTriggerEnter2D(Collider2D other)
	{
		
		SceneManager.LoadScene(2);
	}
}
