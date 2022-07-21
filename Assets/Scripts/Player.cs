using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Player 
{
    public string name;
    public Color pColor = Color.white;
    [Space]
    public int score;
    public int strike;
    public int attempts;
    public int lives = 10;
}
