using UnityEngine;
using TMPro;

public class HeightCounter : MonoBehaviour
{
    public Transform player;
    public TextMeshProUGUI meterText;

    private float maxHeight = 0f;

    void Update()
    {
        if (player.position.y > maxHeight)
        {
            maxHeight = player.position.y;
        }

        int meters = Mathf.FloorToInt(maxHeight);
        meterText.text = meters + " m";
    }
}
