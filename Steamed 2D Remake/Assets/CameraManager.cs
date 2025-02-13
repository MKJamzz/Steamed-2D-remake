using Unity.VisualScripting;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    GameObject player;
    public float zOffset;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.Find("Player");
        zOffset = -10;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 follow = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z + zOffset);
        transform.position = follow;
    }
}
