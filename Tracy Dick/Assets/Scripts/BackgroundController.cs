using UnityEngine;
using System.Collections;

public class BackgroundController : MonoBehaviour 
{
    public GameStateScript gameStateScript;
    public GameObject gameStateManager;

    public AudioClip ItemCollected;

    public AudioClip[] Wrench;
    public AudioClip[] Bat;
    public AudioClip[] BowlingBall;
    public AudioClip[] BowlingPin;
    public AudioClip[] Chair;
    public AudioClip[] CornDog;
    public AudioClip[] Guitar;
    public AudioClip[] Knife;
    public AudioClip[] Revolver;
    public AudioClip[] WineBottle;
    public AudioClip[] FryingPan;
    public AudioClip[] Pills;
    public AudioClip[] Poison;
    public AudioClip[] Shovel;
    public AudioClip[] Spatula;
    public AudioClip[] Steak;
    public AudioClip[] Crowbar;


	// Use this for initialization
	void Start () 
    {
        gameStateManager = GameObject.Find("GameStateManager");
        gameStateScript = gameStateManager.GetComponent<GameStateScript>();
        gameStateScript.WeaponsInPlay = 0;
        gameStateScript.TrashCansInPlay = 0;
	}
	
	// Update is called once per frame
	void Update () 
    {
        
	}

    public void Collected()
    {
        audio.PlayOneShot(ItemCollected);
    }

    public void PlayAudio(GameObject gameObject)
    {
        switch (gameObject.tag)
        {
            case "Wrench":
                audio.clip = Wrench[Random.Range(0, Wrench.Length)];
                audio.PlayOneShot(audio.clip);
                gameStateScript.ItemsCollected += 1;
                gameStateScript.WeaponsInPlay -= 1;
                break;
        }
    }


}
