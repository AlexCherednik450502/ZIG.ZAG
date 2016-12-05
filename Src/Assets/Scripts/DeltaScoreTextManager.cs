using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DeltaScoreTextManager : MonoBehaviour {

    public GameObject textPrefab;

    public RectTransform canvasTransform;

    public RectTransform deltaScoreAttachPointTransform;

    public Vector3 direction;

    public float speed;

    public float fadeOutTime;

    private static DeltaScoreTextManager instance;

    public static DeltaScoreTextManager Instance
    {
        get
        {
            if(instance == null)
            {
                instance = GameObject.FindObjectOfType<DeltaScoreTextManager>();
            }
            return instance;
        }
    }

    public void CreateText(string text)
    {
        GameObject dst = Instantiate(textPrefab);
        dst.transform.SetParent(canvasTransform);
        dst.transform.localScale = new Vector3(1, 1, 1);
        dst.GetComponent<RectTransform>().transform.position = deltaScoreAttachPointTransform.transform.position;
        dst.GetComponent<DeltaScoreTextScript>().Initialize(direction, speed, fadeOutTime);
        dst.GetComponent<Text>().text = text;
    }
}
