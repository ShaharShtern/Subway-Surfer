using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuCanvas : MonoBehaviour
{
    public GameObject playerRef;
    public GameObject gameOverMenu;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartGame()
    {
        //playerRef.GetComponent<MovementScript>().enabled = true;
        playerRef.GetComponent<PlayerController>().StartRunning();
    }
    public void StartOver()
    {
        playerRef.GetComponent<PlayerController>().enabled = false;
        gameOverMenu.SetActive(enabled);
    }
    public void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
