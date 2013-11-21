using UnityEngine;
using System.Collections;

public class Floor : MonoBehaviour {

    public GameStateScript gameStateScript;
    public GameObject gameStateManager;
    public float WallSpeed;
    public float OffScreenPosition;
    public float ResetLocation;

    // Use this for initialization
    void Start()
    {
        gameStateManager = GameObject.Find("GameStateManager");
        gameStateScript = gameStateManager.GetComponent<GameStateScript>();
    }

    // Update is called once per frame
    void Update()
    {
        WallSpeed = gameStateScript.FloorSpeed;
        transform.Translate(-1 * Time.deltaTime * WallSpeed, 0, 0);

        if (transform.position.x < OffScreenPosition)
        {
            transform.position = new Vector3(ResetLocation, transform.position.y, transform.position.z);
        }
    }
}
