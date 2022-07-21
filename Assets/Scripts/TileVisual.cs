using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class TileVisual : MonoBehaviour
{
    [SerializeField] private float expansionFactor = .2f;
    [Space]
    public Image outline;
    [Header("Front")]
    public Transform frontPanel;
    public Image frontBorder;
    public Image frontBg;
    public Color frontColor = Color.white;
    public Image frontIcon;
    public Color frontIconColor = Color.white;
    [Header("Back")]
    public Transform backPanel;
    public Image backBg;
    public Color backColor = Color.white;
    public Image backIcon;
    [SerializeField] Animator anim;


    void Start()
    {
        backPanel.gameObject.SetActive(true);
        frontPanel.gameObject.SetActive(false);
        outline.enabled = false;
    }

    public void ApplyAssetStyle(TileAsset asset, ThemeAsset theme)
    {
        // Set Front
        frontBg.color = frontColor = asset.tileColor;
        frontIcon.sprite = asset.icon;
        frontIcon.color = asset.iconColor;
        if(asset.alwaysUseArt)
        {
            frontIcon.color = Color.white;
            frontIcon.sprite = asset.art;
        }
        // Set Back
        backBg.color = backColor= theme.backTileColor;
        frontIcon.color = frontIconColor =asset.iconColor;
        backIcon.sprite = theme.backTileSprite;
    }

    public void OnFlipUp()
    {
        backPanel.gameObject.SetActive(false);
        frontPanel.gameObject.SetActive(true);
        outline.enabled = true;
    }

    public void OnFlipDown()
    {
        backPanel.gameObject.SetActive(true);
        frontPanel.gameObject.SetActive(false);
        outline.enabled = false;
    }

    public void Esconder()
    {
        Retract();
        anim.Play("Flip Tile Down");
    }

    public void Mostrar()
    {
        Expand();
        anim.Play("Flip Tile Up");
    }

    public void Expand()
    {
        transform.localScale += new Vector3(expansionFactor, expansionFactor, 0);
    }

    public void Retract()
    {
        transform.localScale -= new Vector3(expansionFactor, expansionFactor, 0);
    }
}
