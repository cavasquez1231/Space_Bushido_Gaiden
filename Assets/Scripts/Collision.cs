using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum stanceChoice
{
    Left,
    Up,
    Right,
    Down,
    Neutral
}

public class Collision : MonoBehaviour
{
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
            DetermineWinner();
        }
    }

//Determine Winner uses a dictionary of lists that contain the winners for each stance and compares them.
    void DetermineWinner() {

        List<stanceChoice> nuetralwinners = new List<stanceChoice>();
        nuetralwinners.Add(stanceChoice.Down);
        nuetralwinners.Add(stanceChoice.Left);

        List<stanceChoice> rightwinners = new List<stanceChoice>();
        rightwinners.Add(stanceChoice.Up);
        rightwinners.Add(stanceChoice.Neutral);

        List<stanceChoice> downwinners = new List<stanceChoice>();
        downwinners.Add(stanceChoice.Right);
        downwinners.Add(stanceChoice.Up);

        List<stanceChoice> leftwinners = new List<stanceChoice>();
        leftwinners.Add(stanceChoice.Right);
        leftwinners.Add(stanceChoice.Down);

        List<stanceChoice> upwinners = new List<stanceChoice>();
        upwinners.Add(stanceChoice.Neutral);
        upwinners.Add(stanceChoice.Left);

//stanceChoice is the key, and the list of winners for that stance is the value. We'll get the winners of they stance by using it as the key
        Dictionary<stanceChoice, List<stanceChoice>> winners = new Dictionary<stanceChoice, List<stanceChoice>>
            {
                { stanceChoice.Neutral, nuetralwinners },
                { stanceChoice.Right, rightwinners },
                { stanceChoice.Down, downwinners },
                { stanceChoice.Left, leftwinners },
                { stanceChoice.Up, upwinners },
            };

//This logic compares the playerStance to the enemy stance and determines the winner
            if (playerStance == enemyStance) {
                Debug.Log(playerStance + " collided with " + enemyStance);
                Debug.Log("It's a Draw!");
                return;
            }
            else{
                var playerWinners = winners[playerStance];
                if (playerWinners.Contains(enemyStance))
                {
                    Debug.Log(playerStance + " collided with " + enemyStance);
                    Debug.Log("You Win!!");
                }
                else
                {
                    Debug.Log(playerStance + " collided with " + enemyStance);
                    Debug.Log("You Lose!!");
                }

            }
    }
}
