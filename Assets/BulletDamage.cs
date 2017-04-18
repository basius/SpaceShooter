using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamage : MonoBehaviour {

    private Game_Controller gameControler;
    public int scoreValue;
    void Start()
    {
        //Accés a la referencia d'objecte del game controler, ja que al estar a hierarchy, null en cas de que el tag no existeixi
       gameControler = GameObject.FindWithTag("GameController").GetComponent<Game_Controller>();
    }
	void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "enemy")
        {
            Destroy(coll.gameObject);
            scoreValue = 10;
            gameControler.AddScore(scoreValue);
        }

        if (coll.gameObject.tag == "ship")
        {
            gameControler.GameOver();
            Destroy(coll.gameObject);       
        }

    }
}
