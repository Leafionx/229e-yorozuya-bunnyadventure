using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool gameEnded = false;
    
    public void EndGame()
    {
        if (!gameEnded)
        {
            gameEnded = true;
            RestartGame();
        }
    }
    
    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
