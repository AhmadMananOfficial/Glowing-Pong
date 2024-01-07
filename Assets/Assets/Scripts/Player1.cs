using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player1 : MonoBehaviour
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
	    float directionY = Input.GetAxisRaw("Vertical2");
	    
	    racketDirection = new Vector2(0,directionY).normalized;
	    
    }
    
	void FixedUpdate()
	{
		rb2D.velocity = racketDirection * racketSpeed * Time.fixedDeltaTime;
	}
	
}
