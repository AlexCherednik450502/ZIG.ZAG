using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameplayController : MonoBehaviour {

    private float[,] styles = new float[,] {
        { 0.745f, 0.745f, 0.745f },
        { 0.490f, 0.392f, 0.882f },
        { 0.949f, 0.361f, 0.361f },
        { 0.435f, 0.914f, 0.694f } };

    private int visualStyle;
    public new Camera camera;


    void Start()
    {
        visualStyle = PlayerPrefs.GetInt("VisualStyle", 0);
        camera.backgroundColor = new Color(styles[visualStyle, 0], styles[visualStyle, 1], styles[visualStyle, 2]);
    }

    public void Retry()
    {
        SceneManager.LoadScene("Gameplay");
    }

    public void OpenMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
