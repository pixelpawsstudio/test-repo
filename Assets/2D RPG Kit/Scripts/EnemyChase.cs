using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChase : MonoBehaviour
{
    Transform player;
    [SerializeField] float speed;
    bool isChasing = false;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>().transform;
        GameObject[] spawnPoint = GameObject.FindGameObjectsWithTag("SpawnPoint");
        int randomSpawnPoint = Random.Range(0, spawnPoint.Length);
        transform.position = spawnPoint[randomSpawnPoint].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(isChasing)
        {
            Vector2 direction = player.position - transform.position;
            direction.Normalize();
            transform.position += (Vector3)direction * Time.deltaTime * speed;

            animator.SetFloat("moveX", transform.position.x);
            animator.SetFloat("moveY", transform.position.y);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(UnactivateEnemy());
        }
        
    }

    IEnumerator UnactivateEnemy()
    {
        Debug.Log("Unactivating enemy");
        yield return new WaitForSeconds(3);

        this.gameObject.SetActive(false);
    }

    void StartChasing()
    {
        this.isChasing = true;
    }

    void StopChasing()
    {
        this.isChasing = false;
    }
}
