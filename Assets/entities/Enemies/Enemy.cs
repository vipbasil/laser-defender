using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Enemy : MonoBehaviour {
    public int MaxHP = 100;
    private float HP ;
	public GameObject laser;
    public GameObject explosion;
	public float ShootingRate = 2.0f;
	public float DeltaShootingRate = 0.2f;
    public static int killed = 0;
    private float waitTime;
	private float timer;
    // Use this for initialization
	void SetTimer(){
		timer = 0;
		waitTime = Random.Range (ShootingRate - DeltaShootingRate, ShootingRate + DeltaShootingRate);
	}
	void Start () {
        HP = (float)MaxHP;
        explosion = GameObject.Find("Explosion");
		SetTimer ();
	}

    void OnTriggerEnter2D(Collider2D col)
    {
         
            HP -= col.gameObject.GetComponent<LaserScript>().Damage;
            print(HP);
            Destroy(col.gameObject);
            if (HP <= 0) {
                killed++;
                explosion.GetComponent<AudioSource>().Play();
                Destroy(gameObject);
                
            }
      
    }
    // Update is called once per frame
    void Update () {
		timer += Time.deltaTime;
		if (timer > waitTime) {
			GameObject laserObject = Instantiate(laser, transform.position + Vector3.down * 0.75f, Quaternion.identity) as GameObject;
			SetTimer();

		}
	
	}
}
