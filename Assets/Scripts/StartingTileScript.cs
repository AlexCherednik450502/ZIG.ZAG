using UnityEngine;
using System.Collections;

public class StartingTileScript : MonoBehaviour {

    private readonly static float fallDelay = 0.8f;

    private readonly static float fallDuration = 2.5f;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            TileManager.Instance.SpawnTile();
            StartCoroutine(FallDown());
        }
    }

    IEnumerator FallDown()
    {
        yield return new WaitForSeconds(fallDelay);
        GetComponent<Rigidbody>().isKinematic = false;
        yield return new WaitForSeconds(fallDuration);
        gameObject.SetActive(false);
        Destroy(gameObject);
    }
}
