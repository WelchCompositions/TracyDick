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

    // Use this for initialization
    void Start()
    {
        gameStateManager = GameObject.Find("GameStateManager");
        gameStateScript = gameStateManager.GetComponent<GameStateScript>();
        Credibility = gameStateScript.Credibility;
        gameStateScript.Playing = true;
        gameStateScript.GameOver = false;
        Time.timeScale = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        GameOver = gameStateScript.GameOver;
        Credibility = gameStateScript.Credibility;
        if (Credibility <= 0)
            Credibility = 0;
    }

    public void OnGUI()
    {
        GUI.skin = TracySkin;
        GUI.Label(new Rect(Screen.width / 2 - 75, Screen.height / 2 - 200, 150, 50), "Credibility");
        GUI.DrawTexture(new Rect(Screen.width / 2 - 300, Screen.height / 2 - 250, Credibility, 30), Cred);
        if (GameOver)
        {
            if (Credibility <= 0 || gameStateScript.Lost == true)
            {
                GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "You Lose!");
            }
            else
            {
                GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "You Caught Him!");
            }
            if (GUI.Button(new Rect(Screen.width / 2 + x, Screen.height / 2, 300, 100), "Play Again"))
            {
                Time.timeScale = 1.0f;
                gameStateScript.GameOver = false;
                gameStateScript.Reset();
                GameOver = false;
                Application.LoadLevel(0);
            }
            if (GUI.Button(new Rect(Screen.width / 2 - y, Screen.height / 2, 300, 100), "Quit"))
            {
                Application.Quit();
            }
        }
    }
}
