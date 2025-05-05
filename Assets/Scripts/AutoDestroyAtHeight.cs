using UnityEngine;

public class AutoDestroyAtHeight : MonoBehaviour
{
    public Transform player;
    public float destroyHeight = 10f;

    void Update()
    {
        if (player.position.y > destroyHeight)
        {
            Destroy(gameObject);
        }
    }
}
