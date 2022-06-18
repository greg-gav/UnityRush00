using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
	[SerializeField] private float playerSpeed;
	private Vector2 _velocityMovement;
	private Rigidbody2D _playerRb;

	private void Awake()
	{
		_playerRb = GetComponent<Rigidbody2D>();
		_playerRb.gravityScale = 0;
	}

	private void FixedUpdate()
	{
		_velocityMovement.x = Input.GetAxisRaw("Horizontal");
		_velocityMovement.y = Input.GetAxisRaw("Vertical");

		_playerRb.velocity = _velocityMovement * (playerSpeed * Time.fixedDeltaTime);
	}
}
