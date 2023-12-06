using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Animator))]

public class MenuRules : MonoBehaviour
{
    [SerializeField] private GameRules gameRules;
    [SerializeField] private int playerCount;
    [SerializeField] private int roundCount;
    [SerializeField] private List<string> playerNames = new List<string>();
    [SerializeField] private Animator animator;

    //Input Fields MUST be in order {player1, player2,player3...}
    [SerializeField] private List<GameObject> NamesInput = new List<GameObject>();
    private void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        ClearGameRules();
        UpdateNameInputDisplay(playerCount);
    }
    public void SetPlayerCount(int x)
    {
        playerCount = x;
        UpdateNameInputDisplay(playerCount);
    }
    public void SetRoundCount(int x)
    {
        roundCount = x;
    }
    
    public void UpdateNameInputDisplay(int playerCount)
    {
        for (int i = 0; i < NamesInput.Count; i++)
        {
            // Enable or disable the input fields based on playerCount
            NamesInput[i].SetActive(i < playerCount);
        }
    }


    public void UpdateNames(int playerID)
    {
        //the list index is playerID - 1
        playerID--;

       
        playerNames[playerID] = NamesInput[playerID].GetComponent<TMP_InputField>().text;
    }

    public void NextBTN()
    {
        animator.SetTrigger("Next");
    }
    public void PrevBTN()
    {
        animator.SetTrigger("Back");


    }


    public void FinalizeRules()
    {
        gameRules.PlayersCount = playerCount;
        gameRules.RoundsCout = roundCount;
        foreach(string playerName in playerNames)
        {
            if(playerName != "")
            {
                gameRules.PlayerNames.Add(playerName);

            }
        }
        SceneManager.LoadScene("Game");
    }



    private void ClearGameRules()
    {
        gameRules.PlayersCount = 0;
        gameRules.RoundsCout = 0;
        gameRules.PlayerNames = new List<string>();
    }


}
