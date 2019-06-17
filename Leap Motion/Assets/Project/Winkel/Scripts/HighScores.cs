using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HighScores : MonoBehaviour
{
    public TMP_InputField input;
    public TextMeshProUGUI scoreText;
    public RectTransform scrollRect;


    void Start()
    {
        UpdateUI();
    }

    public void SaveScore()
    {
        if(input.text == "DELETE_SCORES") { ClearScores(); return; }

        HighScoreManager._instance.SaveHighScore(input.text, GameManager.GM.score);
        GetComponent<Button>().enabled = false;
        UpdateUI();
    }

    public void ClearScores()
    {
        HighScoreManager._instance.ClearLeaderBoard();
        UpdateUI();
    }

    public void Play()
    {
        SceneManager.LoadScene(0);
    }

    public void UpdateUI()
    {
        scoreText.text = "";        
        List<Scores> scores = HighScoreManager._instance.GetHighScore();
        scrollRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, scores.Count * 47f);
        foreach (Scores score in scores)
        {
            scoreText.text += score.score + " - " + score.name + "\n";
            
        }
    }
}
