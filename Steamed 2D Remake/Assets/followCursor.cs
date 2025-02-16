using UnityEngine;

public class followCursor : MonoBehaviour
{
    public float mouseX;
    public float mouseY;
    public Vector2 mouseXY;
    public float mouseDistance;
    public float shieldRot;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mouseX = Input.mousePosition.x;
        mouseY = Input.mousePosition.y;
        mouseXY = new Vector2(mouseX, mouseY);
        mouseDistance = Vector2.Distance(gameObject.transform.position, mouseXY);


        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0; // Keep Z at 0 for 2D

        // Calculate direction from object to mouse
        Vector3 direction = (mousePos - transform.position).normalized;

        // Calculate angle (convert to degrees)
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        angle -= 90;
        // Apply rotation (subtract 90 if object is facing up by default)
        transform.position = mousePos;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

}
