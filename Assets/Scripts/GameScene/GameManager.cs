using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    Mole[] moles;
    public GameObject moleBox;
    public GameObject moleBox2;
    float spawnTimer;
    public float spawnTimerStartTime = 2;
    public float maxSpawnSpeed = 0.8f;
    float spawnSpeedChangeRate = 0.065f;

    int secondPhaseScore;
    bool isSecondPhase = false;


    float moveSpeed = 2;
    float gameOverTimer = 120f; // 2 dakika;

    public TextMeshProUGUI timeValue;

    int Health;
    float fillAmount = 1f;

    public int health
    {
        get
        {
            return Health;
        }
        set
        {
            if (value <= 0)
            {
                GameOver();
            }
            fillAmount -= 0.25f;//can göstergesini azaltıyor.
            HealthValue.fillAmount = fillAmount;
            Health = value;
        }
    }


    public TextMeshProUGUI ScoreValue;
    int Score = 0;
    public int score
    {
        get
        {
            return Score;
        }
        set
        {


            ScoreValue.SetText(value.ToString());
            if (value >= secondPhaseScore && isSecondPhase == false)
            {

                moleBox.SetActive(false);
                moles = null;
                GameObject.FindGameObjectWithTag("Player").GetComponent<CameraController>().Rotate();
                StartCoroutine(RotateComplateWait());
                //SecondPhase();
            }
            Score = value;
        }
    }




    public Image HealthValue;

    // Start is called before the first frame update
    void Start()
    {
        moles = moleBox.GetComponentsInChildren<Mole>();

        HealthValue = GameObject.FindGameObjectWithTag("health").GetComponent<Image>();
        DefaultStats();
        StartGame();
    }

    void StartGame()
    {
        timeValue.SetText(gameOverTimer + " s");
        StartCoroutine(GameOverTimer());

    }

    IEnumerator GameOverTimer()
    {
        while (gameOverTimer > 0)
        {

            yield return new WaitForSeconds(1f);//1 saniyede süreyi bir düşür.
            gameOverTimer -= 1F;
            timeValue.SetText(gameOverTimer + " s");
            if (gameOverTimer <= 0)
            {
                GameOver();
            }
        }
    }
    IEnumerator RotateComplateWait()
    {
        while (isSecondPhase == false)
        {
            if (GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("idleAfterRotate"))
            {
                SecondPhase();
            }
            yield return new WaitForFixedUpdate();

        }
    }
    private void DefaultStats()
    {
        spawnTimer = spawnTimerStartTime;
        Health = 4;
        spawnSpeedChangeRate = 0.07f;
        secondPhaseScore = 6;
    }

    public void GameOver()
    {
        StopCoroutine(GameOverTimer());
        PlayerPrefs.SetInt("Score", Score);//skoru kaydet

        SceneLoader.LoadScene();
    }
    private void SecondPhase()
    {
        StopCoroutine(RotateComplateWait());
        isSecondPhase = true;
        moles = moleBox2.GetComponentsInChildren<Mole>();
        moleBox2.SetActive(true);
    }

    void FixedUpdate()
    {
        spawnTimer -= Time.deltaTime; //mole spawner
        if (spawnTimer <= 0)
        {
            int random = Random.Range(0, 5); // 5 mole den birisini seçiyor

            if (moles[random].isShow == false)//seçilen mole yukarıda değilse yukarı çıkarıyor
            {
                if (isSecondPhase)
                    moles[random].SetMoleHealth(2);
                else
                    moles[random].SetMoleHealth(1);
                moles[random].Show(moveSpeed);
            }

            if (spawnTimerStartTime <= maxSpawnSpeed)
            {//spawn hızı sürekli artıyor.

                spawnTimerStartTime = maxSpawnSpeed;
            }
            else
            {
                spawnTimerStartTime -= spawnSpeedChangeRate;
            }
            spawnTimer = spawnTimerStartTime;
        }
    }
}
