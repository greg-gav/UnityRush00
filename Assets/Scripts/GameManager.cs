using UnityEngine;

public class GameManager : MonoBehaviour
{
	public static GameManager Instance;
	public WeaponManager weaponManager;

	private void Start()
	{
		if (Instance == null)
		{
			Instance = this;
		}
		else if (Instance == this)
		{
			Destroy(gameObject);
		}
		
		DontDestroyOnLoad(gameObject);
		
		Initialize();
	}

	private void Initialize()
	{
		Debug.Log("Put something here!");
	}
}
