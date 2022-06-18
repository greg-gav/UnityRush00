using UnityEngine;

public class GameManager : MonoBehaviour
{

	public static GameManager instance;

	private void Start()
	{
		if (instance == null)
		{
			instance = this;
		}
		else if (instance == this)
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
