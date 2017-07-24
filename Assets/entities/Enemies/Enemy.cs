using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
    public int MaxHP = 100;
    private float HP ;
    // Use this for initialization
    void Start () {
        HP = (float)MaxHP;
	}

    void OnTriggerEnter2D(Collider2D col)
    {
 
        if (col.gameObject.tag == "PlayerLaser") {
            HP -= col.gameObject.GetComponent<LaserScript>().Damage;
            print(HP);
            Destroy(col.gameObject);
            if (HP <= 0) {
                Destroy(gameObject);
            }
        }
    }
    // Update is called once per frame
    void Update () {
	
	}
}
