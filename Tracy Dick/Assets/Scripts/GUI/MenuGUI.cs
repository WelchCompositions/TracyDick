using UnityEngine;
using System.Collections;

public class MenuGUI : MonoBehaviour 
{
    public GameStateScript gameStateScript;
    public GameObject gameStateManager;

    public AudioClip ScreamSound;
    public AudioClip OnIt;
    public int ScreamCount = 0;
    public int OnItCount = 0;
    public bool PlayOnIt;
    public bool LoadNext;
    public float LoadTimer;
    GUIState guiState;
    public Texture2D TracyDick;
    public GUISkin TracySkin;
    public bool ShowBlack;
    public int CreditSpacing = 0;

    public string[] Credits;

    private enum GUIState
    {
        Menu = 1,
        Credits = 2,
        Rules = 3,
        Main = 4
    }

	// Use this for initialization
	void Start () 
    {
        guiState = GUIState.Menu;
        gameStateManager = GameObject.Find("GameStateManager");
        gameStateScript = gameStateManager.GetComponent<GameStateScript>();
	}

    public void Update()
    {
        
    }

    public void OnItSound()
    {
        audio.PlayOneShot(OnIt);
    }

    private void LoadNextLevel()
    {
        Application.LoadLevel("Main");
    }
	
    public int screenHeight;

    void OnGUI()
    {
        GUI.skin = TracySkin;
        switch (guiState)
        {
            case GUIState.Menu:
                GUI.Box(new Rect(0, 0, Screen.width, Screen.height / 2), TracyDick);
                GUI.backgroundColor = Color.black;
                if (GUI.Button(new Rect(0, Screen.height - screenHeight, 200, 50), "Rules"))
                {
                    guiState = GUIState.Rules;
                }
                if (GUI.Button(new Rect(Screen.width / 2 - 200, Screen.height - screenHeight, 200, 50), "Play"))
                {
                    ShowBlack = true;
                    OnItSound();
                    guiState = GUIState.Main;
                    Invoke("LoadNextLevel", 2f);
                }
                if (GUI.Button(new Rect(Screen.width / 2 + 100, Screen.height - screenHeight, 200, 50), "Credits"))
                {
                    guiState = GUIState.Credits;
                }
                if (GUI.Button(new Rect(Screen.width - 200, Screen.height - screenHeight, 200, 50), "Quit"))
                {
                    Application.Quit();
                }
                break;
            case GUIState.Credits:
                foreach(string credit in Credits)
                {
                    GUI.Label(new Rect(0, 200, 500, 50), credit);
                }
                GUI.Label(new Rect(Screen.width / 2 - 400, Screen.height / 2 + 200, 300, 100), "Programming - Will Foldi", "CreditGUI");
                GUI.Label(new Rect(Screen.width / 2 - 400, Screen.height / 2 + 250, 300, 100), "Sound - Jim Welch", "CreditGUI");
                GUI.Label(new Rect(Screen.width / 2 - 400, Screen.height / 2 + 300, 300, 100), "Art - Young Wang", "CreditGUI");

                GUI.Label(new Rect(Screen.width / 2 - 130, Screen.height / 2 + 200, 300, 100), "Art - Nasser Elsamadisy", "CreditGUI");
                GUI.Label(new Rect(Screen.width / 2 - 130, Screen.height / 2 + 250, 300, 100), "Writing - Christi Heiskell", "CreditGUI");
                GUI.Label(new Rect(Screen.width / 2 - 130, Screen.height / 2 + 300, 300, 100), "Voice Acting - Adrienne Welch", "CreditGUI");

                GUI.Label(new Rect(Screen.width / 2 + 195, Screen.height / 2 + 200, 300, 100), "Art - Andrew Shirk", "CreditGUI");
                GUI.Label(new Rect(Screen.width / 2 + 195, Screen.height / 2 + 250, 300, 100), "Art - Brandon Shirk", "CreditGUI");
                GUI.Label(new Rect(Screen.width / 2 + 195, Screen.height / 2 + 300, 300, 100), "Art - Adam Zaelit", "CreditGUI");
                break;
        }      
    }
}
