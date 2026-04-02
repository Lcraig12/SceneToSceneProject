using UnityEngine;
using Unity.Cinemachine;
using UnityEngine.InputSystem;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class PlayController_SCENE2 : MonoBehaviour
{
    public GameObject player;
    public CinemachineCamera vcam;
    public int gemCollectCount = 0;
    public GameObject gem1;
    public GameObject gem2;
    public GameObject gem3;
    public GameObject gem4;
    public GameObject gem5;
    public int lives = 3;

    public TextMeshProUGUI restartText;
    public TextMeshProUGUI gemCountText;
    public TextMeshProUGUI livesText;

    public float cooldown;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        restartText.text = "";
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
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
        if(gemCollectCount >= 5)
        {
            SceneManager.LoadScene("3rdScene");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Gem"))
        {
            other.gameObject.SetActive(false);
            gemCollectCount++;
            gemCountText.text = "Gems Collected: " + gemCollectCount.ToString() +"/5";
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
                    player.transform.position = new Vector3(-44, 1, 39);
                    gemCollectCount = 0;
                    gem1.SetActive(true);
                    gem2.SetActive(true);
                    gem3.SetActive(true);
                    gem4.SetActive(true);
                    gem5.SetActive(true);
                    lives = 3;
                    livesText.text = "Lives: " + lives.ToString();
                    gemCountText.text = "Gems Collected: " + gemCollectCount.ToString() +"/5";
                    SceneManager.LoadScene("Dungeon");
                }
                else
                {
                    livesText.text = "Lives: " + lives.ToString();
                }
            }
            
            

        }
    }



}

