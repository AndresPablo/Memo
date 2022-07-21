using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    void Awake()
    {
        if(Instance == null)
            Instance = this;
        else
        if(Instance != this)
            Destroy(gameObject);
        
        DontDestroyOnLoad(this.gameObject);
    }

    public ThemeAsset[] themesList;
    private int temaElegido;
    [Space]
    public Player[] player;
    public bool versusMode = false;

    void Start()
    {
        
    }

    public void SetVersusMode(bool state)
    {
        versusMode = state;
    }

    public void ElegirTema(int i)
    {
        temaElegido = i;
    }

    public ThemeAsset GetTheme()
    {
        return themesList[temaElegido];
    }

}
