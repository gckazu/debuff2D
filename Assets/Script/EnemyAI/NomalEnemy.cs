using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class NomalEnemy : MonoBehaviour
{
    [SerializeField] private Transform _playerTarget;
    [SerializeField] private float _moveSpeed = 3.5f;
    [SerializeField] private float _stopDistance = 0.6f;

    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        if (_playerTarget == null)
        {
            GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
            if (playerObject != null)
            {
                _playerTarget = playerObject.transform;
            }
        }

        if (_playerTarget == null)
        {
            Debug.LogWarning($"{gameObject.name}: Player target is not set.");
        }
    }

    private void FixedUpdate()
    {
        if (_playerTarget == null)
        {
            _rigidbody.linearVelocity = Vector2.zero;
            return;
        }

        float distance = Vector2.Distance(transform.position, _playerTarget.position);
        if (distance <= _stopDistance)
        {
            _rigidbody.linearVelocity = Vector2.zero;
            return;
        }

        float direction = Mathf.Sign(_playerTarget.position.x - transform.position.x);
        _rigidbody.linearVelocity = new Vector2(direction * _moveSpeed, _rigidbody.linearVelocity.y);
    }
}
