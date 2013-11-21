using UnityEngine;
using System.Collections;

public class JumpSoundScript : MonoBehaviour {

    public AudioClip[] Jump;
    public AudioClip[] Dumpster;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
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
