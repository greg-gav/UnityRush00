using UnityEngine;

public abstract class WeaponBase : ScriptableObject
{
	public Sprite icon;
	public Sprite equippedSprite;
	public new string name;
	public bool hasAmmo;
	public int ammoSize;
}
