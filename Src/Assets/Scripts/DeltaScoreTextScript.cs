using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DeltaScoreTextScript : MonoBehaviour {

    private float speed;
    private Vector3 direction;
    private float fadeOutTime;

    public void Initialize(Vector3 direction, float speed, float fadeTime) {
        this.direction = direction;
        this.speed = speed;
        this.fadeOutTime = fadeTime;

        StartCoroutine(FadeOut());
    } 
	
	void Update () {
        float translation = speed * Time.deltaTime;
        transform.Translate(direction * translation);	
	}

    private IEnumerator FadeOut() {
        float startAlpha = GetComponent<Text>().color.a;
        float rate = 1.0f / fadeOutTime;
        float progress = 0.0f;

        while(progress < 1.0) {
            Color tempColor = GetComponent<Text>().color;

            GetComponent<Text>().color = new Color(tempColor.r, tempColor.g, tempColor.b, Mathf.Lerp(startAlpha, 0, progress));
            progress += rate * Time.deltaTime;

            yield return null;   
        }

        Destroy(gameObject);
    }
}
