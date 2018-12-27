using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public Image bar;
    public Enemy enemy;

    void Update()
    {
        bar.fillAmount = 1f*enemy.health / enemy.startHealth;
    }
}
