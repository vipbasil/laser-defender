using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {
    public GameObject EnemyPrefab;
    public float Width = 10f;
    public float Height = 10f;
    public float Speed = 1f;
    private Vector3 Velocity;
    private float minx;
    private float maxx;
	// Use this for initialization
	void Start () {
        Velocity = Vector3.left * Speed;

        float distance = transform.position.z - Camera.main.transform.position.z;
        Vector3 leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        Vector3 rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));
        minx = leftmost.x + Width / 2;
        maxx = rightmost.x - Width / 2;

        foreach (Transform child in transform)
        {
            GameObject enemy = Instantiate(EnemyPrefab, child.transform.position, Quaternion.identity) as GameObject;
            enemy.transform.parent = child.transform;
        }
	}
    void OnDrawGizmos() {
        Gizmos.DrawWireCube(transform.position, new Vector3(Width, Height, 0));
    }

	
	// Update is called once per frame
	void Update () {
        
        if ((transform.position + Velocity).x  < minx || (transform.position + Velocity).x  > maxx) {
            Velocity = -Velocity;
            
        }
        transform.position += Velocity;

    }
}
