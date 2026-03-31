using UnityEngine;
using Unity.Cinemachine;
using UnityEngine.SceneManagement;
using Unity.Cinemachine;
using UnityEngine.InputSystem;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class PlayController : MonoBehaviour
{
    //public GameObject spawnedPlayer;
    public GameObject player;
    public GameObject door;
    public CinemachineCamera vcam;
    //public float fspeed = 500;

    [SerializeField] private float speed = 5f;
    [SerializeField] private float gravity = -9.81f;

    private CharacterController character;
    private Vector3 velocity;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        character = GetComponent<CharacterController>();
    }
    
    void Start()
    {
        //instantiates a prefab of the player at the given position w/ given rotation
        //(aka places player at the start of the path for the first scene)
        //player = Resources.Load("Planet_object") as GameObject;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        
        //spawnedPlayer = Instantiate(player, new Vector3(55, 2, 60), Quaternion.Euler(new Vector3(0,-95,0)));
        vcam.Follow = player.transform;
        vcam.LookAt = player.transform;
    }
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Door"))
        {
            SceneManager.LoadScene("Dungeon");
        }
    }

    /*

    void FixedUpdate()
    {


        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-speed * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0, 0, speed * Time.deltaTime);

        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0, 0, -speed * Time.deltaTime);

        }

    }
    */
    
    
}