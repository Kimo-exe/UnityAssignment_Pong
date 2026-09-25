using TMPro;
using Unity.AppUI.UI;
using UnityEditor.Callbacks;
using UnityEngine;

public class Manager : MonoBehaviour
{

    public int P1_Score;

    public int P2_Score;

    public TextMeshProUGUI P2_ScoreText;
    public TextMeshProUGUI P1_ScoreText;

    public BallController ball;

    void Start()
    {
        // Just in case!
        P1_Score = 0;
        P2_Score = 0;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void ScoreLeft()
    {
        P1_Score++;
        P1_ScoreText.text = P1_Score.ToString();
        ball.ResetBall();
    }

    public void ScoreRight()
    {
        P2_Score++;
        P2_ScoreText.text = P2_Score.ToString();
        ball.ResetBall();
    }
}
