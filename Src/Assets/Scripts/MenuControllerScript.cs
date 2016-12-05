using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class MenuControllerScript : MonoBehaviour {

    private float[,] styles = new float[,] { 
        { 0.745f, 0.745f, 0.745f },
        { 0.490f, 0.392f, 0.882f },
        { 0.949f, 0.361f, 0.361f }, 
        { 0.435f, 0.914f, 0.694f } };

    private int visualStyle;
    public new Camera camera;
    public Animator menuAnimator;

    public Text pickupsText;
    public Text pointsScoredText;
    public Text clicksText;
    public Text deathsText;
    public Text bestScoreText;
    
	void Start () {
        visualStyle = PlayerPrefs.GetInt("VisualStyle", 0);
        camera.backgroundColor = new Color(styles[visualStyle, 0], styles[visualStyle, 1], styles[visualStyle, 2]);
        bestScoreText.text = "BEST SCORE: " + PlayerPrefs.GetInt("BestScore", 0);
	}
	
    public void ChangeBackground()
    {
        visualStyle++;
        if(visualStyle == 4)
        {
            visualStyle = 0;
        }
        camera.backgroundColor = new Color(styles[visualStyle, 0], styles[visualStyle, 1], styles[visualStyle, 2]);
        PlayerPrefs.SetInt("VisualStyle", visualStyle);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Gameplay");
    }

    public void OpenStatistics()
    {
        pickupsText.text = PlayerPrefs.GetInt("Pickups", 0).ToString();
        pointsScoredText.text = PlayerPrefs.GetInt("PointsScored", 0).ToString();
        clicksText.text = PlayerPrefs.GetInt("Clicks", 0).ToString();
        deathsText.text = PlayerPrefs.GetInt("Deaths", 0).ToString();

        menuAnimator.SetTrigger("OpenStatisticsTrigger");
    }

    public void CloseStatistics()
    {
        menuAnimator.SetTrigger("CloseStatisticsTrigger");
    }
}
