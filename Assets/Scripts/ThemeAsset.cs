using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Tema", menuName = "SO_AssetData/Tema", order = 2)]
public class ThemeAsset : ScriptableObject
{
    // VARIABLES
    public Color backTileColor = Color.black;
    public Sprite backTileSprite;
    public TileAsset[] tileAssets;
    
    // Propiedades
    public int TileCount{
        get { return tileAssets.Length;}
    }
}
