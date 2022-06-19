using UnityEngine;

public class EnemyVision : MonoBehaviour
{
    private EnemyMovement _movement;
    private void Awake()
    {
        _movement = transform.parent.GetComponent<EnemyMovement>();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && !Blocked(other))
            _movement.LookAt(other.transform);
    }
    

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            _movement.ReturnToSpawn();
    }

    private bool Blocked(Collider2D other)
    {
        var dir = (other.transform.position - transform.position).normalized;
        RaycastHit2D[] hits = 
            Physics2D.RaycastAll(transform.position, dir);
        Debug.DrawRay(transform.position, dir, Color.red, 10.0f);
        int i = 0;
        while (i < hits.Length && (hits[i].transform.CompareTag("Enemy")))
            ++i;

        if (i == hits.Length)
            return true;
        var blocked = !hits[i].collider.gameObject.CompareTag("Player");
        return blocked;
    }
}
