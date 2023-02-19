using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaivior : MonoBehaviour
{
    [SerializeField] private Transform _centerPoint;
    [SerializeField] private LayerMask _obstacleMask;
    [SerializeField] private GameObject _destroyBulletEffect;
    private Collider[] _hitObstacle;

    private void Update()
    {
        
        /*Collider[]*/ _hitObstacle = Physics.OverlapSphere(_centerPoint.position, transform.localScale.x * 2, _obstacleMask);      
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Goal")
        {
            Destroy(gameObject);
        }

        if (collision.collider.tag == "Obstacle")
        {
            DestroyBulletEffect();
            Destroy(gameObject, 0.1f);
            foreach (Collider obstacle in _hitObstacle)
            {
                obstacle.GetComponent<Obstacle>().ToDestroyColor();
                obstacle.GetComponent<Obstacle>().DestroyEffect();
                Destroy(obstacle.gameObject, 0.1f);
            }
        }
    }

    private void DestroyBulletEffect()
    {
        GameObject destroyEffect = (GameObject)Instantiate(_destroyBulletEffect, transform.position, transform.rotation);
        Destroy(destroyEffect, 2f);
    }
}
