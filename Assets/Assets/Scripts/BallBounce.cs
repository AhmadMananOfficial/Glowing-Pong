using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBounce : MonoBehaviour
{
	BallMovement ballMovement;
	public ScoreManager scoreManager; 
	
	public GameObject hitSFX;
	
	
    void Start()
    {
	    ballMovement = GetComponent<BallMovement>();
    }

    
	void Bounce(Collision2D collision)
    {
	    Vector3 ballPosition = transform.position;
	    Vector3 racketPosition = collision.transform.position;
	    float racketHeight = collision.collider.bounds.size.y;
	    
	    float positionY = (ballPosition.y -racketPosition.y) / racketHeight;
	    
	    float positionX;
	    if(collision.gameObject.name == "Player1")
	    {
	    	positionX = 1;
	    }
	    
	    else 
	    {
	    	positionX = -1;
	    }
	    
	    ballMovement.IncreaseHitCounter();
	    ballMovement.MoveBall(new Vector2(positionX, positionY));
    }
    
	
	protected void OnCollisionEnter2D(Collision2D collisionInfo)
	{
		if(collisionInfo.gameObject.name == "Player 1" || collisionInfo.gameObject.name == "Player 2")
		{
			Bounce(collisionInfo);
		}
		
		if(collisionInfo.gameObject.name == "Right Border")
		{
			scoreManager.Player1Score();
			ballMovement.player1Start = false;
			StartCoroutine(ballMovement.Launch());
		}
		if(collisionInfo.gameObject.name == "Left Border")
		{
			scoreManager.Player2Score();
			ballMovement.player1Start = true;
			StartCoroutine(ballMovement.Launch());
		}
		
		Instantiate(hitSFX, transform.position, transform.rotation);
	}
}
