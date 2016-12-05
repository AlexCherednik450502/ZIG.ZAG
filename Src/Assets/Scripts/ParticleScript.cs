using UnityEngine;

public class ParticleScript : MonoBehaviour
{

    private ParticleSystem ps;
    
    void Start()
    {
        ps = GetComponent<ParticleSystem>();
    }
    
    void Update()
    {
        if (!ps.isPlaying)
        {
            Destroy(gameObject);
        }
    }
}
