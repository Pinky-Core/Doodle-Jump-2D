using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float offsetY = 5f;

    void LateUpdate()
    {
        Vector3 newPosition = new Vector3(transform.position.x, player.position.y + offsetY, transform.position.z);
        transform.position = newPosition;
    }
}
