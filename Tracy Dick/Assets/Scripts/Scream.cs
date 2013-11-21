using UnityEngine;
using System.Collections;

public class Scream : MonoBehaviour 
{

    public AudioClip ScreamSound;
    public AudioClip OnIt;
    public int ScreamCount = 0;
    public int OnItCount = 0;
    public bool PlayOnIt;
    public bool LoadNext;
    public float LoadTimer;

	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        LoadTimer += Time.deltaTime;
        if (ScreamCount == 0)
        {
            audio.PlayOneShot(ScreamSound);
            OnItCount += 1;
            PlayOnIt = true;
        }
        if (OnItCount == 0 && PlayOnIt)
        {
            audio.PlayOneShot(OnIt);
            LoadNext = true;
        }

        if (LoadTimer > 10.0f && LoadNext)
            Application.LoadLevel("Main");
	}
}
