using UnityEngine;
using System.Collections;

public class TrashSpeedCollider : MonoBehaviour {

    public GameStateScript gameStateScript;
    public GameObject gameStateManager;
    public float ItemSpeed;
    public float OffScreenPosition;
    public float ResetLocation;
    public int FlashTime;
    public bool IsHit;
    public AnimationClip TrashCanAnim;

    // Use this for initialization
    void Start()
    {
        gameStateManager = GameObject.Find("GameStateManager");
        gameStateScript = gameStateManager.GetComponent<GameStateScript>();
    }

    // Update is called once per frame
    void Update()
    {
        ItemSpeed = gameStateScript.TrashSpeed;
        transform.Translate(Vector3.left * Time.deltaTime * ItemSpeed, Space.World);

        if (transform.position.x < OffScreenPosition)
        {
            transform.position = new Vector3(ResetLocation, transform.position.y, transform.position.z);
        }

        if (IsHit)
            Flash();
    }

    void OnTriggerEnter(Collider obj)
    {
        if (obj.gameObject.tag == "Player")
        {
            //Flash and destroy
            IsHit = true;
            gameObject.collider.enabled = false;
            //gameObject.tag = "TrashCanHit";
        }

        if (obj.gameObject.tag == "Enemy")
        {
            //Fall over
            Debug.Log("Not collected");
            Animation();
            gameStateScript.TrashCansInPlay = 0;
            //Destroy(gameObject);
        }

        if (obj.gameObject.tag == "Wall")
        {
            Debug.Log("Not collected");
            gameStateScript.TrashCansInPlay = 0;
            Destroy(gameObject);
        }
    }

    public void Flash()
    {
        if (FlashTime > 0)
        {
            renderer.enabled = !renderer.enabled;
            FlashTime--;
        }
        if (FlashTime <= 0)
        {
            IsHit = false;
            Destroy(gameObject);
            gameStateScript.TrashCansInPlay -= 1;
        }
    }

    public void Animation()
    {
        animation.Play("TrashCanOver");
    }
}
