using UnityEngine;
using System.Collections;

public class DeltaScoreTextManager : MonoBehaviour {

    public GameObject textPrefab;

    public RectTransform canvasTransform;

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

    public void CreateText(Vector3 position)
    {
        GameObject text = Instantiate(textPrefab);
        text.transform.SetParent(canvasTransform);
        text.transform.position = position;
        text.transform.localScale = new Vector3(1, 1, 1);
    }
}
