using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    [SerializeField] GameObject player;
    private int playerScore;
    [SerializeField] Text scoreText;
    [SerializeField] Text coinsText;
    private void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int playerPos = Mathf.FloorToInt(player.transform.position.z);
        playerScore = playerPos * 10;
        scoreText.text ="Score: " + playerScore.ToString();

        coinsText.text = "Coins: " + player.GetComponent<CollisionScript>().coins;
    }
}
