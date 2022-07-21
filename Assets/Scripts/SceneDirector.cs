using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneDirector : MonoBehaviour
{
    [SerializeField] int menuScene;
    [SerializeField] int playScene;

    void Awake()
    {
        
    }

    public static void GoTo_MainMenu(){
        SceneManager.LoadScene(0);
    }

    public static void GoTo_GameStage(){
        SceneManager.LoadScene(1);
    }
}
