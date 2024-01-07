using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
	public float ballSpeed;
	public float extraSpeed;
	public float maxExtraSpeed;
	
	public bool player1Start = true;
	
	int hitCounter;
	Rigidbody2D rb2D;
	
	
    void Start()
    {
	    rb2D = GetComponent<Rigidbody2D>();
	    StartCoroutine(Launch());
    }

    
	void Restart()
	{
		rb2D.velocity = new Vector2(0,0);
		transform.position = new Vector2(0,0);
	}
    
	public IEnumerator Launch()
	{
		Restart();
		hitCounter = 0;
	   yield return new WaitForSeconds(1);
	   
		if(player1Start == true)
		{
			 MoveBall(new Vector2(1,0));
		}
		else
		{
			MoveBall(new Vector2(-1,0));
		}
    }
   
   
	public void MoveBall(Vector2 direction)
	{
		direction = direction.normalized;
		float BallSpeed = ballSpeed + (hitCounter * extraSpeed);
		
		rb2D.velocity = direction * BallSpeed;
	}


	public void IncreaseHitCounter()
	{
		if((hitCounter * extraSpeed) < maxExtraSpeed)
		{
			hitCounter++;
		}
	}
	
	
}
