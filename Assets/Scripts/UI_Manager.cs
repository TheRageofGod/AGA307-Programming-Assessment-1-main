using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UI_Manager : Singleton<UI_Manager>
{
    public TMP_Text scoreText;
    public GameObject mainPanel;
    public GameObject pausePanel;
    public TMP_Text enemiesList;
    public TMP_Text difficultyDisplay;
    public Difficulty _difficulty;
    public TMP_Text timer;
    void Start()
    {
        ScoreChanger(0);
        EnemiesChange(0);
        Diff(_difficulty);
    }
    private void Update()
    {
        timer.text = _GM.timeRemaining.ToString();
    }
    void Diff(Difficulty _difficulty)
    {
        difficultyDisplay.text = _difficulty.ToString();
    }
    void ScoreChanger(int _score)
    {
        scoreText.text = "Score:" + _GM.score;
    }
    void EnemiesChange(int _Enemies)
    {
        enemiesList.text = "Enemies Remaining:" + _EM.enemies.Count;
    }
    private void OnEnable()
    {
        GameEvents.OnGameStateChange += OnGameStateChange;
        GameEvents.OnScoreChange += ScoreChanger;
        GameEvents.OnListChange += EnemiesChange;
    }
    private void OnDisable()
    {
        GameEvents.OnScoreChange -= ScoreChanger;
        GameEvents.OnListChange -= EnemiesChange;
    }
  
    public void ReturnToTitle()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Title");
    }
    void OnGameStateChange(GameState _gameState)
    {
        switch (_gameState)
        {
            case GameState.Playing:
                mainPanel.SetActive(true);
                pausePanel.SetActive(false);
                break;
            case GameState.Paused:
                mainPanel.SetActive(false);
                pausePanel.SetActive(true);
                break;
            case GameState.GameOver:
                break;

        }
    }
}
