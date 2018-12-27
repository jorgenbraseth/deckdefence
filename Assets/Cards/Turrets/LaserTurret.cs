using Cards.Turrets;
using UnityEngine;

public class LaserTurret : MonoBehaviour, ITurret
{
    public Transform head;
    private Enemy target;

    public Transform shotOrigin;
    public float range = 3f;
    public float rotateSpeed = 15f;
    public float dps = 1;
    public LayerMask canHit;
    public GameObject badgePanel;
    public LineRenderer laserBeam;
    public GameObject hitEffect;
       
    // Update is called once per frame
    void Update()
    {
        Lock();
        MoveLaser();
        Shoot();
    }

    private void MoveLaser()
    {
        laserBeam.gameObject.SetActive(target != null);
        hitEffect.gameObject.SetActive(target != null);
        
        if (target == null)
            return;
        
        
        laserBeam.SetPosition(0, shotOrigin.position);
        laserBeam.SetPosition(1, target.transform.position);

        var direction =  shotOrigin.position - target.transform.position;
        RaycastHit hit;
        if (Physics.Raycast(shotOrigin.position, -direction, out hit, range, canHit))
        {
            hitEffect.transform.position = hit.point;
        }
        hitEffect.transform.rotation = Quaternion.LookRotation(direction);
    }

    void Shoot()
    {
        if (target == null)
            return;
        
        target.TakeDamage(dps * Time.deltaTime);
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
            var targetDir = target.transform.position - head.position;
            var rot = Quaternion.Lerp(head.rotation, Quaternion.LookRotation(targetDir), rotateSpeed * Time.deltaTime);
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
