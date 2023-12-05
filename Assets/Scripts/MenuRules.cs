using System.Collections;
using System.Collections.Generic;
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

    private void Start()
    {
        animator = gameObject.GetComponent<Animator>(); 
    }
    public void SetPlayerCount(int x)
    {
        playerCount = x;
    }
    public void SetRoundCount(int x)
    {
        roundCount = x;
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
        gameRules.PlayerNames = playerNames;
        SceneManager.LoadScene("Game");
    }



}
