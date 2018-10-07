using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moving : MonoBehaviour
{
	public Rigidbody2D block;
	private void OnCollisionEnter2D(Collision2D other)
	{
			block.velocity=new Vector2(30,0);
	
		 
	}
}
