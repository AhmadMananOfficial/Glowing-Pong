using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
	public static Music music;
	
	void Awake()
    {
	    if(music == null)
	    {
	    	music = this;
	    	DontDestroyOnLoad(music);
	    }
	    else
	    {
	    	Destroy(gameObject);
	    }
    }
 
    
}
