using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaivior : MonoBehaviour
{
    [SerializeField] private Transform _centerPoint;
    [SerializeField] private float _radius;
    [SerializeField] private LayerMask _obstacleMask;
    private bool _canDestroyObstacle = false;
    private Collider[] _hitObstacle;

    private void Update()
    {
        
        /*Collider[]*/ _hitObstacle = Physics.OverlapSphere(_centerPoint.position, _radius, _obstacleMask);

        /*if (_canDestroyObstacle)
        {
            foreach (Collider obstacle in _hitObstacle)
            {
                Destroy(obstacle.gameObject, 0.8f);
            }
        }*/
        
    }

    private void OnDrawGizmosSelected()
    {
        if (_centerPoint == null)
            return;

        Gizmos.DrawWireSphere(_centerPoint.position, _radius); 
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Goal")
        {
            Destroy(gameObject);
        }

        if (collision.collider.tag == "Obstacle")
        {
            _canDestroyObstacle = true;
            Destroy(gameObject, 1.9f);
            foreach (Collider obstacle in _hitObstacle)
            {
                obstacle.GetComponent<Obstacle>().ToDestroyColor();
                Destroy(obstacle.gameObject, 0.5f);
            }
        }
    }
}
