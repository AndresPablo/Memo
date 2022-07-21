using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileLogic : MonoBehaviour
{
    public TileAsset asset;
    public TileVisual visual;
    GameManager gm;

    bool selected;

    void Start()
    {
        gm = GameManager.instance;
    }

    public void LoadAssetData(TileAsset _asset, ThemeAsset _theme)
    {
        asset = _asset;
        
        visual.ApplyAssetStyle(_asset, _theme);
    }

    public void HandleClick()
    {
        if(gm.canReveal == false && selected==false)
            return;



        visual.Mostrar(); 
        gm.TileSelected(this);
        selected = true;
    }

    public void Deselect()
    {
        selected = false;
        visual.Esconder(); 
    }
}
