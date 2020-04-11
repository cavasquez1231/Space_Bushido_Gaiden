using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum stanceChoice
{
    Left,
    Up,
    Right,
    Down,
    Neutral
}

public class StanceLogic : MonoBehaviour
{

    public GameObject EnemyPlayer;

    //Determine Winner uses a dictionary of lists that contain the winners for each stance and compares them.
    public void DetermineWinner(stanceChoice playerStance, stanceChoice enemyStance) {

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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
