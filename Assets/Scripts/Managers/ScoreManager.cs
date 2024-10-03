using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    //public static int score;

    static Text text;

    [SerializeField] ScoreCounter currentScore; // Scriptable Object


    void Awake ()
    {
        currentScore.score = 0;
        text = GameObject.Find("ScoreText").GetComponent<Text>(); // For a one time call, this for
                                                                 // optimization is fine. For an overall project, it's not very smart.
    }


    /*void Update ()
    {
        text.text = "Score: " + score;
    }*/

    public void updateScore()
    {
        //currentScore.score += value; // This is done in the EnemyHealth script for optimization purposes
        text.text = "Score: " + currentScore.score;
    }
}
