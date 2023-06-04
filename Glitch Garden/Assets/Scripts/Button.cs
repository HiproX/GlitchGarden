using Mono.CompilerServices.SymbolWriter;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class Button : MonoBehaviour
{
    public static GameObject SelectedDefender { get; set; }
    public GameObject defenderPrefab;
    private SpriteRenderer sprite;
    private Color hideColor;
    private Button[] buttonArray;
    private Text costLabel;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        hideColor = sprite.color;
        buttonArray = GameObject.FindObjectsOfType<Button>();
        costLabel = GetComponentInChildren<Text>();
        costLabel.text = defenderPrefab.GetComponent<Defender>().scoreCost.ToString();
    }

    void Update()
    {
        
    }
    private void OnMouseDown()
    {
        SelectedDefender = defenderPrefab;
        foreach (var button in buttonArray) {
            button.Hidden = true;
        }
        Hidden = false;
    }

    public bool Hidden
    {
        set
        {
            if (value)
            {
                sprite.color = hideColor;
            }
            else
            {
                sprite.color = Color.white;
            }
        }
    }
}
