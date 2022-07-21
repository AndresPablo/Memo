using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Ficha", menuName = "SO_AssetData/Ficha", order = 1)]
public class TileAsset : ScriptableObject
{
    public string altName;
    [Space]
    public Sprite icon;
    public Sprite art;
    public Color tileColor = Color.black;
    public Color iconColor = Color.white;
    public bool alwaysUseArt;
    [Space]
    [TextArea(5,10)]
    public string description;
}
