using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleScript : MonoBehaviour
{
    
    public GameObject bottleCap;
    public GameObject capPos;
    public int forceForBottleCap = 5;
    public int forceForBottle = 5;    
    public GameObject bubbleParticlesUp;
    public GameObject bubbleParticlesDown;
    public GameObject bubbleParticlesRight;
    public GameObject bubbleParticlesLeft;
    public GameObject burstEffect1;
    public GameObject burstEffect2;
    public GameObject burstEffect3;
    public GameObject colorBurstEffect;
    public Animator animator;
    public AudioSource capOpenSound;
    public enum BottleDirections { Up, Down, Left, Right};
    public BottleDirections bottleDirections;


    Rigidbody2D rb_bottle;
    Vector2 mousePos;
    bool oneTimeOnly;
    int bottleDestroyCounter;

    private void Awake()
    {
        rb_bottle = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(bottleDestroyCounter >= 3)
        {
            bottleCap.transform.parent = null;
            Destroy(gameObject);
            Instantiate(burstEffect1, this.transform.position, burstEffect1.transform.rotation);
            Instantiate(burstEffect2, this.transform.position, burstEffect2.transform.rotation);
            Instantiate(burstEffect3, this.transform.position, burstEffect3.transform.rotation);
            Instantiate(colorBurstEffect, this.transform.position, colorBurstEffect.transform.rotation);
        }
    }

    private void OnMouseDown()
    {
        Rigidbody2D rb = bottleCap.AddComponent<Rigidbody2D>();
        bottleDestroyCounter += 1;
        if (!oneTimeOnly)
        {
            capOpenSound.Play();

            switch (bottleDirections)
            {
                case BottleDirections.Up:
                    {
                        rb.AddForce(capPos.transform.up * forceForBottleCap, ForceMode2D.Impulse);
                        rb_bottle.AddForce(new Vector2(-1, 0) * forceForBottle, ForceMode2D.Force);
                        animator.SetInteger("BottlePop", 1);
                        GameObject particle = Instantiate(bubbleParticlesUp, new Vector2(this.transform.position.x, this.transform.position.y + 1f), bubbleParticlesUp.transform.rotation);
                        particle.transform.parent = capPos.transform;
                        //particle.transform.position = capPos.transform.position;
                        particle.transform.localScale = Vector3.one;
                        break;
                    }

                case BottleDirections.Down:
                    {
                        rb.AddForce(capPos.transform.up * forceForBottleCap, ForceMode2D.Impulse);
                        rb_bottle.AddForce(new Vector2(-1, 0) * forceForBottle, ForceMode2D.Force);
                        animator.SetInteger("BottlePop", 4);
                        GameObject particle = Instantiate(bubbleParticlesDown, new Vector2(this.transform.position.x, this.transform.position.y - 1f), bubbleParticlesDown.transform.rotation);
                        particle.transform.parent = capPos.transform;
                        //particle.transform.position = capPos.transform.position;
                        particle.transform.localScale = Vector3.one;
                        break;
                    }

                case BottleDirections.Left:
                    {
                        rb.AddForce(-capPos.transform.up * forceForBottleCap, ForceMode2D.Impulse);
                        rb_bottle.AddForce(Vector2.right * forceForBottle, ForceMode2D.Force);
                        GameObject particle = Instantiate(bubbleParticlesLeft, new Vector2(this.transform.position.x - 1f, this.transform.position.y), bubbleParticlesLeft.transform.rotation);
                        animator.SetInteger("BottlePop", 2);
                        particle.transform.parent = capPos.transform;
                        //particle.transform.position = capPos.transform.position;
                        particle.transform.localScale = Vector3.one;
                        break;
                    }
                case BottleDirections.Right:
                    {
                        rb.AddForce(capPos.transform.up * forceForBottleCap, ForceMode2D.Impulse);
                        rb_bottle.AddForce(Vector2.left * forceForBottle, ForceMode2D.Force);
                        GameObject particle = Instantiate(bubbleParticlesRight, new Vector2(this.transform.position.x + 1f, this.transform.position.y), bubbleParticlesRight.transform.rotation);                        
                        animator.SetInteger("BottlePop", 3);
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
