using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    void Awake()
    {
        instance = this;
    }
    
    [SerializeField] GameObject tilePrefab;
    [Space]
    [SerializeField] Transform gridTransform;
    [SerializeField] UIManager ui;
    [SerializeField] Timer timer;
    [Space]
    [SerializeField] int tileAmount = 20;
    TileLogic[] selectedTiles = {null,null};
    ThemeAsset theme;
    DataManager data;
    float remainingTime;
    int turn;
    int revealedTiles;

    public bool versusMode;
    public bool canReveal {
        get{
            if(selectedTiles[1] == null) 
                return true;
            else
                return false;
        }    
    }
        
    
    void Start()
    {
        data = DataManager.Instance;
        versusMode = data.versusMode;
        Timer.OnTimeOver += GameOver;
        OnGameStart();
    }

    void OnGameStart()
    {

        ui.OnGameStart(versusMode);   // Restart Scores
        ui.WriteWhoseTurn(data.player[turn]);

        // Clear Rect Transform
        foreach (Transform child in gridTransform) {
            GameObject.Destroy(child.gameObject);
        }

        // Copy Data & References
        theme = DataManager.Instance.GetTheme();
        List<TileAsset> allAssets = new List<TileAsset>(theme.tileAssets);

        // Pick X amount of assets
        List<TileAsset> assets = new List<TileAsset>();
        for(int i = 0; i < tileAmount/2; i++)
        {
            int randomIndex = Random.Range(0, allAssets.Count);
            TileAsset _a = allAssets[randomIndex];
            assets.Add(_a);
            allAssets.Remove(_a);
        }

        // Duplicamos
        assets.AddRange(assets);

        // Shuffle the list
        assets.Shuffle();

        // Spawn Tiles
        for(int i = 0; i <tileAmount; i++)
        {
            GameObject tileGO = Instantiate(tilePrefab, gridTransform);
            TileLogic tileScript = tileGO.GetComponentInChildren<TileLogic>();
            
            if(i > assets.Count)
            {
                Debug.LogError("No hay suficientes datos para llenar la grilla!"); // Vemos si alcanzan los datos para llenar la cuadricula
                return;
            }
                
            tileScript.LoadAssetData(assets[i], theme);
        }

        // Dificultad
        if(versusMode)
        {
            turn = Random.Range(0, 1) + 1;            
        }
        else
        {
            timer.Start();
        }
    }
    

    public void TileSelected(TileLogic tile)
    {
        // Duplicate selection Failsafe
        if(selectedTiles[0] == tile || selectedTiles[1] == tile)
            return;

        AudioManager.instance.PlayFlip();


        // Duplicate 
        if (selectedTiles[0] == null)
        {
            selectedTiles[0] = tile;
            ui.WriteLastTileName(tile.asset.name);
        }
            
        else
        if(selectedTiles[1] == null)
        {
            selectedTiles[1] = tile;
            ui.WriteLastTileName(tile.asset.name);
        }
            
        // Aun falta
        if(canReveal)
            return;

        // Son iguales? (tienen el mismo asset)
        if (selectedTiles[0].asset == selectedTiles[1].asset)
        {
            StartCoroutine("SuccessfulMatch");
        }else
            StartCoroutine("FailedToMatch");
    }

    public void Restart(){
        StopAllCoroutines();
        OnGameStart();
    }

    public void Quit()
    {
        // Back to main
        SceneManager.LoadScene(0);
    }

    IEnumerator FailedToMatch()
    {
        yield return new WaitForSeconds(1f);

        selectedTiles[0].Deselect();
        selectedTiles[1].Deselect();
        selectedTiles[0] = selectedTiles[1] = null;

        data.player[turn].lives--;
        if (versusMode == false)
        {
            if (data.player[turn].lives < 1)            
                GameOver();
        }

        AudioManager.instance.PlayNoMatchFX();

        yield return new WaitForSeconds(.5f);

        if(versusMode)
            NextTurn();
    }

    IEnumerator SuccessfulMatch()
    {
        yield return new WaitForSeconds(1f);

        Player player = data.player[turn];
        data.player[turn].score++;
        ui.UpdateScores(data.player[0], data.player[1]);

        ui.DiscoverTile(selectedTiles[1].asset, player);

        //selectedTiles[0].Deselect();
        //selectedTiles[1].Deselect();
        selectedTiles[0] = selectedTiles[1] = null;
        revealedTiles++;

        if(versusMode)
            NextTurn();
    }

    void NextTurn()
    {
        if(turn == 0)
            turn = 1;
        else
        if(turn == 1)
            turn = 0;

        if(versusMode)
            ui.WriteWhoseTurn(data.player[turn]);

        // Evaluar victoria
        if(revealedTiles >= tileAmount)
        {
            if(!versusMode)
                Victory(data.player[0]);
            else
            {
                if(data.player[0].score == data.player[1].score)
                    ui.DisplayTie();
                else if(data.player[0].score > data.player[1].score)
                    Victory(data.player[0]);
                else
                    Victory(data.player[1]);
            }
        }
    }

    void GameOver()
    {
        ui.DisplayGameOver();
    }

    void Victory(Player winner)
    {
        ui.DisplayVictory(winner, versusMode);
    }
}

