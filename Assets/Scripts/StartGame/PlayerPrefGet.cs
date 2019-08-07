using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerPrefGet : MonoBehaviour
{

    int score;
    public TextMeshProUGUI scoreBoard;
    private void Start()
    {
        if (PlayerPrefs.HasKey("HighScore"))
            score = PlayerPrefs.GetInt("HighScore");
        else
            score = 0;

        scoreBoard.SetText(score.ToString());
    }
}
