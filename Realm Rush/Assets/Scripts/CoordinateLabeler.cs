using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[ExecuteAlways]
[RequireComponent(typeof(TextMeshProUGUI))]
public class CoordinateLabeler : MonoBehaviour
{
    [SerializeField] Color defaultColor = Color.black;
    [SerializeField] Color blockedColor = Color.grey;
    [SerializeField] Color exploredColor = Color.yellow;
    [SerializeField] Color pathColor = Color.red;

    TextMeshPro label;
    Vector2Int coordinates = new Vector2Int(); // 1)burada coordinate olusturduk, bunun degerlerini DisplayCoordinates fonksiyonunda
    GridManager gridManager;                                                                                            //atadik

    private void Awake()
    {
        gridManager = FindObjectOfType<GridManager>();
        label = GetComponent<TextMeshPro>();
        label.enabled = false;
        DisplayCoordinates();
        //UpdateObjectName();
    }
    void Update()
    {
        if(!Application.isPlaying)
        {
            DisplayCoordinates();
            UpdateObjectName();
            label.enabled = true;
        }

        SetLabelColor();
        ToggleLabels();
    }

    void ToggleLabels()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            label.enabled = !label.enabled;
        }
        
    }

    void SetLabelColor()
    {
        if (gridManager == null) return;

        Node node = gridManager.GetNode(coordinates); //2) ve burada coordinate degeriyle eslesen Node'u cagirdik

        if (node == null) return;

        if(!node.isWalkable)
        {
            label.color = blockedColor;
        }      
        else if(node.isPath)
        {
            label.color = pathColor;
        }
        else if (node.isExplored)
        {
            label.color = exploredColor;
        }
        else
        {
            label.color = defaultColor;
        }
    }

    private void DisplayCoordinates()  
    {
        coordinates.x = Mathf.RoundToInt(transform.parent.position.x / UnityEditor.EditorSnapSettings.move.x);
        coordinates.y = Mathf.RoundToInt(transform.parent.position.z / UnityEditor.EditorSnapSettings.move.z);

        label.text = "(" + coordinates.x + ", " + coordinates.y + ")";
    }

    private void UpdateObjectName()
    {
        transform.parent.name = coordinates.ToString();
    }
}
