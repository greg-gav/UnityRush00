using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	[SerializeField] private Texture2D cursor;
	public static GameManager Instance;
	public WeaponManager weaponManager;

	private void Awake()
	{
		Cursor.SetCursor(cursor, Vector2.zero, CursorMode.ForceSoftware);
	}

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

	private static void Initialize()
	{
		Debug.Log("Put something here!");
	}

	public void QuitGame()
	{
		#if UNITY_EDITOR
			EditorApplication.isPlaying = false;
		#else
			Application.Quit();
		#endif
	}

	public void LoadNextScene()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

	public void ReloadScene()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
}
