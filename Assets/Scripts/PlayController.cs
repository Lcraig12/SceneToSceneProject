using UnityEngine;
using Unity.Cinemachine;

public class PlayController : MonoBehaviour
{
    public GameObject player;
    public CinemachineCamera vcam;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //instantiates a prefab of the player at the given position w/ given rotation
        //(aka places player at the start of the path for the first scene)

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        GameObject spawnedPlayer = Instantiate(player, new Vector3(55, 2, 60), Quaternion.Euler(new Vector3(0,-95,0)));
        vcam.Follow = spawnedPlayer.transform;
        vcam.LookAt = spawnedPlayer.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
