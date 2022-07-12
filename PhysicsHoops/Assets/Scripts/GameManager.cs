using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] Text scoreText;
    [SerializeField] Text timerText;
    [SerializeField] Transform scoreEndPos;
    [SerializeField] GameObject endMenu;
    [SerializeField] float time = 20;
    public int score;
    private static GameManager _instance;
    public static GameManager Instance { get { return _instance; } }


    private void Awake()
    {
        //singleton
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    private void Update()
    {
        scoreText.text = string.Format("{0:0.00}", score);
        HandleTimer();
    }

    /// <summary>
    /// Handles the timer and what happens when it ends
    /// </summary>
    void HandleTimer() 
    {
        timerText.text = time.ToString();
        if (time > 0)
        {
            time -= Time.deltaTime;
        }
        else
        {
            Time.timeScale = 0;
            endMenu.SetActive(true);
            scoreText.transform.position = scoreEndPos.position;
        }
    }

    /// <summary>
    /// Restarts the scene
    /// </summary>
    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
