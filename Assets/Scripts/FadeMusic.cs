using UnityEngine;

public class Music3DFade : MonoBehaviour
{
    public Transform player;
    public float minDistance = 5f;
    public float maxDistance = 30f;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (player != null && audioSource != null)
        {

            float distance = Vector3.Distance(player.position, transform.position);


            if (distance < minDistance)
            {
                audioSource.volume = 1f;
            }
            else if (distance > maxDistance)
            {
                audioSource.volume = 0f;
            }
            else
            {

                float volume = 1f - (distance - minDistance) / (maxDistance - minDistance);
                audioSource.volume = Mathf.Clamp01(volume);
            }
        }
    }
}