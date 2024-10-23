using System.Collections;
using UnityEngine;

public class ShootingController : MonoBehaviour
{
    [SerializeField] private Transform weaponPivot;

    private void Start()
    {
        StartCoroutine(Shoot());
    }

    IEnumerator Shoot()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            GameObject projectile = GameManager.Instance.pool.Get("Bullet");
            projectile.transform.position = weaponPivot.position;
        }
    }
}