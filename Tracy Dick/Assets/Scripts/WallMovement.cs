using UnityEngine;
using System.Collections;

public class WallMovement : MonoBehaviour {

    public GameStateScript gameStateScript;
    public GameObject gameStateManager;
    public float WallSpeed;
    public float OffScreenPosition;
    public float ResetLocation;
    public float Life;
    public float BackgroundTimer;
    public float BackgroundResetTime;
    public bool CanCreate = true;

	// Use this for initialization
	void Start () 
    {
        gameStateManager = GameObject.Find("GameStateManager");
        gameStateScript = gameStateManager.GetComponent<GameStateScript>();
        gameStateScript.BackgroundTimer = 2;
        BackgroundTimer = gameStateScript.BigTimer;
        CanCreate = gameStateScript.CanCreate;
	}
	
	// Update is called once per frame
	void Update () 
    {
        WallSpeed = gameStateScript.BackgroundOneSpeed;


        BackgroundTimer -= Time.deltaTime;
        if (BackgroundTimer <= 0 && CanCreate)
        {
            BackgroundTimer = 0.0f;
            gameStateScript.CreateBackground();
            CanCreate = false;
        }

        Life = gameStateScript.Life;
        Life -= Time.deltaTime;
        if (Life >= 0.0f)
        {
            transform.Translate(-1 * Time.deltaTime * WallSpeed, 0, 0);
        }
        if (Life <= 0.0f)
        {
            Destroy(gameObject);
            //gameStateScript.CreateBackground();
        }
	}
}
