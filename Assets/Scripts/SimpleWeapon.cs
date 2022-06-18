using UnityEngine;

[CreateAssetMenu(menuName = "Rush00/Weapons/SimpleWeapon")]
public class SimpleWeapon : WeaponBase
{
	public override void Shoot()
	{
		if (hasAmmo)
			Debug.Log("PEW PEW");
	}
}
