using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class ProjectileBehaviour : MonoBehaviour
{
	[SerializeField] private float lifetime;
	[SerializeField] private float projectileSpeed;

	private void Start()
	{
		Destroy(gameObject, lifetime);
	}

	private void Update()
	{
		transform.Translate(Vector2.up * (projectileSpeed * Time.deltaTime));
	}

	private void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.CompareTag("Player") || col.gameObject.CompareTag("Enemy"))
		{
			if (col.gameObject.CompareTag("Player"))
			{
				GameManager.Instance.PlayerAlive = false;
				GameManager.Instance.restartScreen.SetActive(true);
				GameManager.Instance.PlayVictoryOrDefeatSound(false);
				Destroy(gameObject);
			}
			else
			{
				Destroy(gameObject);
				Destroy(col.gameObject);
			}
		}
		else
		{
			Destroy(gameObject);
		}
	}
}
