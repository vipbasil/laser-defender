using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelManager : MonoBehaviour {
    public Text score;

    void Update() {
        score.text = "Score : " + Enemy.killed; 
    }
    void Reset()
    {
        Enemy.killed = 0;
    }
	public void LoadLevel(string name){
		Debug.Log ("New Level load: " + name);
        
		Application.LoadLevel (name);
	}

	public void QuitRequest(){
		Debug.Log ("Quit requested");
		Application.Quit ();
	}

}
