using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionScript : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    private PlayerSound playerSound;

    private void Awake()
    {
        playerSound = GetComponent<PlayerSound>();
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.collider.CompareTag("Obstacle"))
        {
            gameManager.isGameOver = true;
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            Destroy(other.gameObject);

            playerSound.PlayCoinSound();
        }
    }
}
