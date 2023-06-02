using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DefenderSpawner : MonoBehaviour
{
    public Camera myCamera;
    private GameObject defenderParent;
    private ScoreDisplay scoreDisplay;

    void Start()
    {
        scoreDisplay = GameObject.FindObjectOfType<ScoreDisplay>();
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

        Debug.Log($"Выбраны координаты ({roundedPos.x}, {roundedPos.y})");

        var selectedDefender = Button.SelectedDefender;
        if (selectedDefender)
        {
            var cost = selectedDefender.GetComponent<Defender>().scoreCost;

            if (scoreDisplay.UseStars(cost) == ScoreDisplay.Status.Success)
            {
                SpawnDefender(selectedDefender, roundedPos);
            }
            else
            {
                Debug.Log("Недостаточно очков для размещения защитника");
            }
        }
    }

    private void SpawnDefender(GameObject defender, Vector2 position)
    {
        var entity = Instantiate(defender, position, Quaternion.identity);
        entity.transform.SetParent(defenderParent.transform);
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
