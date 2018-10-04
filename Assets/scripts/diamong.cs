using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class diamong : MonoBehaviour
{
	private int counter = 0;
	public bool isdisappearing = false;

	private void Update()
	{
		  
		if (isdisappearing)
		{
			counter++;
			if (counter >= 50)
			{
				GetComponent<SpriteRenderer>().enabled = true;     
				GetComponent<BoxCollider2D>().enabled = true;
				isdisappearing = false;
				counter = 0;
			}
		}
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		other.GetComponent<character>().grounded2 = true;

		if (other.GetComponent<character>().grounded2)
		
		//Destroy((gameObject));
		//GetComponent<CharacterControl>().enabled=false;          
		GetComponent<SpriteRenderer>().enabled = false;     
		GetComponent<BoxCollider2D>().enabled = false;
		isdisappearing = true;


	}
}
