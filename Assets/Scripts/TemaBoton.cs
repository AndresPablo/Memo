using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TemaBoton : MonoBehaviour
{
    public int tema = 0;
    [SerializeField] TextMeshProUGUI label;
    [SerializeField] Image icon;

    public void LoadData(int _i)
    {
        ThemeAsset asset = DataManager.Instance.themesList[_i];
        tema = _i;
        label.text = asset.name;
        icon.sprite = asset.backTileSprite;
    }

    // DEPRECATED
    public void ChangeLabel(string text)
    {
        label.text = text;
    }

    public void OnClickButton()
    {
        DataManager.Instance.ElegirTema(tema);
        SceneDirector.GoTo_GameStage();
    }
}
