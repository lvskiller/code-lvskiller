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
	private float sprintSpeed1 = 20;//正冲速度
	private float sprintSpeed2 = 14;//斜冲速度
	public bool grounded1= true;    //jump
	public bool grounded2 = true;   //sprint
	public float cnt  =1.0f;//记载原方向
	public bool flag_climbing = false;
	private int cnttime=0;//记载爬的时间
	public bool ismoving = true;//判断是否在爬的时候，爬的时候不能左右移动
	
	
	public Rigidbody2D m_rigidbody;
	public SpriteRenderer render;
	public Sprite[] decide;
	public Animator m_amin;

	void FixedUpdate ()
	{
		float h = Input.GetAxisRaw("Horizontal");
		float c = Input.GetAxisRaw(("Vertical"));
		if (h != 0)
		{
			if (h < 0)//左右移动人物转向
				render.flipX = true;
			else
			{
				render.flipX = false;
			}
			cnt = h;
		}

		if (grounded2)//冲刺时头发变色
			render.sprite = decide[1];
		else
		{
			render.sprite = decide[0];
		}

		if(ismoving)
		transform.Translate(Vector2.right*h*moveSpeed*Time.deltaTime,Space.World);
		if (Input.GetKey("c"))
		{
			jump();
		}

		if (Input.GetKey("x"))
		{
		   sprinting();
		}

		climbing(c);
   }


	private void jump()
	{
		if (this.grounded1)
		{
			m_rigidbody.velocity=new Vector2(0,1)*jumpSpeed;
			grounded1 = false;
		}
	}

	void climbing(float c)
	{
		if (Input.GetKey("z")&&flag_climbing&&cnttime<150)
		{
			m_rigidbody.velocity=new Vector2(0,0);
			m_rigidbody.gravityScale = 0;
			//m_rigidbody.constraints = RigidbodyConstraintsc2D.FreezePosition;
			transform.Translate(Vector2.up * c * moveSpeed * Time.deltaTime, Space.World);
			cnttime++;
		
			ismoving = false;
		}
		else if (flag_climbing&&cnttime <= 10)
		{
			m_rigidbody.velocity=new Vector2(0,0);
			m_rigidbody.gravityScale = 2;
			cnttime++;
			ismoving = false;
		}
		else
		{
			flag_climbing = false;
			cnttime = 0;
			m_rigidbody.gravityScale =4;
			ismoving = true;
		}
	}

	
		
		
		void sprinting()//冲刺
	{
		float h = Input.GetAxisRaw("Horizontal");
		float c = Input.GetAxisRaw(("Vertical"));
		if (grounded2)
		{
			m_rigidbody.velocity=new Vector2(0,0);
			grounded2 = false;
			if (c != 0 && h != 0)    //斜冲
			{
				m_rigidbody.gravityScale = 0;
				m_rigidbody.velocity = new Vector2(h, c) * sprintSpeed2;
				StartCoroutine(DelayToInvoke.DelayToInvokeDo(() =>
				{
					m_rigidbody.velocity = new Vector2(0, 0);
					m_rigidbody.gravityScale = 4;
				}, 0.2f));
			}
			else if (c != 0f||h!=0f )     //正冲
			{
				m_rigidbody.gravityScale = 0;
				m_rigidbody.velocity = new Vector2(h, c) * sprintSpeed1;
				StartCoroutine(DelayToInvoke.DelayToInvokeDo(() =>
				{
					m_rigidbody.velocity = new Vector2(0, 0);
					m_rigidbody.gravityScale = 4;
				}, 0.2f));
			}
		
			else       //原定方向冲刺
			{
				m_rigidbody.gravityScale = 0;
				m_rigidbody.velocity = new Vector2(cnt, 0) * sprintSpeed1;
				StartCoroutine(DelayToInvoke.DelayToInvokeDo(() =>
				{
					m_rigidbody.velocity = new Vector2(0, 0);
					m_rigidbody.gravityScale = 4;
				}, 0.2f));
			}
		}
	}

	
		
		
		private void OnCollisionEnter2D(Collision2D clo)//碰撞检测落地
	{
		     grounded1 = true;
			if (clo.contacts[0].normal.y == -1) //从上方碰撞
			{
				
			}
			if (clo.contacts[0].normal.y == 1) //从下方碰撞
			{
				
			}
			 if (clo.contacts[0].normal.x == -1) //左边碰撞
			{
				flag_climbing = true;
			}
			 if (clo.contacts[0].normal.x >0.9f) //右边碰撞
			{
				flag_climbing = true;	
			}
		

	}

	private void OnCollisionStay2D(Collision2D collision)//在陆地上可以连冲
	{
		for (int i = 0; i < collision.contactCount; i++)
		{
			if (collision.contacts[i].normal.y == -1) //从上方碰撞
			{

			}
			else if (collision.contacts[i].normal.y == 1) //从下方碰撞
			{
				grounded2 = true;
			}
			else if (collision.contacts[i].normal.x == -1)//左边碰撞
			{

			}
			else if (collision.contacts[i].normal.x == 1)//右边碰撞
			{
				
			}

		}
	}
}
