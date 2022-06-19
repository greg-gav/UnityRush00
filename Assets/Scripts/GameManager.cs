using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class GameManager : MonoBehaviour
{
	[SerializeField] private Texture2D cursor;
	[SerializeField] private AudioClip victory;
	[SerializeField] private AudioClip defeat;
	public GameObject restartScreen;
	public RandomizeWeapon rWeapons;
	public static GameManager Instance;
	public WeaponManager weaponManager;
	private Vector2 _cursorHotspot;
	private AudioSource _audioSource;
	public bool PlayerAlive { get; set; }

	private void Awake()
	{
		_cursorHotspot = new Vector2 (cursor.width / 2, cursor.height / 2);
		Cursor.SetCursor(cursor, _cursorHotspot, CursorMode.ForceSoftware);
		_audioSource = GetComponent<AudioSource>();
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
		
		PlayerAlive = true;
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

	public void PlayVictoryOrDefeatSound(bool areYouWinningSon)
	{
		if (areYouWinningSon)
			_audioSource.clip = victory;
		else
			_audioSource.clip = defeat;
		_audioSource.Play();
	}
}
