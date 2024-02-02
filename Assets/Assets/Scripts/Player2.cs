using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player2 : MonoBehaviour
{
	public float racketSpeed;
	
	Vector2 racketDirection;
	Rigidbody2D rb2D; 
    
	void Start()
	{
		rb2D = GetComponent<Rigidbody2D>();
	}

    
	void Update()
	{
		float directionY = Input.GetAxisRaw("Vertical");
	    
		racketDirection = new Vector2(0f,directionY).normalized;
	}
    
	void FixedUpdate()
	{
		rb2D.velocity = new Vector2(0f, racketDirection.y * racketSpeed);
	}
	
}