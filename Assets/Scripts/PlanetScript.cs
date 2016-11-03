using UnityEngine;
using System.Collections;

public class PlanetScript : MonoBehaviour {

    GameObject playerSprite;
	// Use this for initialization
	void Start () {
        playerSprite = GameObject.Find("PlayerSprite");
	}
	
	// Update is called once per frame
	void Update () {

        float distance = Vector3.Distance(this.transform.position, playerSprite.transform.position);
        if(distance < 20.0F){
            var direction = -(playerSprite.GetComponent<Rigidbody2D>().transform.position - this.transform.position);
            if (playerSprite.GetComponent<Rigidbody2D>())
            {
                playerSprite.GetComponent<Rigidbody2D>().AddForce(direction);
            }
        }
        else
        {
            playerSprite.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            playerSprite.GetComponent<Rigidbody2D>().angularVelocity = 0.0F;
        }
	}
}
