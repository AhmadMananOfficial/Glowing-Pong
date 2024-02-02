using System.Collections;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
	[SerializeField] private float initialSpeed = 5.0f;
	[SerializeField] private float extraSpeed = 1.0f;
	[SerializeField] private float maxExtraSpeed = 10.0f;
	public bool isPlayer1Start = true;

	private int hitCounter;
	private Rigidbody2D rb2D;

	void Start()
	{
		rb2D = GetComponent<Rigidbody2D>();
		StartCoroutine(Launch());
	}

	void Restart()
	{
		rb2D.velocity = Vector2.zero;
		transform.position = Vector2.zero;
	}

	public IEnumerator Launch()
	{
		Restart();
		hitCounter = 0;
		yield return new WaitForSeconds(1);

		//Vector2 launchDirection = isPlayer1Start ? Vector2.right : Vector2.left;
		//MoveBall(launchDirection);
		// Set initial velocity with a random angle
		float angle = Random.Range(-45f, 45f);
		rb2D.velocity = Quaternion.Euler(0, 0, angle) * Vector2.right * initialSpeed;
	}

	public void MoveBall(Vector2 direction)
	{
		direction = direction.normalized;
		float currentSpeed = initialSpeed + (hitCounter * extraSpeed);

		rb2D.velocity = direction * currentSpeed;
	}

	public void IncreaseHitCounter()
	{
		if ((hitCounter * extraSpeed) < maxExtraSpeed)
		{
			hitCounter++;
		}
	}
}
