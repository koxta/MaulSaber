using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stick : MonoBehaviour
{
    public Colors color;

    private void OnCollisionEnter2D(Collision2D collision)
    {
            GameManager.Instance.CheckActiveEnemies();

        if(collision.gameObject.GetComponent<Enemy>().color != this.color)
        {
            GameManager.Instance.Die();
        }

    }

}
