using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public int highScore;
    public TMP_Text scoreText;
    public TMP_Text highScoreText;
    public GameObject gameOverScreen;
    public GameObject titleScreen;
    public AudioSource scoreSFX;
    public GameObject bird;
    public GameObject pipes;

    [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd)
    {
        if (!gameOverScreen.activeSelf){
        playerScore += scoreToAdd;
        scoreSFX.Play();
        scoreText.text= playerScore.ToString();
        }
    }

    public void restartGame()
    {
        if (playerScore > highScore){
            Debug.Log("New High Score");
            PlayerPrefs.SetInt("High Score", playerScore);
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        highScore = PlayerPrefs.GetInt("High Score", -1); 
        highScoreText.text=highScore.ToString();
    }

    public void gameOver()
    {
        gameOverScreen.SetActive(true);
    }

    void Start()
    {
        PlayerPrefs.SetInt("High Score", 0);
    }

    public void startGame(){
        Debug.Log(highScore);
        titleScreen.SetActive(false);
        bird.SetActive(true);
        pipes.SetActive(true);
        scoreText.gameObject.SetActive(true);

    }
}
