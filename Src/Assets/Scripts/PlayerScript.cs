using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{

    private bool isDead;
    private bool isPlaying = false;
    public float speed;
    private Vector3 direction;
    private int score;
    private float deltaDistance;
    public GameObject ps;
    public GameObject restartButton;
    public Text scoreText;
    public Text yourScoreText;
    public Text bestScoreText;
    public Text newHighScoreText;
    public Animator gameOverAnimator;
    public LayerMask whatIsGround;
    public Transform contactPoint;
    private int clicks;
    private int pickups;

    void Start()
    {
        isDead = false;
        isPlaying = false;
        direction = Vector3.zero;
        score = 0;
        deltaDistance = 0.0f;
        scoreText.text = score.ToString();
    }

    void Update()
    {
        if (!IsGrounded() && isPlaying)
        {
            GameOver();
        }

        if (Input.GetMouseButtonDown(0) && !isDead)
        {
            isPlaying = true;
            clicks++;

            if (direction == Vector3.forward)
            {
                direction = Vector3.left;
            }
            else
            {
                direction = Vector3.forward;
            }
        }       

        if (direction != Vector3.zero && !isDead)
        {
            float distance = speed * Time.deltaTime;
            transform.Translate(direction * distance);

            speed += Time.deltaTime * 0.05f;

            deltaDistance += distance;

            if (deltaDistance >= 5)
            {
                score += (int)deltaDistance / 5;
                scoreText.text = score.ToString();
                deltaDistance = deltaDistance % 5;
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Pickup")
        {
            score += 3;
            pickups++;

            scoreText.text = score.ToString();
            DeltaScoreTextManager.Instance.CreateText("+3");

            other.gameObject.SetActive(false);
            Instantiate(ps, transform.position, Quaternion.identity);
        }
    }

    private void GameOver()
    {
        gameOverAnimator.SetTrigger("GameOverTrigger");
        isPlaying = false;
        isDead = true;
        transform.GetChild(0).transform.parent = null;
        restartButton.SetActive(true);

        yourScoreText.text = score.ToString();

        int bestScore = PlayerPrefs.GetInt("BestScore", 0);

        if (score > bestScore)
        {
            newHighScoreText.gameObject.SetActive(true);
            PlayerPrefs.SetInt("BestScore", score);
            bestScore = score;
        }

        bestScoreText.text = bestScore.ToString();

        PlayerPrefs.SetInt("Pickups", PlayerPrefs.GetInt("Pickups", 0) + pickups);
        PlayerPrefs.SetInt("PointsScored", PlayerPrefs.GetInt("PointsScored", 0) + score);
        PlayerPrefs.SetInt("Clicks", PlayerPrefs.GetInt("Clicks", 0) + clicks);
        PlayerPrefs.SetInt("Deaths", PlayerPrefs.GetInt("Deaths", 0) + 1);
    }

    private bool IsGrounded()
    {
        Collider[] colliders = Physics.OverlapSphere(contactPoint.position, 0.5f, whatIsGround);

        foreach (Collider collider in colliders)
        {
            if (collider.gameObject != gameObject)
            {
                return true;
            }
        }
        return false;
    }
}
