using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    GameObject Player;
    GameObject HPText;
    GameObject TimeText;
    GameObject GameOverText;
    GameObject RestartButton;
    GameObject ToTitleButton;

    float playerHp;

    float currentTime = 0;
    float maxTime = 300;
    // Start is called before the first frame update
    void Start()
    {
        this.Player = GameObject.Find("tatejima");
        this.HPText = GameObject.Find("HPText");
        this.TimeText = GameObject.Find("TimeText");
        this.GameOverText = GameObject.Find("GameOver");
        this.RestartButton = GameObject.Find("Restart");
        this.ToTitleButton = GameObject.Find("Title");
        GameOverText.SetActive(false);
        RestartButton.SetActive(false);
            ToTitleButton.SetActive(false);
        ResumeGame();
    }

    // Update is called once per frame
    void Update()
    {
        GetPlayerHP();
        ChangeHPText();
        CountTime();
    }

    void GetPlayerHP()
    {
        this.playerHp = Player.GetComponent<Player>().myHp;
        if(playerHp <= 0) {
            GameOverText.SetActive(true);
            RestartButton.SetActive(true);
            ToTitleButton.SetActive(true);
            StopGame();
        }
    }

    void ChangeHPText()
    {
        this.HPText.GetComponent<Text>().text = "HP:" + playerHp.ToString("F2");
    }

    void CountTime()
    {
        this.currentTime += Time.deltaTime;
        this.TimeText.GetComponent<Text>().text = currentTime.ToString("F1");
        if(currentTime >= maxTime) {
            this.TimeText.GetComponent<Text>().text = "ゲーム終了";
        }
    }

    public void StopGame()
    {
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
    }

    public void GameRestart()
    {
        SceneManager.LoadScene("Fishes");
    }

    public void ToTitle()
    {
        SceneManager.LoadScene("Title");
    }
}
