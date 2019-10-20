using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Enemy : MonoBehaviour
{
    public Colors color;
    public int Lives = 1;
    public float StrengthOfAttraction = 1f;

    private GameObject attractedTo;
    private Rigidbody2D rigidBody;
    private bool attract;

    public UnityEngine.UI.Text liveText;

    private void Start()
    {
        attractedTo = GameManager.Instance.player;
        rigidBody = GetComponent<Rigidbody2D>();
        attract = true;
        if (Lives > 1)
        {
            liveText.text = Lives.ToString();
        }
    }

    private void FixedUpdate()
    {
        Vector2 direction = attractedTo.transform.position - transform.position;

        if (attract)
        {
            rigidBody.AddForce(StrengthOfAttraction * direction);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag.Equals("stick"))
        {
            if (collision.gameObject.GetComponent<Stick>().color.Equals(color))
            {
                if (--Lives <= 0)
                {
                    StartCoroutine(Die());
                    GameManager.Instance.activeEnemyCounter--;
                    GameManager.Instance.killedEnemies++;
                }
                else
                {
                    liveText.text = Lives.ToString();
                    StartCoroutine(StopAttraction(UnityEngine.Random.Range(2, 3)));
                }
                
            }
            else
            {
                //Debug.Log("Game over");
            }

        }
    }

    private IEnumerator Die()
    {
        Camera.main.GetComponent<Shaker>().TriggerShake();
        attract = false;
        GetComponent<CapsuleCollider2D>().enabled = false;
        GetComponent<Animator>().SetBool("die", true);
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }

    private IEnumerator StopAttraction(float seconds)
    {
        attract = false;
        yield return new WaitForSeconds(seconds);
        attract = true;
    }


}
