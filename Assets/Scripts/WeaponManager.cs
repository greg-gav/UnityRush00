using UnityEngine;

public class WeaponManager : MonoBehaviour
{
	[SerializeField] private WeaponBase starterWeapon;
	[SerializeField] private BoxCollider2D meleeCollider;
	private SpriteRenderer _weaponSprite;
	private WeaponBase _currentWeapon;

	private void Awake()
	{
		_weaponSprite = GetComponent<SpriteRenderer>();
		_currentWeapon = starterWeapon;
		_weaponSprite.sprite = _currentWeapon.equippedSprite;
	}

	private void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			if (_currentWeapon.hasAmmo)
				_currentWeapon.Shoot();
			else
				_currentWeapon.Smash(meleeCollider);
		}

		if (Input.GetMouseButtonDown(1) && _currentWeapon != starterWeapon)
		{
			ChangeWeapon(starterWeapon);
		}
	}

	public void ChangeWeapon(WeaponBase weapon)
	{
		if (_currentWeapon != starterWeapon)
		{
			Instantiate(Resources.Load($"{_currentWeapon.name}"), transform.position,
				Quaternion.identity);
		}

		_currentWeapon = weapon;
		_weaponSprite.sprite = _currentWeapon.equippedSprite;
	}
}
