using UnityEngine;

public class Basketball : MonoBehaviour
{

    [SerializeField]
    private AudioSource bounceSound;

    private void OnCollisionEnter(Collision collision)
    {
        bounceSound.Play();
    }
}
