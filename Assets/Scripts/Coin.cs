using UnityEngine;

public class Coin : MonoBehaviour
{

    public float turnSpeed = 90f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Obstacle>() != null)
        {
            Destroy(gameObject);
            return;
        }
        
        //cek collide atau tidak
        if (other.gameObject.name != "Player")
        {
            return;
        }
        //add score
        GameManager.Instance.IncrementScore();

        //destroy coin
        Destroy(gameObject);
    }

    void Start()
    {
        
    }

    void Update()
    {
        transform.Rotate(0, 0, turnSpeed * Time.deltaTime);
    }
}
