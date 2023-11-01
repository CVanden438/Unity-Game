using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleGrid : MonoBehaviour
{
    public GridController gridController;
    public Shooting shootingController;

    public void Toggle()
    {
        shootingController.enabled = !shootingController.enabled;
        var grid = gridController.GetGrid();
        gridController.ToggleActive();
        for (int i = 0; i < grid.GetLength(0); i++)
        {
            for (int j = 0; j < grid.GetLength(1); j++)
            {
                grid[i, j].gameObject.SetActive(!grid[i, j].gameObject.activeInHierarchy);
            }
        }
    }
}
