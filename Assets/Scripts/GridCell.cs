using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridCell : MonoBehaviour
{
    public Color highlightColor;
    public Color defaultColor;

    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update()
    {
        // Cast a ray from the mouse position
        Vector2 rayPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(rayPos, Vector2.zero, Mathf.Infinity);

        // Check if the ray hits any colliders
        if (hit.collider != null)
        {
            // Check if the hit collider belongs to the object you're interested in
            if (hit.collider.gameObject == gameObject)
            {
                // The mouse is hovering over this object
                // Debug.Log("Mouse is hovering over this object.");
                SetCellColor(highlightColor);
            }
            else
            {
                SetCellColor(defaultColor);
            }
        }
    }

    public void HideCell()
    {
        gameObject.SetActive(false);
    }

    public void ShowCell()
    {
        gameObject.SetActive(true);
    }

    public void SetCellColor(Color color)
    {
        GetComponent<Renderer>().material.color = color;
    }
}
