using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool isGameOver = false;
    [SerializeField] private MenuCanvas menuCanvas = null;
    private void Update()
    {
        if (isGameOver)
        {
            menuCanvas.StartOver();
        }
    }
    //public void AddToScore()
   // {

   // }
}
