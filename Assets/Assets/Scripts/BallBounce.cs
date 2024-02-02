using System.Collections;
using UnityEngine;

public class BallBounce : MonoBehaviour
{
	private BallMovement ballMovement;
	[SerializeField] private ScoreManager scoreManager;
	[SerializeField] private GameObject hitSFX;

	private void Start()
	{
		ballMovement = GetComponent<BallMovement>();
	}

	private void Bounce(Collision2D collision)
	{
		Vector3 ballPosition = transform.position;
		Vector3 racketPosition = collision.transform.position;
		float racketHeight = collision.collider.bounds.size.y;

		float positionY = (ballPosition.y - racketPosition.y) / racketHeight;

		float positionX = (collision.gameObject.name == "Player1") ? 1 : -1;

		ballMovement.IncreaseHitCounter();
		ballMovement.MoveBall(new Vector2(positionX, positionY));
	}

	protected void OnCollisionEnter2D(Collision2D collisionInfo)
	{
		if (collisionInfo.gameObject.CompareTag("Player"))
		{
			Bounce(collisionInfo);
		}
		else if (collisionInfo.gameObject.CompareTag("RightBorder"))
		{
			scoreManager.Player1Score();
			ballMovement.isPlayer1Start = false;
			StartCoroutine(ballMovement.Launch());
		}
		else if (collisionInfo.gameObject.CompareTag("LeftBorder"))
		{
			scoreManager.Player2Score();
			ballMovement.isPlayer1Start = true;
			StartCoroutine(ballMovement.Launch());
		}

		Instantiate(hitSFX, transform.position, transform.rotation);
	}
}
