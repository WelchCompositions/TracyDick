using UnityEngine;
using System.Collections;

public class PlatformMovement : MonoBehaviour {

    public GameStateScript gameStateScript;
    public GameObject gameStateManager;
    public float PlatformSpeed;
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
        PlatformSpeed = gameStateScript.PlatformSpeed;
        transform.Translate(-1 * Time.deltaTime * PlatformSpeed, 0, 0);

        if (transform.position.x < OffScreenPosition)
        {
            transform.position = new Vector3(ResetLocation, transform.position.y, transform.position.z);
        }
	}
}
