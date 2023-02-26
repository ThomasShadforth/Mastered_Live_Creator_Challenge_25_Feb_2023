using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : Subject
{
    public GameObject[] baseStages;
    public int baseScore;

    public bool gameEnded;
    public string team;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeScoreState()
    {
        if (baseScore < baseStages.Length)
        {

            baseScore++;
            baseStages[baseScore - 1].SetActive(true);
        }
        NotifyObservers(ScoreEnum.Add_1);
    }

    private void OnTriggerEnter(Collider other)
    {
        //Determine whether to check if the other object was a player or AI
        if (other.gameObject.tag == team)
        {
            if (other.GetComponentInChildren<TargetObject>())
            {
                ChangeScoreState();
                other.GetComponentInChildren<TargetObject>().gameObject.SetActive(false);

                if (other.GetComponent<PlayerGrab>())
                {
                    other.GetComponent<PlayerGrab>().isGrabbing = false;
                }

            }
        }

    }
}
