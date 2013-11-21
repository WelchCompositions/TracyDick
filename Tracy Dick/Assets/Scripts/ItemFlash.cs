using UnityEngine;
using System.Collections;

public class ItemFlash : MonoBehaviour {

    public int x;
	// Use this for initialization
	void Start () {
	
	}
    void OnEnable()
    {

    }
	// Update is called once per frame
	void Update () 
    {
        if (Input.GetKey("a"))
            Flash();
      
    }

    public void Flash()
    {
        if (x > 0)
        {
            renderer.enabled = !renderer.enabled;
            x--;
        }
        else
            Destroy(gameObject);
    }
}
