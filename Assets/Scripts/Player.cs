using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Panels")]
    [SerializeField] private GameObject _losePanel;
    [SerializeField] private GameObject _winPanel;

    [Header("Setting")]
    [SerializeField] private Transform _target;
    [SerializeField] private GameObject _prefab;
    private Rigidbody _rb;
    private GameObject _currentPrefab;
    private float _prefabSpeed = 0f;
    private bool _canChangeSize;
    private bool _isLose = false;
    private bool _canMoveToGoal = false;
    private string _goalTag = "Goal";

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.isKinematic = true;
        _rb.detectCollisions = false;
    }

    private void Update()
    {
        currentPrefab();

        Lose();

        if (_canMoveToGoal)
        {
            MoveToGoal();
        }
    }

    public void PlayerLocalScale()
    {
        if (!_isLose && !_canMoveToGoal)
        {
            if (_canChangeSize)
            {
                transform.localScale -= new Vector3(0.009f, 0.009f, 0.009f);
            }
            if (_currentPrefab == null)
            {
                _currentPrefab = (GameObject)Instantiate(_prefab, new Vector3(0, 1, -10), transform.rotation);
            }

            if (_currentPrefab != null && _canChangeSize)
            {
                _currentPrefab.transform.localScale += new Vector3(0.009f, 0.009f, 0.009f);
            }
        }       
    }

    public void ButtonUp()
    {
        _canChangeSize = false;
        SetSpeedBullet(10);
    }

    public void SetActiveRB()
    {
        _canMoveToGoal= true;
        _rb.isKinematic = false;
        _rb.detectCollisions = true;
    }

    private void MoveToGoal()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target.position, 5f * Time.deltaTime);
    }

    public void SetSpeedBullet(float speed)
    {
        _prefabSpeed = speed;
    }

    private void currentPrefab()
    {
        if (_currentPrefab != null)
        {
            _currentPrefab.transform.position += Vector3.forward * _prefabSpeed * Time.deltaTime;
        }
        if (_currentPrefab == null)
        {
            _prefabSpeed = 0f;
            _canChangeSize = true;
        }
    }

    private void Lose()
    {
        if (transform.localScale.x < 0.3f)
        {
            _isLose = true;
            _canChangeSize = false;
            _losePanel.SetActive(true);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        _rb.AddForce(Vector3.up * 4, ForceMode.Impulse);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == _goalTag)
        {
            _winPanel.SetActive(true);
        } 
    }
}
