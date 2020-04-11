using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyAI : MonoBehaviour
{
    public GameObject textStance;

    public stanceChoice currentStance = stanceChoice.Neutral;

    public void ChooseStance(){

    currentStance = RandomStance();
    textStance.GetComponent<TextMesh>().text = currentStance.ToString() + " Stance";
    }
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("ChooseStance", 2.0f, 2.0f);



    }
    private stanceChoice RandomStance()
    {

        return (stanceChoice)(UnityEngine.Random.Range(0, Enum.GetNames(typeof(stanceChoice)).Length));

    }

}
