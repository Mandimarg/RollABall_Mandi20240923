using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int currentScore = 0;
    public Text scoreText;
    public Text leaderboardText;

    // When the game ends, call this function to save the score and update the leaderboard
    public void EndGame()
    {
        SaveScore(currentScore);
        ShowLeaderboard();
    }

    // Save the score into PlayerPrefs
    void SaveScore(int score)
    {
        // Assuming you want to store the top 5 scores
        for (int i = 0; i < 5; i++)
        {
            if (PlayerPrefs.GetInt("score_" + i) < score)
            {
                // Shift scores down the leaderboard
                for (int j = 4; j > i; j--)
                {
                    PlayerPrefs.SetInt("score_" + j, PlayerPrefs.GetInt("score_" + (j - 1)));
                }
                PlayerPrefs.SetInt("score_" + i, score);
                break;
            }
        }
    }

    // Display the leaderboard
    void ShowLeaderboard()
    {
        string leaderboard = "Leaderboard\n";
        for (int i = 0; i < 5; i++)
        {
            leaderboard += (i + 1) + ". " + PlayerPrefs.GetInt("score_" + i) + "\n";
        }
        leaderboardText.text = leaderboard;
    }

    // Call this function when the player wants to start a new game
    public void StartNewGame()
    {
        currentScore = 0;
        scoreText.text = "Score: " + currentScore;
    }

    // Update the score during gameplay
    public void UpdateScore(int points)
    {
        currentScore += points;
        scoreText.text = "Score: " + currentScore;
    }
}
