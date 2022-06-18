using UnityEngine;

public class WeaponManager : MonoBehaviour
{
	[SerializeField] private WeaponBase starterWeapon;
	private SpriteRenderer _weaponSprite;
	private WeaponBase _currentWeapon;

	private void Awake()
	{
		_weaponSprite = GetComponent<SpriteRenderer>();
		_currentWeapon = starterWeapon;
		_weaponSprite.sprite = _currentWeapon.equippedSprite;
	}

	public void ChangeWeapon(WeaponBase weapon)
	{
		_currentWeapon = weapon;
		_weaponSprite.sprite = _currentWeapon.equippedSprite;
	}
}
