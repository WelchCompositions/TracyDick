using UnityEngine;
using System.Collections;

public class WeaponMovement : MonoBehaviour {

    public GameStateScript gameStateScript;
    public GameObject gameStateManager;
    public BackgroundController BackgroundController;
    public GameObject MainCamera;
    public float ItemSpeed;
    public float OffScreenPosition = -33f;
    public float ResetLocation = 85f;
    public AudioClip Collected;
    public int RotateSpeed;

	// Use this for initialization
	void Start () 
    {
        gameStateManager = GameObject.Find("GameStateManager");
        gameStateScript = gameStateManager.GetComponent<GameStateScript>();
        MainCamera = GameObject.Find("MainCamera");
        BackgroundController = MainCamera.GetComponent<BackgroundController>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        RotateSpeed = gameStateScript.RotateSpeed;
        ItemSpeed = gameStateScript.WeaponSpeed;
        transform.Translate(Vector3.left * Time.deltaTime * ItemSpeed, Space.World);
        transform.Rotate(Vector3.up * Time.deltaTime * RotateSpeed, Space.World);
        //if (transform.position.x < OffScreenPosition)
        //{
        //    transform.position = new Vector3(ResetLocation, transform.position.y, transform.position.z);
        //}
        if (Input.GetMouseButtonDown(1))
        {
            renderer.enabled = false;
            audio.PlayOneShot(Collected);
            gameStateScript.ItemsCollected += 1;
            gameStateScript.WeaponsInPlay -= 1;
            gameStateScript.Credibility += gameStateScript.CredAddition;
            Destroy(gameObject);
        }
	}

    void OnTriggerEnter(Collider obj)
    {
        if (obj.gameObject.tag == "Player")
        {
            gameStateScript.Credibility += gameStateScript.CredAddition;
            BackgroundController.Collected();
            BackgroundController.PlayAudio(this.gameObject);
            //audio.PlayOneShot(Collected);
            //gameStateScript.ItemsCollected += 1;
            //gameStateScript.WeaponsInPlay -= 1;
            
            Destroy(gameObject);
        }

        if (obj.gameObject.tag == "Wall")
        {
            Debug.Log("Not collected");
            gameStateScript.WeaponsInPlay = 0;
            Destroy(gameObject);
        }
    }
}
