using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerScoreGet : MonoBehaviour
{
    public TextMeshProUGUI scoreBoard;

    public GameObject highScore;

    // Start is called before the first frame update
    private void Start()
    {
        int score = 0;

        if (PlayerPrefs.HasKey("Score")) //score kaydı oluşmuşsa
            score = PlayerPrefs.GetInt("Score");//bu değeri ekrana yazdırmak için değişkene atıyoruz
        else
            score = 0;

        if (PlayerPrefs.HasKey("HighScore"))//yüksek skor varsa
        {
            if (score > PlayerPrefs.GetInt("HighScore"))
            {
                PlayerPrefs.SetInt("HighScore", score);//karşılaştırıp yüksek skora atıyoruz
                highScore.SetActive(true);
            }

        }
        else
            PlayerPrefs.SetInt("HighScore", score);//yoksa diğer yüksek skor varsayıyoruz.

        scoreBoard.SetText(score.ToString());
    }
}
