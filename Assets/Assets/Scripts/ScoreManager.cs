using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
	public int maxScore = 5;
	
	int player1Score = 0;
	int player2Score = 0;
	
	public Text player1ScoreText;
	public Text player2ScoreText;
	
	
	public void Player1Score()
	{
		player1Score++;
		player1ScoreText.text = player1Score.ToString();
		CheckScore();
	}
	
	
	public void Player2Score()
	{
		player2Score++;
		player2ScoreText.text = player2Score.ToString();
		CheckScore();
	}
	
	void CheckScore()
	{
		if(player1Score == maxScore || player2Score == maxScore)
		{
			SceneManager.LoadScene(2); // 2 is gameOver Scene
		}
	}
}
