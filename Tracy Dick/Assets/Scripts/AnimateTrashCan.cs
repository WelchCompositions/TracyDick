using UnityEngine;
using System.Collections;

public class AnimateTrashCan : MonoBehaviour 
{
    public AnimationClip TrashCanAnim;
	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (Input.GetKey("a"))
        {
            Animation();
        }
        if (transform.localRotation.x > 85)
        {
            renderer.enabled = false;
        }
	}

    public void Animation()
    {
        animation.Play("TrashCanOver");
    }
}
