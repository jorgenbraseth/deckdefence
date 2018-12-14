using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Enemy target;
    public float moveSpeed = 30f;
    public int damage;
   
    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }
        var distanceToMove = moveSpeed * Time.deltaTime;
        var diff = target.transform.position - transform.position;
        if (diff.magnitude <= distanceToMove)
        {
            Hit();            
            return;
        }
        
        transform.LookAt(target.transform.position);
        var move = Vector3.forward.normalized * distanceToMove;
        move.y = 0f;
        transform.Translate(move);
    }

    void Hit()
    {
        target.TakeDamage(damage);
        Destroy(gameObject);
    }
}
