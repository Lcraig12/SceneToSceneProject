using UnityEngine;

public class GemSpawner : MonoBehaviour
{
    public GameObject gem1;
    public GameObject gem2;
    public GameObject gem3;
    public GameObject gem4;
    public GameObject gem5;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Instantiate(gem1, new Vector3(-44, 2, 48), Quaternion.identity);
        Instantiate(gem2, new Vector3(-44, 5, 161), Quaternion.identity);
        Instantiate(gem3, new Vector3(-44, 8, 137), Quaternion.identity);
        Instantiate(gem4, new Vector3(-44, 3, 96), Quaternion.identity);
        Instantiate(gem5, new Vector3(-44, 2, 29), Quaternion.identity);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
