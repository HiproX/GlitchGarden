using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    public Camera myCamera;
    private GameObject defenderParent;

    void Start()
    {
        defenderParent = GameObject.Find("Defenders");

        if (!defenderParent)
        {
            defenderParent = new GameObject("Defenders");
        }
    }


    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        var rawWorldPos = CalculateWorldPointOfMouseClick();
        var roundedPos = SnapToGrid(rawWorldPos);

        Debug.Log($"X:{roundedPos.x} Y:{roundedPos.y}");
        
        if (Button.SelectedDefender)
        {
            var defender = Instantiate(Button.SelectedDefender, roundedPos, Quaternion.identity);
            defender.transform.SetParent(defenderParent.transform);
        }
    }

    private Vector2 SnapToGrid(Vector2 rawWorldPos)
    {
        float newX = Mathf.RoundToInt(rawWorldPos.x);
        float newY = Mathf.RoundToInt(rawWorldPos.y);
        return new Vector2(newX, newY);
    }

    private Vector2 CalculateWorldPointOfMouseClick()
    {
        float mouseX = Input.mousePosition.x;
        float mouseY = Input.mousePosition.y;
        float distanceFromCamera = 10f;
        Vector3 weirdTriplet = new Vector3(mouseX, mouseY, distanceFromCamera);
        Vector2 worldPos = myCamera.ScreenToWorldPoint(weirdTriplet);
        return worldPos;
    }
}
