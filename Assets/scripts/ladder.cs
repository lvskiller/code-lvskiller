using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ladder : MonoBehaviour {
	
	private void OnCollisionEnter2D(Collision2D other)
	{
		StartCoroutine(DelayToInvoke.DelayToInvokeDo(() =>

		{
			Destroy(gameObject);
		}, 2.0f));
	}
	}
