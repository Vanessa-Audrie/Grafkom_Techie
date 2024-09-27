using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    int score;
    public static GameManager Instance;
    public Text scoreText;
    public PlayerMovement playerMovement;

    public void IncrementScore()
    {
        score++;
        scoreText.text = "Score: " + score;
        //tambah speed player
        playerMovement.speed += playerMovement.speedIncreasePerPoint;
    }

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
