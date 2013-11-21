using UnityEngine;
using System.Collections;

public class MenuGUI : MonoBehaviour 
{
    public GameStateScript gameStateScript;
    public GameObject gameStateManager;

    public Texture2D TracyDick;
    public GUISkin TracySkin;
    public float x;
    public float y;
    public float yOffset = 0.0f;

    public string[] Credits;


	// Use this for initialization
	void Start () 
    {
        gameStateManager = GameObject.Find("GameStateManager");
        gameStateScript = gameStateManager.GetComponent<GameStateScript>();
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    void OnGUI()
    {
        GUI.skin = TracySkin;
        GUI.backgroundColor = Color.black;
        GUI.Box(new Rect(0, 0, Screen.width, Screen.height), TracyDick);
        if (GUI.Button(new Rect(Screen.width / 2 - 250, Screen.height / 2 + x, 500, 100), "Hit Space Bar To Play"))
        {
            gameStateScript.Playing = true;
            Application.LoadLevel("Main");
        }


        GUI.Label(new Rect(Screen.width / 2 - 250, Screen.height / 2 + y, 500, 100), "Programming - Will Foldi", "CreditGUI");
        GUI.Label(new Rect(Screen.width / 2 - 250, Screen.height / 2 + y + yOffset , 500, 100), "Sound - Jim Welch", "CreditGUI");
        GUI.Label(new Rect(Screen.width / 2 - 250, Screen.height / 2 + y + yOffset *2, 500, 100), "Art - Young Wang", "CreditGUI");

        GUI.Label(new Rect(Screen.width / 2 - 250, Screen.height / 2 + y, 500, 100), "Programming - Will Foldi", "CreditGUI");
        GUI.Label(new Rect(Screen.width / 2 - 250, Screen.height / 2 + y + yOffset, 500, 100), "Sound - Jim Welch", "CreditGUI");
        GUI.Label(new Rect(Screen.width / 2 - 250, Screen.height / 2 + y + yOffset * 2, 500, 100), "Art - Young Wang", "CreditGUI");

        GUI.Label(new Rect(Screen.width / 2 - 250, Screen.height / 2 + y, 500, 100), "Programming - Will Foldi", "CreditGUI");
        GUI.Label(new Rect(Screen.width / 2 - 250, Screen.height / 2 + y + yOffset, 500, 100), "Sound - Jim Welch", "CreditGUI");
        GUI.Label(new Rect(Screen.width / 2 - 250, Screen.height / 2 + y + yOffset * 2, 500, 100), "Art - Young Wang", "CreditGUI");

    }
}
