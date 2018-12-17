using UnityEngine;

public class Turret : MonoBehaviour
{
    public Transform head;
    private Enemy target;

    public Transform shotOrigin;
    public Bullet bulletPrefab;
    public float fireRate = 1f;
    public float nextShot;
    public float range = 3f;
    public float rotateSpeed = 15f;
    public LayerMask canHit;
    public GameObject badgePanel;
       
    // Update is called once per frame
    void Update()
    {
        Lock();
        Shoot();
    }

    void Shoot()
    {
        if (target == null || Time.time < nextShot)
            return;

        bulletPrefab.target = target;
        Instantiate(bulletPrefab, shotOrigin.position, shotOrigin.rotation);
        nextShot = Time.time + (1f / fireRate);
    }

    void Lock()
    {
        if (target != null)
        {
            var currentTargetDistance = (target.transform.position - transform.position).magnitude;    
            if (currentTargetDistance > range)
            {
                target = null;
            }
        }        
        
        if (target == null)
        {
            var targets = Physics.OverlapSphere(transform.position, range, canHit);
            if (targets.Length > 0)
            {
                target = targets[0].GetComponent<Enemy>();
            }

        }
        if(target != null)
        {
            var targetDir = target.transform.position - transform.position;
            var rot = Quaternion.Lerp(head.rotation, Quaternion.LookRotation(targetDir), rotateSpeed * Time.deltaTime);
            rot.x = 0;
            rot.z = 0;
            head.rotation = rot;
        }        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Enemy") || target != null)
            return;

        target = other.GetComponent<Enemy>();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform == target)
        {
            target = null;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    public void AddBadge(GameObject badge)
    {
        Instantiate(badge, badgePanel.transform);
    }
}
