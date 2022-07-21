using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI whatPlayerLabel;
    [SerializeField] TextMeshProUGUI playerOneScore;
    [SerializeField] TextMeshProUGUI playerTwoScore;
    [SerializeField] GameObject soloPanel;
    [SerializeField] GameObject versusPanel;
    [SerializeField] TextMeshProUGUI soloScoreLabel;
    [Space]
    [SerializeField] TextMeshProUGUI lastTileName;
    [Header("Discovery Panel")]
    [SerializeField] GameObject discoveryPanel;
    [SerializeField] Image titleBg;
    [SerializeField] Image illustration;
    [SerializeField] TextMeshProUGUI titleLabel;
    [SerializeField] TextMeshProUGUI subtitleLabel;
    [SerializeField] TextMeshProUGUI descLabel;
    [Header("Victory Panel Panel")]
    [SerializeField] GameObject victoryPanel;
    [SerializeField] TextMeshProUGUI victoryLabel;
    [SerializeField] TextMeshProUGUI winnerLabel;
    [Space]
    [SerializeField] GameObject gameOverPanel;

    void Start()
    {
        
    }

    public void OnGameStart(bool versusMode)
    {
        playerOneScore.text = "0";
        playerTwoScore.text = "0";
        discoveryPanel.SetActive(false);
        victoryPanel.SetActive(false);
        gameOverPanel.SetActive(false);
        lastTileName.text = "";

        if(versusMode)
            SetVersusGUI();
        else
            SetSoloGUI();
    }

    public void WriteLastTileName(string _name)
    {
        lastTileName.text = _name;
    }

    public void DiscoverTile(TileAsset tile, Player player)
    {
        discoveryPanel.SetActive(true);
        titleLabel.text = tile.name;
        subtitleLabel.text = "Esto falta";
        descLabel.text = tile.description;
        titleBg.color = player.pColor;
    }

    public void WriteWhoseTurn(Player player)
    {
        whatPlayerLabel.text = player.name;
        whatPlayerLabel.color = player.pColor;
    }

    public void UpdateScores(Player playerOne, Player playerTwo)
    {
        soloScoreLabel.text = playerOne.score.ToString();
        playerOneScore.text = playerOne.score.ToString();
        playerOneScore.text = playerTwo.score.ToString();
    }

    public void DisplayVictory(Player winner, bool versusMode)
    {
        victoryPanel.SetActive(true);
        winnerLabel.text = winner.name;
        winnerLabel.color = winner.pColor;

        if(versusMode)
            victoryLabel.text = "gana!";
        else
        {
            victoryLabel.text = "¡Ganaste!";
            winnerLabel.text = "";
        } 
    }

    public void DisplayTie()
    {
        victoryPanel.SetActive(true);
        victoryLabel.text = "¡Empate!";
    }

    public void DisplayGameOver()
    {
        gameOverPanel.SetActive(true);
    }

    void SetSoloGUI()
    {
        whatPlayerLabel.gameObject.SetActive(false);
        soloPanel.SetActive(true);
        versusPanel.SetActive(false);

        soloScoreLabel.text = DataManager.Instance.player[0].score.ToString() ;
    }

    void SetVersusGUI()
    {
        soloPanel.SetActive(false);
        versusPanel.SetActive(true);
        whatPlayerLabel.gameObject.SetActive(true);

        playerOneScore.color = DataManager.Instance.player[0].pColor;
        playerTwoScore.color = DataManager.Instance.player[1].pColor;

        playerOneScore.text = DataManager.Instance.player[0].score.ToString();
        playerTwoScore.text = DataManager.Instance.player[1].score.ToString();
    }
}
