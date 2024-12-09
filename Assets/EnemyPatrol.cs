using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{public Transform sp;
public Transform ep;
    Transform player;
    [SerializeField] float speed;
    bool isChasing = false;
    public Animator animator;
public float time;
public float p;

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
        time=time+Time.deltaTime;
        p = Mathf.PingPong(time*speed, 1);
        Vector2 np=(ep.position-sp.position)*p+sp.position;
        transform.position=np;
        
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