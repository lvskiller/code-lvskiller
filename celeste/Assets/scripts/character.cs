using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Animations;
using System;

public class DelayToInvoke : MonoBehaviour

{

	public static IEnumerator DelayToInvokeDo(Action action, float delaySeconds)

	{

		yield return new WaitForSeconds(delaySeconds);

		action();

	}

}
public class character : MonoBehaviour
{

	private float moveSpeed = 5;
	private  float jumpSpeed = 14;
	private bool m_jumping = false;
    public Rigidbody2D m_rigidbody;
	private float sprintSpeed = 20;
	public Animator m_amin;

	public bool grounded1= true;//jump
	public bool grounded2 = true;//sprint
	public bool flag_sprinrt = true;
	// Use this for initialization
	public float cnt  =1.0f;
	public bool flag_climbing = false;
	private int cnttime=0;
	

	// Update is called once per frame
	void FixedUpdate ()
	{
		float h = Input.GetAxisRaw("Horizontal");
		if (h != 0)
			cnt = h;
		transform.Translate(Vector2.right*h*moveSpeed*Time.deltaTime,Space.World);
		float c = Input.GetAxisRaw(("Vertical"));
		//transform.Translate(Vector2.up*c*moveSpeed*Time.deltaTime,Space.World);
		if (Input.GetKey("c"))
		{
			jump();
		}

		if (Input.GetKey("x"))
		{
		   sprinting(h,c);
		}
		
		if (Input.GetKey("z")&&flag_climbing&&cnttime<500)
		{
			m_rigidbody.velocity=new Vector2(0,0);
			m_rigidbody.gravityScale = 0;
			transform.Translate(Vector2.up * c * moveSpeed * Time.deltaTime, Space.World);
			cnttime++;
			print(cnttime);
		}
		else
		{
			flag_climbing = false;
			cnttime = 0;
			m_rigidbody.gravityScale =4;
			print(1);

		}
		//if(grounded==false)
		//	transform.Translate(Vector3.up*c*moveSpeed*Time.deltaTime,Space.World);
	}


	private void jump()
	{
		if (this.grounded1)
		{
			m_rigidbody.velocity=new Vector2(0,1)*jumpSpeed;
			grounded1 = false;
		}
	}

	void sprinting(float h, float c)
	{
		if (flag_sprinrt && grounded2)
		{
			if (c != 0)
			{
				m_rigidbody.gravityScale = 0;
				m_rigidbody.velocity = new Vector2(0, c) * sprintSpeed;
				StartCoroutine(DelayToInvoke.DelayToInvokeDo(() =>

				{
					m_rigidbody.velocity = new Vector2(0, 0);
					m_rigidbody.gravityScale = 4;
					//flag_sprinrt = false;
					//m_rigidbody.drag = 0;
					grounded2 = false;

				}, 0.2f));
			}
			else if (h != 0)
			{
				m_rigidbody.gravityScale = 0;
				m_rigidbody.velocity = new Vector2(h, 0) * sprintSpeed;
				StartCoroutine(DelayToInvoke.DelayToInvokeDo(() =>

				{
					m_rigidbody.velocity = new Vector2(0, 0);
					m_rigidbody.gravityScale = 4;
					//flag_sprinrt = false;
					//m_rigidbody.drag = 0;
					grounded2 = false;

				}, 0.2f));
			}
			else
			{
				m_rigidbody.gravityScale = 0;
				m_rigidbody.velocity = new Vector2(cnt, 0) * sprintSpeed;
				StartCoroutine(DelayToInvoke.DelayToInvokeDo(() =>

				{
					m_rigidbody.velocity = new Vector2(0, 0);
					m_rigidbody.gravityScale = 4;
					//flag_sprinrt = false;
					//m_rigidbody.drag = 0;
					grounded2 = false;

				}, 0.2f));
			}
		}
	}

	private void OnCollisionEnter2D(Collision2D clo)
	{
		grounded1 = true;
		if (clo.contacts[0].normal.y == -1)//从上方碰撞
		{
                  
			grounded2 = true;    
		}
		else if(clo.contacts[0].normal.y == 1)//从下方碰撞
		{
			grounded2 = true;   
		}
		else if (clo.contacts[0].normal.x == -1)//左边碰撞
		{
			flag_climbing = true;
		}
		else if (clo.contacts[0].normal.x == 1)//右边碰撞
		{
			flag_climbing = true;
		}

	}

	
		
	

}
