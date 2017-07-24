using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    // Use this for initialization
    public float Speed = 15f;
    public float FireRate = 0.2f;
    public GameObject laser;
    private float minx;
    private float maxx;
	void Start () {
        float distance = transform.position.z - Camera.main.transform.position.z;
        Vector3 leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0,0,distance));
        Vector3 rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));
        minx = leftmost.x + gameObject.GetComponent<SpriteRenderer>().bounds.size.x / 2;
        maxx = rightmost.x - gameObject.GetComponent<SpriteRenderer>().bounds.size.x / 2; ;
    }

    // Update is called once per frame
    void Fire() {
        GameObject laserObject = Instantiate(laser, transform.position + Vector3.up * 0.75f, Quaternion.identity) as GameObject;
    }

    void Update () {
        float speed = Speed * Time.deltaTime;

        if (Input.GetKey(KeyCode.RightArrow))
        {

            this.transform.position += Vector3.right * speed;

        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.position += Vector3.left * speed;
        }
       if (Input.GetKeyDown(KeyCode.Space)) {
            InvokeRepeating("Fire", 0.00001f, FireRate);
           
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            CancelInvoke("Fire");

        }
        float newx = Mathf.Clamp(this.transform.position.x, minx, maxx);
        transform.position = new Vector3(newx, this.transform.position.y);

    }
}
