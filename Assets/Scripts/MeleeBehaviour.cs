using UnityEngine;

public class MeleeBehaviour : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D col)
	{
		if (!col.CompareTag("Enemy")) return;
		Destroy(col.gameObject);
	}
	
	private void OnTriggerStay2D(Collider2D col)
	{
		if (!col.CompareTag("Enemy")) return;
		Destroy(col.gameObject);
	}
}
