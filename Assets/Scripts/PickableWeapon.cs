using UnityEngine;

[RequireComponent(typeof(CircleCollider2D), typeof(SpriteRenderer), typeof(Rigidbody2D))]
public class PickableWeapon : MonoBehaviour
{
	[SerializeField] private WeaponBase weaponBase;
	private CircleCollider2D _weaponCollider;
	private SpriteRenderer _weaponSprite;
	private bool _throwing;
	private const float ThrowingTime = 2f;
	private float _currentThrowingTime;

	private void Awake()
	{
		_weaponCollider = GetComponent<CircleCollider2D>();
		_weaponSprite = GetComponent<SpriteRenderer>();
		GetComponent<Rigidbody2D>().gravityScale = 0;
		_weaponSprite.sprite = weaponBase.icon;
		_weaponCollider.isTrigger = true;
	}

	private void Update()
	{
		if (!_throwing)
			return;
		_currentThrowingTime += Time.deltaTime;
		if (_currentThrowingTime >= ThrowingTime)
		{
			_throwing = false;
			_currentThrowingTime = 0f;
			GetComponent<Rigidbody2D>().velocity = Vector2.zero;
		}
	}

	private void OnTriggerEnter2D(Collider2D col)
	{
		if (col.CompareTag("Player") && Input.GetKey(KeyCode.E))
		{
			GameManager.Instance.weaponManager.ChangeWeapon(weaponBase);
			GetComponent<AudioSource>().Play();
			Destroy(gameObject);
		}
	}

	private void OnTriggerStay2D(Collider2D other)
	{
		if (other.CompareTag("Player") && Input.GetKey(KeyCode.E))
		{
			GameManager.Instance.weaponManager.ChangeWeapon(weaponBase);
			Destroy(gameObject);
		}
	}

	public void ThrowWeapon(Vector2 direction)
	{
		GetComponent<Rigidbody2D>().AddForce(direction, ForceMode2D.Impulse);
		_throwing = true;
	}
}
