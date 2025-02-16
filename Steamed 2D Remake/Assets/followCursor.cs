using UnityEngine;

public class followCursor : MonoBehaviour
{
    public float mouseX;
    public float mouseY;
    public Vector2 mouseXY;
    public Transform player;
    public float mouseDistance;
    public float distFromPlayer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        distFromPlayer = 0.75f;
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0; // Keep Z at 0 for 2D
        mouseXY = new Vector2 (mousePos.x, mousePos.y);

        mouseDistance = Vector2.Distance(gameObject.transform.position, mouseXY);

        // Calculate direction from object to mouse
        Vector3 direction = (mousePos - player.position).normalized;

        // Calculate angle (convert to degrees)
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        angle -= 90;

        Vector3 setDistance = player.position + direction * distFromPlayer;
        transform.position = setDistance;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

}
