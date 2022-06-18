using UnityEngine;

public class MeleeBehaviour : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D col)
	{
		if (!col.CompareTag("Enemy")) return;
		Debug.Log(col.tag + "is dead!");
		Destroy(col.gameObject);
	}
	
	private void OnTriggerStay2D(Collider2D col)
	{
		if (!col.CompareTag("Enemy")) return;
		Debug.Log(col.tag + "is dead!");
		Destroy(col.gameObject);
	}
}
