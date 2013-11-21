using UnityEngine;
using System.Collections;

public class StairMovement : MonoBehaviour {

    public GameStateScript gameStateScript;
    public GameObject gameStateManager;
    public float WallSpeed;
    public float OffScreenPosition;
    public float ResetLocation;

	// Use this for initialization
	void Start () 
    {
        gameStateManager = GameObject.Find("GameStateManager");
        gameStateScript = gameStateManager.GetComponent<GameStateScript>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        WallSpeed = gameStateScript.BackgroundOneSpeed;
        transform.Translate(Vector3.left * Time.deltaTime * WallSpeed,Space.World);

        if (transform.position.x < OffScreenPosition)
        {
            transform.position = new Vector3(ResetLocation, transform.position.y, transform.position.z);
        }
	}
}
