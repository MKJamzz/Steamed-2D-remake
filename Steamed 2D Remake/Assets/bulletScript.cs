using JetBrains.Annotations;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.InputSystem;

public class bulletScript : MonoBehaviour
{
    GameObject shield;
    public float lifeTime;
    public float despawnTime;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lifeTime = 0;
        despawnTime = 3f;

        shield = GameObject.Find("Shield");
        transform.position = shield.transform.position; //Spawns it at the shield spot
    }

    // Update is called once per frame
    void Update()
    {
        lifeTime += Time.deltaTime;

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0; // Keep Z at 0 for 2D;





        if (lifeTime >= despawnTime)
        {
            Destroy(gameObject);
        }
    }
}
