using UnityEngine;

public class ShadowFollower : MonoBehaviour
{
    public Transform player;
    public Vector2 offset = new Vector2(2f, 0); // Position décalée

    void Update()
    {
        if (player != null)
        {
            transform.position = player.position + (Vector3)offset;
        }
    }
}
