using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region Singeltone DontDestroyOnLoad
    public static GameManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    #endregion


    [SerializeField] private TextMeshProUGUI ScoreText;
    [SerializeField] private GameObject ReadyBTN;
    [SerializeField] private TextMeshProUGUI ReadyPlayerName;

    private int TotalScore;

    private void Start()
    {
        Time.timeScale = 0;
    }
    private void Update()
    {
        ScoreText.text = TotalScore.ToString();
    }

    public void addScore(int score)
    {
        TotalScore += score;
    }

    public void ResetScene() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
        ReadyBTN.SetActive(true);
        Time.timeScale = 0;


    }
    public void LaunchBall()
    {
        Time.timeScale = 1;
    }
}
