using UnityEngine;
using System.Collections;

public class MovePlayer : MonoBehaviour 
{
    public GameStateScript gameStateScript;
    public GameObject gameStateManager;
    public BackgroundController BackgroundController;
    public GameObject MainCamera;
    public JumpSoundScript jumpSoundScript;
    public GameObject JumpSoundObject;
    public MainGUI MainGUI;

    public float PlayerStart;
    public float PlayerEnd;
    public float PlayerLose;
    public float PlayerWin;

    public AudioClip ItemCollected;

    public bool Lost;

	// Use this for initialization
	void Start () 
    {
        gameStateManager = GameObject.Find("GameStateManager");
        gameStateScript = gameStateManager.GetComponent<GameStateScript>();
        MainCamera = GameObject.Find("Main Camera");
        BackgroundController = MainCamera.GetComponent<BackgroundController>();
        MainGUI = MainCamera.GetComponent<MainGUI>();
        JumpSoundObject = GameObject.Find("JumpSoundDumpster");
        jumpSoundScript = JumpSoundObject.GetComponent<JumpSoundScript>();
        PlayerLose = PlayerStart - 2;
        Lost = false;
        gameStateScript.Lost = false;
        gameStateScript.Won = false;
        gameStateScript.GameOver = false;        
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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //BackgroundController.JumpSound();
            jumpSoundScript.JumpSound();
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

        if (PlayerStart >= PlayerWin)
        {
            gameStateScript.Won = true;
            gameStateScript.GameOver = true;
            gameStateScript.Playing = false;
            MainGUI.Won = true;
            MainGUI.GameOver = false;
            Time.timeScale = 0.0f;
        }
	}

    void OnTriggerEnter(Collider obj)
    {
        if (obj.gameObject.tag == "PlatformHit")
        {
            Debug.Log("OUCH!");
            PlayerStart -= gameStateScript.PlayerHinder;
        }

        //if (obj.gameObject.tag == "Weapon")
        //{
        //    audio.PlayOneShot(ItemCollected);
        //    PlayerStart -= gameStateScript.PlayerHinder;
        //}

        if (obj.gameObject.tag == "Obstacle")
        {
            BackgroundController.HurtSound();
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
            gameStateScript.Won = true;
            gameStateScript.GameOver = true;
            gameStateScript.Playing = false;
            MainGUI.Won = true;
            MainGUI.GameOver = false;
            Time.timeScale = 0.0f;
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Dumpster")
        {
            jumpSoundScript.DumpsterSound();
           // BackgroundController.DumpsterSound();
        }
    }
}
