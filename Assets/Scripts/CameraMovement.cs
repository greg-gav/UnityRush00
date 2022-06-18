using UnityEngine;

public class CameraMovement : MonoBehaviour
{
	[SerializeField] private GameObject player;
	private Transform _cameraTransform;
	private Transform _playerTransform;
	private float _cameraOffset;

	private void Awake()
	{
		_cameraTransform = GetComponent<Transform>();
		_playerTransform = player.GetComponent<Transform>();
		_cameraOffset = _cameraTransform.position.z;
	}

	private void Update()
	{
		_cameraTransform.position = _playerTransform.position - Vector3.back * _cameraOffset;
	}
}
