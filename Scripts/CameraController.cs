using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    private Vector2 velocity;

    public float smoothTimeX;
    public float smoothTimeY;

    public PlayerController player;

    public bool bounds;

    public Vector3 minCameraPos;
    public Vector3 maxCameraPos;

    public float yOffset;     

    void Start()
    {
        
    }

    void FixedUpdate()
    {
		player = FindObjectOfType<PlayerController>();
        float posX = Mathf.SmoothDamp(transform.position.x, player.transform.position.x, ref velocity.x, smoothTimeX);
        float posY = Mathf.SmoothDamp(transform.position.y, player.transform.position.y, ref velocity.y, smoothTimeY);

        transform.position = new Vector3(posX, posY, transform.position.z);

        if (bounds)
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, minCameraPos.x, maxCameraPos.x),
                Mathf.Clamp(transform.position.y, minCameraPos.y, maxCameraPos.y),
                Mathf.Clamp(transform.position.z, minCameraPos.z, maxCameraPos.z));
        }
        if (Input.GetKey(KeyCode.DownArrow) && !player.onLadder)
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, minCameraPos.x, maxCameraPos.x),
                Mathf.Clamp(transform.position.y, minCameraPos.y, maxCameraPos.y) - yOffset,
                Mathf.Clamp(transform.position.z, minCameraPos.z, maxCameraPos.z));
        }
    }
}
