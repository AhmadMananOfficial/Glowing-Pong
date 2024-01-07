using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneController : MonoBehaviour
{
	
	public void LoadScene(int SceneID)
    {
	    SceneManager.LoadScene(SceneID);  
    }

   
	public void Quit()
    {
	    Application.Quit();
    }
    
}
