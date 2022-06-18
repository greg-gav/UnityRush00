using System;
using System.Collections;
using System.Collections.Generic;
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

	private void OnTriggerEnter2D(Collider2D col)
	{
		if (col.CompareTag("Player") || col.CompareTag("Enemy"))
			Debug.Log(col.tag);
		else
		{
			Destroy(gameObject);
		}
	}
}
