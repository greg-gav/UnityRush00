using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	[SerializeField] private Texture2D cursor;
	public RandomizeWeapon rWeapons;
	public static GameManager Instance;
	public WeaponManager weaponManager;
	private Vector2 _cursorHotspot;
	public bool PlayerAlive { get; set; }

	private void Awake()
	{
		_cursorHotspot = new Vector2 (cursor.width / 2, cursor.height / 2);
		Cursor.SetCursor(cursor, _cursorHotspot, CursorMode.ForceSoftware);
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
		
		
		Initialize();
		PlayerAlive = true;
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
