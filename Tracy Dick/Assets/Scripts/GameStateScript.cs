using UnityEngine;
using System.Collections;

public class GameStateScript : MonoBehaviour
{
    public MovePlayer MovePlayer;

    public float BackgroundOneSpeed;
    public float BackgroundTwoSpeed;
    public float BackgroundThreeSpeed;
    public float FloorSpeed;

    public AudioClip WasCollected;

    public float WeaponSpeed;
    public float PlatformSpeed;
    public float TrashSpeed;

    public int ItemsCollected;
    public int WeaponsInPlay;
    public int TrashCansInPlay;
    public int BackgroundsInPlay;

    public int MaxDropHeight;
    public int MinDropHeight;

    public float Credibility;
    public float CredReduction;
    public int CredAddition;
    public float BackgroundTimer;
    public float BackgroundResetTime;
    public float Life;

    public Transform[] Weapons;
    public Transform[] TrashCans;
    public Transform[] Backgrounds;
    public int[] WeaponDropHeightArray;

    public Transform Wrench;

    public float PlayerMoveSpeed;
    public float PlayerHinder;

    public bool GameOver;
    public bool Playing;
    //public bool CreateBackground;
    public bool Lost;
    public bool Won;

    public float BigTimer;
    public float LittleTimer;
    public float ReallyBigTimer;
    public bool CanCreate;
    public float WeaponTimer;
    public int RotateSpeed;

    // Use this for initialization
    void Start()
    {
        DontDestroyOnLoad(transform.gameObject);
        Application.LoadLevel("Menu");
    }

    // Update is called once per frame
    void Update()
    {
        CanCreate = true;
        if (Playing)
        {
            Credibility -= Time.deltaTime * CredReduction;
        }

        if (Credibility <= 0)
        {
            GameOver = true;
        }
            if (!GameOver)
            {
                if (WeaponsInPlay < 1)
                {
                    WeaponTimer -= Time.deltaTime;
                    if (WeaponTimer <= 0)
                    {
                        var WeaponDropHeight = Random.Range(0, 3);
                        var WeaponToDrop = Random.Range(0, Weapons.Length);
                        Instantiate(Weapons[WeaponToDrop], new Vector3(-14, WeaponDropHeightArray[WeaponDropHeight], -11f), Quaternion.identity);
                        Debug.Log("Weapon drop height " + WeaponDropHeight);
                        WeaponsInPlay += 1;
                        WeaponTimer = 1.5f;
                    }  
                }
                //if (Input.GetKeyDown(KeyCode.A))
                //{
                //    Instantiate(Wrench, new Vector3(-14, 4, -11f), Quaternion.identity);
                //}
                if (TrashCansInPlay < 1)
                {
                    var TrashCanToDrop = Random.Range(0, TrashCans.Length);
                    Instantiate(TrashCans[TrashCanToDrop], new Vector3(80, -3, -4), Quaternion.identity);
                    TrashCansInPlay += 1;
                }
            }                 
    }

    public void CreateBackground()
    {
        var BackgroundToCreate = Random.Range(0, Backgrounds.Length);
        Instantiate(Backgrounds[BackgroundToCreate], new Vector3(0, 11, 0), Quaternion.identity);
        //BackgroundTimer = BackgroundResetTime;
    }

    public void Reset()
    {
        ItemsCollected = 0;
        WeaponsInPlay = 0;
        TrashCansInPlay = 0;
        BackgroundsInPlay = 4;
        Credibility = 600;
    }
}
