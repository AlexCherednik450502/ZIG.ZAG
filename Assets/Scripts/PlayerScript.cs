using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour {

    private bool isDead;

    public float speed;

    private Vector3 direction;

    private int score;

    public GameObject ps;

    public GameObject restartButton;

    public Text ScoreText;

	// Use this for initialization
	void Start () {
        isDead = false;
        direction = Vector3.zero;
        score = 0;
        ScoreText.text = score.ToString();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0) && !isDead)
        {
            if (direction == Vector3.forward)
            {
                direction = Vector3.left;
            }
            else
            {
                direction = Vector3.forward;
            }
        }

        float distance = speed * Time.deltaTime;

        transform.Translate(direction * distance);
	}

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Pickup")
        {
            score += 3;

            ScoreText.text = score.ToString();
            DeltaScoreTextManager.Instance.CreateText(transform.position);

            other.gameObject.SetActive(false);
            Instantiate(ps, transform.position, Quaternion.identity);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (!isDead)
        {
            if (other.tag == "Tile")
            {
                RaycastHit hit;

                Ray rayDown = new Ray(transform.position, Vector3.down);

                if (!Physics.Raycast(rayDown, out hit))
                {
                    isDead = true;
                    transform.GetChild(0).transform.parent = null;
                    restartButton.SetActive(true);
                }
            }
        }
    }
}
