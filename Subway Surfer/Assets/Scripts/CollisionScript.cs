using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionScript : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    private PlayerSound playerSound;
    [HideInInspector] public int coins;
    private Animator animator;

    private void Awake()
    {
        playerSound = GetComponent<PlayerSound>();
        animator = GetComponentInChildren<Animator>();
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.collider.CompareTag("Obstacle"))
        {
            gameManager.isGameOver = true;
            playerSound.PlayDefeatSound();
            animator.SetTrigger("Death");
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            Destroy(other.gameObject);

            playerSound.PlayCoinSound();

            coins++;
        }
    }
}
