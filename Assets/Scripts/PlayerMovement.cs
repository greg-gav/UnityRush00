using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
	[SerializeField] private float playerSpeed;
	[SerializeField] private Camera mainCamera;
	private Vector2 _velocityMovement;
	private Vector2 _mousePosition;
	private float _playerRotation;
	private Transform _playerTransform;
	private Rigidbody2D _playerRb;

	private void Awake()
	{
		_playerRb = GetComponent<Rigidbody2D>();
		_playerTransform = GetComponent<Transform>();
		_playerRb.gravityScale = 0;
	}

	private void FixedUpdate()
	{
		if (!GameManager.Instance.PlayerAlive)
			return;
		_velocityMovement.x = Input.GetAxis("Horizontal");
		_velocityMovement.y = Input.GetAxis("Vertical");

		_playerRb.velocity = _velocityMovement * (playerSpeed * Time.fixedDeltaTime);
		_mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
		var position = _playerTransform.position;
		_playerRotation = Mathf.Atan2(_mousePosition.y - position.y, _mousePosition.x - position.x) * Mathf.Rad2Deg + 90;
		_playerRb.transform.eulerAngles = Vector3.forward * _playerRotation;
	}
}
