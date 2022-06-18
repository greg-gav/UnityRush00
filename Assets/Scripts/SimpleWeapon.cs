using UnityEngine;

[CreateAssetMenu(menuName = "Rush00/Weapons/SimpleWeapon")]
public class SimpleWeapon : WeaponBase
{
	public override void Shoot()
	{
		Debug.Log("PEW PEW");
	}

	public override void Smash(BoxCollider2D collider2D)
	{
		Debug.Log("SMASH");
	}
}
