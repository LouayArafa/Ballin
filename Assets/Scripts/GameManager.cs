using System.Collections;
using System.Collections.Generic;
using System.Linq;
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


    [SerializeField] private List<TextMeshProUGUI> PlayersScore = new List<TextMeshProUGUI>();
    [SerializeField] private List<int> Scores = new List<int>();

    [SerializeField] private List<TextMeshProUGUI> PlayersNames = new List<TextMeshProUGUI>();

    [SerializeField] private int CurrPlayerID = -1; //reset at -1

    [SerializeField] private TextMeshProUGUI RoundText;
    [SerializeField] private GameObject ReadyBTN;
    [SerializeField] private TextMeshProUGUI ReadyPlayerName;

    [SerializeField] private GameRules rules;

    [SerializeField] private GameObject GameResultScreen;

    private int currentRound = 1;
    private int maxRounds;



    private void Start()
    {

        StartBallin();

    }

    void StartBallin()
    {
        Time.timeScale = 0;
        maxRounds = rules.RoundsCout;
        currentRound = 1;
        //display names and score in top right

        //trimming lists
        PlayersNames.RemoveRange(rules.PlayersCount, PlayersNames.Count - rules.PlayersCount);
        PlayersScore.RemoveRange(rules.PlayersCount, PlayersScore.Count - rules.PlayersCount);
        Scores.RemoveRange(rules.PlayersCount, Scores.Count - rules.PlayersCount);
        rankingText.RemoveRange(rules.PlayersCount, rankingText.Count - rules.PlayersCount);

        int i = 0;
        foreach (TextMeshProUGUI name in PlayersNames)
        {
            name.text = rules.PlayerNames[i];
            i++;
        }
        foreach (TextMeshProUGUI score in PlayersScore)
        {
            score.text = 0.ToString();
        }
        RoundText.text = "Round: " + currentRound + "/" + maxRounds;
        NextPlayer();
    }


    public void AddScore(int score)
    {
        Scores[CurrPlayerID] += score;
        PlayersScore[CurrPlayerID].text = Scores[CurrPlayerID].ToString();
    }


    public void NextPlayer()
    {
        CurrPlayerID++; //next player
        Debug.Log("Player turn " + CurrPlayerID);
       
        if (CurrPlayerID >= PlayersScore.Count)
        {
            CurrPlayerID = 0; // Loop back
            currentRound++;

            if (currentRound > maxRounds)
            {
                EndGame();
                return;
            }
            RoundText.text = "Round: " + currentRound + "/" + maxRounds;

        }

        UpdateUIForNextPlayer();
    }

    private void UpdateUIForNextPlayer()
    {

        ReadyPlayerName.text = rules.PlayerNames[CurrPlayerID] + " Turn";
        ReadyBTN.SetActive(true);
        Time.timeScale = 0;
    }
    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
        ReadyBTN.SetActive(true);
        NextPlayer();
        Time.timeScale = 0;

    }
    public void LaunchBall()
    {
        Time.timeScale = 1;
    }

    
    
    
    
    [Header("EndGame")]
    [SerializeField] private GameObject EndGameUI;
    [SerializeField] private GameObject InGameUI;
    [SerializeField] private List<TextMeshProUGUI> rankingText = new List<TextMeshProUGUI>();


    void EndGame ()
    {
        Time.timeScale = 0;
        EndGameUI.SetActive(true);
        InGameUI.SetActive(false);
        Ranking();
    }



    private void Ranking()
    {
        // Use LINQ to create a sorted list of indices based on Scores
        List<int> sortedIndices = Enumerable.Range(0, Scores.Count)
                                            .OrderByDescending(i => Scores[i])
                                            .ToList();

        for (int i = 0; i < sortedIndices.Count; i++)
        {
            int playerIndex = sortedIndices[i];
            rankingText[i].gameObject.SetActive(true);
            rankingText[i].text = PlayersNames[playerIndex].text + ": " + Scores[playerIndex];
        }
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("Menu");
    }
}
