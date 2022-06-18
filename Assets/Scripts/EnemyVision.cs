using UnityEngine;

public class EnemyVision : MonoBehaviour
{
    private EnemyMovement _movement;
    private void Awake()
    {
        _movement = transform.parent.GetComponent<EnemyMovement>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            _movement.LookAt(other.transform);
    }
}
