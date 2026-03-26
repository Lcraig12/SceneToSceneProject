using UnityEngine;

public class NPC01Controller : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private float minimum = 3.7f; //how low the npc goes
    private float maximum = 4.1f; //how high the npc goes

    private float yPos;
    private float bounceSpeed = .8f;
    // Update is called once per frame
    void Update()
    {
        
        float sinValue = Mathf.Sin(Time.time * bounceSpeed);

        yPos = Mathf.Lerp(maximum, minimum, Mathf.Abs(sinValue));
        transform.position = new Vector3(transform.position.x, yPos, transform.position.z);
    }
}
