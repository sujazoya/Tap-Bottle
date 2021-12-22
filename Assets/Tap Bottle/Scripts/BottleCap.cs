using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleCap : MonoBehaviour
{

    public GameObject starAnimationPrefab;
    public AudioSource pickUpStar;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Star"))
        {
            GameManager.instance.starsCollect += 1;
            Instantiate(starAnimationPrefab, other.gameObject.transform.position, starAnimationPrefab.transform.rotation);
            Destroy(other.gameObject);
            pickUpStar.Play();
        }

        if (other.gameObject.CompareTag("Destroyer"))
        {
            Destroy(gameObject);
            GameManager.instance.bottleCapsDestroied += 1;
        }
    }
}
