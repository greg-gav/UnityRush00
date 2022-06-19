using UnityEngine;

public class RandomizeWeapon : MonoBehaviour
{
	[SerializeField] private WeaponBase[] weapons;

	public WeaponBase RandomizeWeapons()
	{
		return weapons[Random.Range(0, weapons.Length)];
	}
}
