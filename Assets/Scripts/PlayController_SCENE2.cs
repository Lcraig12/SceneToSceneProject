using UnityEngine;
using Unity.Cinemachine;

public class PlayController_SCENE2 : MonoBehaviour
{
    public GameObject player;
    public CinemachineCamera vcam;
    public int gemCollectCount;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        GameObject spawnedPlayer = Instantiate(player, new Vector3(-44, 1, 38), Quaternion.identity);
        vcam.Follow = spawnedPlayer.transform;
        vcam.LookAt = spawnedPlayer.transform;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Gem"))
        {
            other.gameObject.SetActive(false);
            gemCollectCount++;
            //SetCountText();
        }
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
}
