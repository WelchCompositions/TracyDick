using UnityEngine;
using System.Collections;

public class MainGUI : MonoBehaviour {

    public GameStateScript gameStateScript;
    public GameObject gameStateManager;
    public Texture Cred;

    public float Credibility;
    public int a;
    public int b;
    public int x;
    public int y;

    public GUISkin TracySkin;
    public bool GameOver;
    public bool Won;

    // Use this for initialization
    void Start()
    {
        gameStateManager = GameObject.Find("GameStateManager");
        gameStateScript = gameStateManager.GetComponent<GameStateScript>();
        Credibility = gameStateScript.Credibility;
        gameStateScript.Playing = true;
        gameStateScript.GameOver = false;
        Time.timeScale = 1.0f;
        GameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        Won = gameStateScript.Won;
        GameOver = gameStateScript.GameOver;
        Credibility = gameStateScript.Credibility;
        if (Credibility <= 0)
            Credibility = 0;
    }

    public void OnGUI()
    {
        GUI.skin = TracySkin;
        GUI.Label(new Rect(Screen.width / 2 - 75, Screen.height / 2 + 200, 150, 50), "Credibility");
        GUI.DrawTexture(new Rect(Screen.width / 2 - 300, Screen.height / 2 + 250, Credibility, 30), Cred);
        if (GameOver)
        {
            if (Credibility <= 0 || gameStateScript.Lost == true)
            {
                Time.timeScale = 0.0f;
                GUI.Label(new Rect(0, 0, Screen.width, Screen.height), "You Lost!", "LoseText");
                GUI.Label(new Rect(Screen.width / 2 - 190, Screen.height / 2 + -100, 400, 200), "Tap space bar to try and catch him again.", "WinText");
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    gameStateScript.Credibility = 600;
                    Won = false;
                    gameStateScript.Won = false;
                    Application.LoadLevel(1);
                }
            }
            if(Won && Credibility > 0 && gameStateScript.Won)
            {
                Time.timeScale = 0.0f;
                GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "You Caught Him!", "WinGUI");
                GUI.Label(new Rect(Screen.width / 2 - 190, Screen.height / 2 + -100, 400, 200), "Tap space bar to catch another criminal.", "WinText");
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    gameStateScript.Credibility = 600;
                    Won = false;
                    gameStateScript.Won = false;
                    Application.LoadLevel(1);
                }
            }
            if (GUI.Button(new Rect(Screen.width / 2 + x, Screen.height / 2, 300, 100), "Play Again"))
            {
                Time.timeScale = 1.0f;
                gameStateScript.GameOver = false;
                gameStateScript.Reset();
                GameOver = false;
                Application.LoadLevel(1);
            }
            if (GUI.Button(new Rect(Screen.width / 2 - y, Screen.height / 2, 300, 100), "Quit"))
            {
                Application.Quit();
            }
        }
    }
}
