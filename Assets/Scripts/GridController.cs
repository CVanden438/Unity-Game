using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridController : MonoBehaviour
{
    [SerializeField]
    private int width;

    [SerializeField]
    private int height;

    [SerializeField]
    private float cellSize;
    public GridCell[,] gridArray;
    public GridCell gridCellPrefab;
    public GameObject towerPrefab;
    public bool isGridActive;
    public Color highlightColor;
    public ToggleGrid toggleGrid;

    private void Start()
    {
        gridArray = new GridCell[width, height];
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                GridCell cell = Instantiate(
                    gridCellPrefab,
                    GetWorldPosition(x, y) + new Vector3(cellSize, cellSize) * 0.5f,
                    Quaternion.identity
                );
                gridArray[x, y] = cell;
                Debug.DrawLine(
                    GetWorldPosition(x, y),
                    GetWorldPosition(x, y + 1),
                    Color.white,
                    100f
                );
                Debug.DrawLine(
                    GetWorldPosition(x, y),
                    GetWorldPosition(x + 1, y),
                    Color.white,
                    100f
                );
            }
        }
        toggleGrid.Toggle();
    }

    private Vector3 GetWorldPosition(int x, int y)
    {
        return new Vector3(x, y) * cellSize;
    }

    private void GetXY(Vector3 worldPosition, out int x, out int y)
    {
        x = Mathf.FloorToInt(worldPosition.x / cellSize);
        y = Mathf.FloorToInt(worldPosition.y / cellSize);
    }

    public void SetValue(int x, int y, int value)
    {
        if (x >= 0 && y >= 0 && x < width && y < height)
        {
            // Debug.Log(x + "," + y);
            // Debug.Log(gridArray);
            // cell.SetCellColor(highlightColor);
            if (isGridActive)
            {
                GridCell cell = gridArray[x, y];
                Instantiate(
                    towerPrefab,
                    GetWorldPosition(x, y) + new Vector3(cellSize, cellSize) * 0.5f,
                    Quaternion.identity
                );
            }
        }
    }

    public void SetValue(Vector3 worldPosition, int value)
    {
        int x,
            y;
        GetXY(worldPosition, out x, out y);
        SetValue(x, y, value);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            SetValue(point, 20);
        }
    }

    public GridCell[,] GetGrid()
    {
        return gridArray;
    }

    public void ToggleActive()
    {
        isGridActive = !isGridActive;
    }
}
