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
			Debug.Log(col.gameObject.tag);
			Destroy(gameObject);
			Destroy(col.gameObject);
		}
		else
		{
			Debug.Log(col.gameObject.name);
			Destroy(gameObject);
		}
	}
}
