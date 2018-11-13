using UnityEngine.UI;
using UnityEngine;

public class Score : MonoBehaviour {

    public Text timer;
    //public Text scoreText;
    //public Text hiScoreText;

    public float timerCount = 300;
    public float hiScoreCount;
    public float pointsPerSecond;

    public bool scoreDecreasing;



    
    // Update is called once per frame
	void Update () {

        if (scoreDecreasing)
        {
            timerCount -= pointsPerSecond * Time.deltaTime; 
        }

        //if (scoreCount > hiScoreCount)
        //{
        //    hiScoreCount = scoreCount;
        //}

        string minutes = Mathf.Floor(timerCount / 60).ToString("00");
        string seconds = (timerCount % 60).ToString("00");


        timer.text = "Time: " + string.Format("{0}:{1}", minutes,seconds);
        //scoreText.text = "Score: " + Mathf.Round(scoreCount);
        //hiScoreText.text = "High Score: " + Mathf.Round(hiScoreCount);
	}
}
