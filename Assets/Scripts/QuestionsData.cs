using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class QuestionsData : MonoBehaviour
{
    public Questions questions;
    [SerializeField] private Text _questionText;

    void Start()
    {
        AskQuestion();
    }

    public void AskQuestion()
    {
        if(CountValidQuestions() == 0)
        {
            _questionText.text = string.Empty;
            ClearQuestion();
            SceneManager.LoadScene("EndScene");
            return;
        }

        var randomIndex = 0;
        do
        {
            randomIndex = UnityEngine.Random.Range(0, questions.questionsList.Count);
        } while (questions.questionsList[randomIndex].questioned == true);

        questions.currentQuestion = randomIndex;
        questions.questionsList[questions.currentQuestion].questioned = true;
        _questionText.text = questions.questionsList[questions.currentQuestion].question;
    }

    public void ClearQuestion()
    {
        foreach (var question in questions.questionsList)
        {
            question.questioned = false;
        }
    }

    private int CountValidQuestions()
    {
        int validQuestions = 0;
        foreach (var question in questions.questionsList)
        {
            if(question.questioned == false)
            {
                validQuestions++;
            }
        }

        Debug.Log("Question Left: " + validQuestions);
        return validQuestions;
    }
}
