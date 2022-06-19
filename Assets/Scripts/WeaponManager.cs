using System.Collections;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
	[SerializeField] private WeaponBase starterWeapon;
	[SerializeField] private BoxCollider2D meleeCollider;
	[SerializeField] private Transform bulletSpawn;
	private SpriteRenderer _weaponSprite;
	private WeaponBase _currentWeapon;
	private bool _isAttacking;
	private WaitForSeconds _attackCd;

	private void Awake()
	{
		_weaponSprite = GetComponent<SpriteRenderer>();
		_currentWeapon = starterWeapon;
		_weaponSprite.sprite = _currentWeapon.equippedSprite;
		_attackCd = new WaitForSeconds(_currentWeapon.attackCoolDown);
	}

	private void Update()
	{
		if (Input.GetMouseButton(0) && !_isAttacking)
		{
			StartCoroutine(Attack());
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
		_attackCd = new WaitForSeconds(_currentWeapon.attackCoolDown);
	}

	private IEnumerator Attack()
	{
		_isAttacking = true;
		if (_currentWeapon.hasAmmo)
		{
			Instantiate(_currentWeapon.projectile, bulletSpawn.position, bulletSpawn.rotation);
			_currentWeapon.Shoot();
		}
		else
		{
			meleeCollider.gameObject.SetActive(true);
			_currentWeapon.Smash(meleeCollider);
		}

		yield return _attackCd;
		meleeCollider.gameObject.SetActive(false);
		_isAttacking = false;
	}
}
