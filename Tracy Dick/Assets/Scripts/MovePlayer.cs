using UnityEngine;
using System.Collections;

public class MovePlayer : MonoBehaviour 
{
    public GameStateScript gameStateScript;
    public GameObject gameStateManager;

    public float PlayerStart;
    public float PlayerEnd;
    public float PlayerLose;

    public AudioClip ItemCollected;

    public bool Lost;

	// Use this for initialization
	void Start () 
    {
        gameStateManager = GameObject.Find("GameStateManager");
        gameStateScript = gameStateManager.GetComponent<GameStateScript>();
        PlayerLose = PlayerStart - 2;
	}
	
	// Update is called once per frame
	void Update () 
    {
        var Newpos = new Vector3(PlayerStart, transform.position.y, -11);
        //Newpos = PlayerPos;
        transform.position = Newpos;

        if (PlayerStart < PlayerEnd && Lost == false)
        {
            PlayerStart += gameStateScript.PlayerMoveSpeed * Time.deltaTime;
        }

        if(Input.GetMouseButton(1))
        {
            //audio.PlayOneShot(ItemCollected);
            //PlayerStart -= gameStateScript.PlayerHinder;
        }
        //Debug.Log("I'm at: " + Newpos);
        if (PlayerStart < PlayerLose)
        {
            Time.timeScale = 0.0f;
            Debug.Log("You LOSE!");
            Lost = true;
            gameStateScript.GameOver = true;
            gameStateScript.Playing = false;
            gameStateScript.Lost = true;
        }
	}

    void OnTriggerEnter(Collider obj)
    {
        if (obj.gameObject.tag == "PlatformHit")
        {
            Debug.Log("OUCH!");
            PlayerStart -= gameStateScript.PlayerHinder;
        }

        if (obj.gameObject.tag == "Weapon")
        {
            audio.PlayOneShot(ItemCollected);
            PlayerStart -= gameStateScript.PlayerHinder;
        }

        if (obj.gameObject.tag == "TrashCan")
        {
            Debug.Log("BAM!");
            PlayerStart -= gameStateScript.PlayerHinder;
        }

        if (obj.gameObject.tag == "Enemy")
        {
            //Win sequence
            Time.timeScale = 0.0f;
        }
    }
}
