using System;
using Player;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private static GameController _instance;
    public static GameController currentGame => _instance ?? (_instance = new GameController());

    public PlayerData PlayerData;
    public event Action OnDataChanged;
    

    public void StartGame()
    {
        Debug.Log("Start Game");
    }
}
