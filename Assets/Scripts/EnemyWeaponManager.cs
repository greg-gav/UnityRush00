using System.Collections;
using UnityEngine;

public class EnemyWeaponManager : MonoBehaviour
{
	[SerializeField] private Transform bulletSpawn;
	private SpriteRenderer _weaponSprite;
	private WeaponBase _currentWeapon;
	private WaitForSeconds _attackCd;
	private int _magSize;

	private void Start()
	{
		_weaponSprite = GetComponent<SpriteRenderer>();
		_currentWeapon = GetComponent<RandomizeWeapon>().RandomizeWeapons();
		_magSize = _currentWeapon.ammoSize;
		_weaponSprite.sprite = _currentWeapon.equippedSprite;
		_attackCd = new WaitForSeconds(_currentWeapon.attackCoolDown);

	}
	
	public IEnumerator Attack()
	{
		while (true)
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
			Instantiate(_currentWeapon.projectile, bulletSpawn.position, bulletSpawn.rotation);
			_currentWeapon.Shoot();
			yield return _attackCd;
		}
	}
}
