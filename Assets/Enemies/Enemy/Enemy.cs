using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int movingTo = 0;
    private Transform[] wps;
    public float moveSpeed = 5f;
    public GameObject deathEffect;
    public int startHealth;
    public int killValue;
    
    public float health;

    private void Start()
    {
        wps = Waypoints.Points;
        health = startHealth;
    }

    // Update is called once per frame
    void Update()
    {
        var targetPos = wps[movingTo].position;
        targetPos.y = transform.position.y;
        
        var towardsTragetWP = targetPos - transform.position;
        if (towardsTragetWP.magnitude <= 0.1f)
        {
            movingTo++;
            if (movingTo >= wps.Length)
            {
                Destroy(gameObject);
                return;
            }            
        }
        else
        {
            transform.LookAt(targetPos);
            var move = transform.forward.normalized * moveSpeed * Time.deltaTime;
            move.y = 0;
            transform.Translate(move,Space.World);
        }
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health > 0)
            return;

        PlayerStats.instance.energy += killValue;
        
        Destroy(Instantiate(deathEffect, transform.position, Quaternion.identity), 5f);
        Destroy(gameObject);
    }
}
