using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
	private Dictionary<string, int> _ammos = new Dictionary<string, int>();
	private int _magSize;
	private Camera _camera;

	private void Start()
	{
		_camera = Camera.main;
	}

	private void Awake()
	{
		_weaponSprite = GetComponent<SpriteRenderer>();
		_currentWeapon = starterWeapon;
		if (!_ammos.ContainsKey(_currentWeapon.name))
			_ammos.Add(_currentWeapon.name, _currentWeapon.maxAmmoSize);
		_magSize = _currentWeapon.ammoSize;
		_weaponSprite.sprite = _currentWeapon.equippedSprite;
		_attackCd = new WaitForSeconds(_currentWeapon.attackCoolDown);
	}

	private void Update()
	{
		if (!GameManager.Instance.PlayerAlive)
			return;
		if (Input.GetMouseButton(0) && !_isAttacking && _ammos[_currentWeapon.name] != -1)
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
			var weaponForThrow = Instantiate(Resources.Load($"{_currentWeapon.name}"), transform.position,
				Quaternion.identity);
			if (_camera != null)
				weaponForThrow.GameObject().GetComponent<PickableWeapon>().ThrowWeapon(_camera.ScreenToWorldPoint
					(Input.mousePosition).normalized * 3);
		}

		_currentWeapon = weapon;
		_weaponSprite.sprite = _currentWeapon.equippedSprite;
		if (!_ammos.ContainsKey(_currentWeapon.name))
			_ammos.Add(_currentWeapon.name, _currentWeapon.maxAmmoSize);
		_magSize = _currentWeapon.ammoSize;
		_attackCd = new WaitForSeconds(_currentWeapon.attackCoolDown);
	}

	private IEnumerator Attack()
	{
		_isAttacking = true;
		if (_currentWeapon.hasAmmo)
		{
			if (_magSize == 0)
			{
				for (var i = 0; i < 5; i++)
				{
					yield return _attackCd;
				}

				_magSize = _currentWeapon.ammoSize;
			}

			_magSize--;
			_ammos[_currentWeapon.name]--;
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
