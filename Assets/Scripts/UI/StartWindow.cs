using UnityEngine;
using UnityEngine.UI;

public class StartWindow : MonoBehaviour
{
    [SerializeField] private Text pointsText;
    
    private void Awake()
    {
        GameController.currentGame.OnDataChanged += UpdateView;
    }

    public void OnClickStart()
    {
        GameController.currentGame.StartGame();
    }

    private void UpdateView()
    {
        var playerData = GameController.currentGame.PlayerData;
        if (playerData == null) return;

        pointsText.text = $"Max result: {playerData.MaxPoints}";
    }
}
