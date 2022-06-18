using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyMovement : MonoBehaviour
{

    [SerializeField] private float enemySpeed;
    [SerializeField] private float baseRange;
    private float _enemyRotation;
    private Transform _enemyTransform;
    private Rigidbody2D _enemyRb;
    private Transform _target;

    private void Awake()
    {
        _enemyRb = GetComponent<Rigidbody2D>();
        _enemyTransform = GetComponent<Transform>();
        _enemyRb.gravityScale = 0;
        _target = transform;
    }

    private void Update()
    {
        FollowTarget();
    }

    private void FollowTarget()
    {
        if (Vector2.Distance(transform.position, _target.position) > baseRange)
            ApproachTarget();
        else
            _enemyRb.velocity = Vector2.zero;
    }

    private void ApproachTarget()
    {
        var dir = (_target.position - transform.position).normalized;
        _enemyRb.velocity = new Vector2(dir.x, dir.y) * enemySpeed;
    }

    private void FixedUpdate()
    {
        LookAtTarget();
    }

    private void LookAtTarget()
    {
        var position = _enemyTransform.position;
        var target = _target.transform.position;
        _enemyRotation = Mathf.Atan2(target.y - position.y,
            target.x - position.x) * Mathf.Rad2Deg + 90;
        _enemyRb.transform.eulerAngles = Vector3.forward * _enemyRotation;
    }

    public void LookAt(Transform target)
    {
        _target = target;
    }
}
