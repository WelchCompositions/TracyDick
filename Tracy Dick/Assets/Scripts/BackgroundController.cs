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
    public AudioClip[] Hurt;
    public AudioClip[] Jump;
    public AudioClip[] Dumpster;


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

            case "Bat":
                audio.clip = Bat[Random.Range(0, Bat.Length)];
                audio.PlayOneShot(audio.clip);
                gameStateScript.ItemsCollected += 1;
                gameStateScript.WeaponsInPlay -= 1;
                break;

            case "BowlingBall":
                audio.clip = BowlingBall[Random.Range(0, BowlingBall.Length)];
                audio.PlayOneShot(audio.clip);
                gameStateScript.ItemsCollected += 1;
                gameStateScript.WeaponsInPlay -= 1;
                break;

            case "BowlingPin":
                audio.clip = BowlingPin[Random.Range(0, BowlingPin.Length)];
                audio.PlayOneShot(audio.clip);
                gameStateScript.ItemsCollected += 1;
                gameStateScript.WeaponsInPlay -= 1;
                break;

            case "Chair":
                audio.clip = Chair[Random.Range(0, Chair.Length)];
                audio.PlayOneShot(audio.clip);
                gameStateScript.ItemsCollected += 1;
                gameStateScript.WeaponsInPlay -= 1;
                break;

            case "CornDog":
                audio.clip = CornDog[Random.Range(0, CornDog.Length)];
                audio.PlayOneShot(audio.clip);
                gameStateScript.ItemsCollected += 1;
                gameStateScript.WeaponsInPlay -= 1;
                break;

            case "Guitar":
                audio.clip = Guitar[Random.Range(0, Guitar.Length)];
                audio.PlayOneShot(audio.clip);
                gameStateScript.ItemsCollected += 1;
                gameStateScript.WeaponsInPlay -= 1;
                break;

            case "Knife":
                audio.clip = Knife[Random.Range(0, Knife.Length)];
                audio.PlayOneShot(audio.clip);
                gameStateScript.ItemsCollected += 1;
                gameStateScript.WeaponsInPlay -= 1;
                break;

            case "Revolver":
                audio.clip = Revolver[Random.Range(0, Revolver.Length)];
                audio.PlayOneShot(audio.clip);
                gameStateScript.ItemsCollected += 1;
                gameStateScript.WeaponsInPlay -= 1;
                break;

            case "WineBottle":
                audio.clip = WineBottle[Random.Range(0, WineBottle.Length)];
                audio.PlayOneShot(audio.clip);
                gameStateScript.ItemsCollected += 1;
                gameStateScript.WeaponsInPlay -= 1;
                break;

            case "FryingPan":
                audio.clip = FryingPan[Random.Range(0, FryingPan.Length)];
                audio.PlayOneShot(audio.clip);
                gameStateScript.ItemsCollected += 1;
                gameStateScript.WeaponsInPlay -= 1;
                break;

            case "Pills":
                audio.clip = Pills[Random.Range(0, Pills.Length)];
                audio.PlayOneShot(audio.clip);
                gameStateScript.ItemsCollected += 1;
                gameStateScript.WeaponsInPlay -= 1;
                break;

            case "Poison":
                audio.clip = Poison[Random.Range(0, Poison.Length)];
                audio.PlayOneShot(audio.clip);
                gameStateScript.ItemsCollected += 1;
                gameStateScript.WeaponsInPlay -= 1;
                break;

            case "Shovel":
                audio.clip = Shovel[Random.Range(0, Shovel.Length)];
                audio.PlayOneShot(audio.clip);
                gameStateScript.ItemsCollected += 1;
                gameStateScript.WeaponsInPlay -= 1;
                break;

            case "Spatula":
                audio.clip = Spatula[Random.Range(0, Spatula.Length)];
                audio.PlayOneShot(audio.clip);
                gameStateScript.ItemsCollected += 1;
                gameStateScript.WeaponsInPlay -= 1;
                break;

            case "Steak":
                audio.clip = Steak[Random.Range(0, Steak.Length)];
                audio.PlayOneShot(audio.clip);
                gameStateScript.ItemsCollected += 1;
                gameStateScript.WeaponsInPlay -= 1;
                break;

            case "Crowbar":
                audio.clip = Crowbar[Random.Range(0, Crowbar.Length)];
                audio.PlayOneShot(audio.clip);
                gameStateScript.ItemsCollected += 1;
                gameStateScript.WeaponsInPlay -= 1;
                break;
        }
    }
    public void HurtSound()
    {
        audio.clip = Hurt[Random.Range(0, Hurt.Length)];
        audio.PlayOneShot(audio.clip);
    }

    public void JumpSound()
    {
        audio.clip = Jump[Random.Range(0, Jump.Length)];
        audio.PlayOneShot(audio.clip);
    }

    public void DumpsterSound()
    {
        audio.clip = Dumpster[Random.Range(0, Dumpster.Length)];
        audio.PlayOneShot(audio.clip);
    }

}
