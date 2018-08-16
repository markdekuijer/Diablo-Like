using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyArrow : MonoBehaviour {

    [SerializeField] private float projectileSpeed;

    void Update()
    {
        transform.position += transform.forward * projectileSpeed * Time.deltaTime;

        if (Vector3.Distance(transform.position, CharacterBehaviour.currentPosition) > 50)
            gameObject.SetActive(false);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<HealthManager>().Damage(10);
            gameObject.SetActive(false);
        }
        if (other.gameObject.CompareTag("Wall"))
        {
            gameObject.SetActive(false);
        }
    }
}
