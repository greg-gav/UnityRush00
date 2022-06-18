using UnityEngine;

[RequireComponent(typeof(CircleCollider2D), typeof(SpriteRenderer))]
public class PickableWeapon : MonoBehaviour
{
	[SerializeField] private WeaponBase weaponBase;
	private CircleCollider2D _weaponCollider;
	private SpriteRenderer _weaponSprite;

	private void Awake()
	{
		_weaponCollider = GetComponent<CircleCollider2D>();
		_weaponSprite = GetComponent<SpriteRenderer>();
		_weaponSprite.sprite = weaponBase.icon;
		_weaponCollider.isTrigger = true;
	}

	private void OnTriggerEnter2D(Collider2D col)
	{
		if (col.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
		{
			GameManager.Instance.weaponManager.ChangeWeapon(weaponBase);
			Destroy(gameObject);
		}
	}

	private void OnTriggerStay2D(Collider2D other)
	{
		if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
		{
			GameManager.Instance.weaponManager.ChangeWeapon(weaponBase);
			Destroy(gameObject);
		}
	}
}
