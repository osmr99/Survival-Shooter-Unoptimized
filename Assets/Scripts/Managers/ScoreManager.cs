using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
    public static int score;


    static Text text;


    void Awake ()
    {
        score = 0;
        text = GameObject.Find("ScoreText").GetComponent<Text>(); // For a one time call, this for
                                                                 // optimization is fine. For a overall project, it's not very smart.
    }


    /*void Update ()
    {
        text.text = "Score: " + score;
    }*/

    static public void updateScore(int value)
    {
        score += value;
        text.text = "Score: " + score;
    }
}
