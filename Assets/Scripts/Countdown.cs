using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
    [SerializeField] private Image _time;
    [SerializeField] private Text _timeText;
    [SerializeField] private float _currentTime;
    [SerializeField] private float _duration;
    void Start()
    {
        _currentTime = _duration;
        _timeText.text = _currentTime.ToString();
        StartCoroutine(CountdownTime());
    }

    private void SahneGec()
    {
        int birSonrakiSahneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (birSonrakiSahneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(birSonrakiSahneIndex);
        }
        else
        {
            Debug.Log("Son sahneye ulaşıldı!");
            // Son sahneye ulaşıldığında yapılması gereken işlemleri burada gerçekleştirebilirsiniz.
        }
    }

        private IEnumerator CountdownTime () {
        while(_currentTime >= 0) {
            _time.fillAmount = Mathf.InverseLerp(0, _duration, _currentTime);
            _timeText.text = _currentTime.ToString();
            yield return new WaitForSeconds(1f);
            _currentTime--;
        }

        SahneGec();
    }
}
