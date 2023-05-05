using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scores : MonoBehaviour
{
    public Text scoreText;
    private int _currentScore;
    void Start()
    {
        _currentScore = 0;
        scoreText.text = _currentScore.ToString();
    }

    public void AddScore()
    {
        _currentScore += 10;
        scoreText.text = _currentScore.ToString();
    }

    public void DeductScore()
    {
        //if koşulunun tek satır hali, 0 dan büyükse 10 azalt değilse 0 yaz
        _currentScore = _currentScore > 0 ? _currentScore - 10 : 0;
        scoreText.text = _currentScore.ToString();
    }

}
