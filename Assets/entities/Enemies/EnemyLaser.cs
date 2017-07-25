using UnityEngine;
using System.Collections;

public class EnemyLaser : MonoBehaviour {

	public int maxHP;
	public float Speed;
	public float Damage = 10f;
	private float HP;
	// Use this for initialization
	void Start () {
		HP = (float) maxHP;
	}
	
	// Update is called once per frame
	void Update () {
		if (HP > 0)
		{
			HP--;
			transform.position += Vector3.down * Speed;
		}
		else {
			GameObject.Destroy(gameObject);
		}
	}
	public void Hit(){
		GameObject.Destroy(gameObject);
	}
}
