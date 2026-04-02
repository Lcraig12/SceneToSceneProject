using UnityEngine;
using Unity.Cinemachine;
using UnityEngine.InputSystem;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class PlayController_SCENE3 : MonoBehaviour
{
    public GameObject player;
    public CinemachineCamera vcam;
    public int lives = 3;

    public TextMeshProUGUI restartText;

    public TextMeshProUGUI winText;

    public TextMeshProUGUI livesText;

    public float cooldown;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        restartText.text = "";
        //GameObject spawnedPlayer = Instantiate(player, new Vector3(-44, 1, 38), Quaternion.identity);
        vcam.Follow = player.transform;
        vcam.LookAt = player.transform;
        
    }

    void Update()
    {
        if (cooldown > 0)
        {
            cooldown -= Time.deltaTime;
        }

        //Check if touching house, if so then win scene?
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Home"))
        {
            //Need to hide winText 
            Time.timeScale = 0f;
            winText.text = "You win!";
            //SetCountText();

        }
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            if (cooldown <= 0)
            {
                cooldown = .5f;  // this is the cooldown
                lives--;
                if(lives==0)
                {
                    //Destroy(gameObject);
                    
                    //player.transform.position = new Vector3(342, 34, 351);
                    lives = 3;
                    livesText.text = "Lives: " + lives.ToString();
                    SceneManager.LoadScene("3rdScene");
                    
                }
                else
                {
                    livesText.text = "Lives: " + lives.ToString();
                }
            }
            
            

        }
    }



}

