using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {
    public GameObject EnemyPrefab;
    public float Width = 10f;
    public float Height = 10f;
    public float Speed = 1f;
    public float SpawnRate = 0.5f;
    private Vector3 Velocity;
    private float minx;
    private float maxx;
	// Use this for initialization
	void Start () {
        Velocity = Vector3.left;

        float distance = transform.position.z - Camera.main.transform.position.z;
        Vector3 leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        Vector3 rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));
        minx = leftmost.x + Width / 2;
        maxx = rightmost.x - Width / 2;
        SpawnUntillFull();


    }
    void Spawn() {
        foreach (Transform child in transform)
        {
            GameObject enemy = Instantiate(EnemyPrefab, child.transform.position, Quaternion.identity) as GameObject;
            enemy.transform.parent = child.transform;
        }
    }
    void OnDrawGizmos() {
        Gizmos.DrawWireCube(transform.position, new Vector3(Width, Height, 0));
    }
    bool EmptyField() {
        foreach (Transform child in transform)
        {
            if (child.childCount > 0)
                return false;
        }
        return true;
    }
    Transform NextFreePosition()
    {
        foreach (Transform child in transform)
        {
            if (child.childCount == 0)
                return child;
        }
        return null;
    }
    void SpawnUntillFull() {
        Transform freePosition = NextFreePosition();
        if (freePosition) {
            GameObject enemy = Instantiate(EnemyPrefab, freePosition.transform.position, Quaternion.identity) as GameObject;
            enemy.transform.parent = freePosition.transform;
        }
        if (NextFreePosition()) {
            Invoke("SpawnUntillFull", SpawnRate);
            
        }
    }
    // Update is called once per frame
    void Update () {
        if (EmptyField()) {
            SpawnUntillFull();
        }
        if (((transform.position + Velocity * Speed ).x  < minx && Velocity == Vector3.left)|| ((transform.position + Velocity * Speed).x  > maxx && Velocity == Vector3.right)) {
            Velocity = -Velocity;
            
        }
        transform.position += Velocity * Speed;

    }
}
