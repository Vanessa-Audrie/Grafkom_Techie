using UnityEngine;

public class Obstacle : MonoBehaviour
{
    PlayerMovement playerMovement;
    
    void Start()
    {
        playerMovement = GameObject.FindObjectOfType<PlayerMovement>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        //bunuh player kalau senggol obstacle
        if (collision.gameObject.name == "Player")
        {
            playerMovement.Die();
        }
        
    }

    void Update()
    {
        
    }
}
