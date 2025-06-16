using UnityEngine;

public class ShadowSwap : MonoBehaviour
{
    public Transform shadow;
    public GameObject swapEffectPrefab;

    private AudioSource audioSource;
    private SwapUIManager uiManager; // ✅ On ajoute ce champ pour afficher le message

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        uiManager = FindObjectOfType<SwapUIManager>(); // 🔍 Trouve l’objet qui gère l’UI
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (shadow != null)
            {
                // 🔊 Son (avant swap ou annulation)
                if (audioSource != null && audioSource.clip != null)
                {
                    audioSource.Play();
                }

                Vector2 direction = shadow.position - transform.position;
                float distance = direction.magnitude;

                // 🔦 Raycast pour bloquer le swap si obstacle
                RaycastHit2D hit = Physics2D.Raycast(transform.position, direction.normalized, distance, LayerMask.GetMask("Obstacle"));

                if (hit.collider != null)
                {
                    Debug.Log("Swap bloqué par un mur !");

                    // ✅ Appelle le message si gestionnaire présent
                    if (uiManager != null)
                    {
                        uiManager.ShowSwapBlockedMessage();
                    }

                    return;
                }

                // ↔️ Swap des positions
                Vector3 temp = transform.position;
                transform.position = shadow.position;
                shadow.position = temp;
            }
        }
    }
}
