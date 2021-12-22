using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanScript : MonoBehaviour
{
    public GameObject bottleCap;
    public GameObject capPos;
    public int forceForBottleCap = 5;
    public int forceForBottle = 5;
    public GameObject bubbleParticlesRight;
    public GameObject bubbleParticlesLeft;
    public Animator animator;
    public AudioSource canOpenSound;
    public enum BottleDirections { Left, Right};
    public BottleDirections bottleDirections;


    Rigidbody2D rb_bottle;
    Vector2 mousePos;
    bool oneTimeOnly;

    private void Awake()
    {
        rb_bottle = GetComponent<Rigidbody2D>();
    }

    private void OnMouseDown()
    {
        Rigidbody2D rb = bottleCap.AddComponent<Rigidbody2D>();
       

        if (!oneTimeOnly)
        {
            canOpenSound.Play();

            switch (bottleDirections)
            {   
                case BottleDirections.Left:
                    {
                        rb.AddForce(capPos.transform.right * forceForBottleCap, ForceMode2D.Impulse);
                        rb_bottle.AddForce(Vector2.left * forceForBottle, ForceMode2D.Force);
                        GameObject particle = Instantiate(bubbleParticlesLeft, new Vector2(this.transform.position.x - 0.2f, this.transform.position.y + .68f), bubbleParticlesLeft.transform.rotation);
                        animator.SetInteger("BottlePop", 1);
                        particle.transform.parent = capPos.transform;
                        //particle.transform.position = capPos.transform.position;
                        particle.transform.localScale = Vector3.one;
                        break;
                    }
                case BottleDirections.Right:
                    {
                        rb.AddForce(-capPos.transform.right * forceForBottleCap, ForceMode2D.Impulse);
                        rb_bottle.AddForce(Vector2.right * forceForBottle, ForceMode2D.Force);
                        GameObject particle = Instantiate(bubbleParticlesRight, new Vector2(this.transform.position.x + 0.2f, this.transform.position.y + .68f), bubbleParticlesRight.transform.rotation);                        
                        animator.SetInteger("BottlePop", 1);
                        particle.transform.parent = capPos.transform;
                        //particle.transform.position = capPos.transform.position;
                        particle.transform.localScale = Vector3.one;
                        break;
                    }
            }
            oneTimeOnly = true;
        }
    }
}
