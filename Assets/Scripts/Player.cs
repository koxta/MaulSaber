using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("enemy"))
        {
            GameManager.Instance.GameOverScreen.Show();
            GetComponent<RotationController>().enable = false;
            StartCoroutine(Die());
        }
    }

    public IEnumerator Die()
    {
        Camera.main.GetComponent<Shaker>().TriggerShake();
        Time.timeScale = 0.5f;
        yield return new WaitForSeconds(0.3f);
        Time.timeScale = 0;
    }
}
