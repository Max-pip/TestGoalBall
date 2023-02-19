using UnityEngine;

public class Goal : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private LayerMask _obstacleLayer;
    [SerializeField] private Player _player;
    private Vector3 _rayVector;
    private Ray _ray;
    private string _playerTag = "Player";

    private RaycastHit _hit;

    private void Start()
    {
        _rayVector = new Vector3(transform.position.x, transform.position.y - 1.5f, transform.position.z);
    }

    private void Update()
    {
        _ray = new Ray(_rayVector, transform.forward);
        Debug.DrawRay(_rayVector, transform.forward * 10f, Color.blue);

        if (Physics.Raycast(_ray, out _hit, 10f, _obstacleLayer))
        {
            return;
        } else
        {
            _player.SetActiveRB(); /*.canMoveToGoal = true;*/
        }
    }

    public void Open()
    {
        _animator.SetTrigger("Open");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == _playerTag)
        {
            _animator.SetTrigger("Open");
        }
    }
}
