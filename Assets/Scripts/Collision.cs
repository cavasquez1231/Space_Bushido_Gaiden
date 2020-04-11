using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Collision : MonoBehaviour
{

    public GameObject StanceLogic;

    
	private stanceChoice playerStance = stanceChoice.Neutral, enemyStance = stanceChoice.Neutral;


    public void OnCollisionEnter2D(Collision2D collision)
    {
        //Check if this object collided with the player object
        var playerCollision = collision.collider.GetComponent<PlayerMovement>();

        //Getting the playerStance from the player upon collision
         playerStance = playerCollision.playerStance;

        //Getting the current stance at collision from the enemy
         enemyStance = gameObject.GetComponent<EnemyAI>().currentStance;

        //If the collision was with the player then run DetermineWinner();
        if (playerCollision != null)
        {
            StanceLogic.GetComponent<StanceLogic>().DetermineWinner(playerStance, enemyStance);
        }
    }

}

