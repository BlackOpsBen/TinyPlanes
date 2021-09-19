using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Pools))]
public class Arsenal : MonoBehaviour
{
    [SerializeField] private Transform muzzle;

    [SerializeField] private Rigidbody2D unitRigidBody;

    [SerializeField] private List<Weapon> weapons = new List<Weapon>(); // TODO automatically load weapons from resources

    private Pools pools;

    private Transform projectileParent;

    private float timer = 0f;

    private bool isShooting = false;

    private int currentWeapon = 0;

    [SerializeField] private bool debugAlwaysShoot = false;
    [SerializeField] private bool debugNeverShoot = false;

    private void Awake()
    {
        pools = GetComponent<Pools>();
        projectileParent = GameObject.FindGameObjectWithTag("Projectiles").transform;
    }

    private void Start()
    {
        List<GameObject> weaponProjectilePrefabs = new List<GameObject>();
        foreach (var weapon in weapons)
        {
            weaponProjectilePrefabs.Add(weapon.GetProjectile());
        }
        pools.Init(weapons.Count, weaponProjectilePrefabs);
    }

    private void FixedUpdate()
    {
        if (debugAlwaysShoot)
        {
            isShooting = true;
        }

        if (debugNeverShoot)
        {
            return;
        }

        timer += Time.deltaTime;

        float fireThreshold = 1f / weapons[currentWeapon].GetPerSecondRate();

        if (isShooting && timer >= fireThreshold)
        {
            timer = 0f;

            FireCurrentWeapon();
        }
    }

    public void FireCurrentWeapon()
    {
        GameObject firedProjectile = pools.GetNextInPool(currentWeapon);

        Rigidbody2D rb = firedProjectile.GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.zero;
        rb.MovePosition(muzzle.position);
        rb.SetRotation(muzzle.rotation);

        //firedProjectile.GetComponent<Projectile>().ToggleActive(true);
        firedProjectile.GetComponent<Projectile>().BeginProjectile(muzzle.position);

        //Rigidbody2D parentRb = muzzle.GetComponentInParent<Rigidbody2D>();
        rb.velocity = unitRigidBody.velocity;
        //rb.AddRelativeForce(Vector2.up * weapons[currentWeapon].GetSpeed(), ForceMode2D.Impulse);
        rb.velocity += (Vector2)muzzle.up * weapons[currentWeapon].GetProjectile().GetComponent<Projectile>().GetSpeed();

        AudioManager.Instance.PlaySoundGroup(1); // TODO refactor sounds
    }

    public void OnShoot(bool performed, bool canceled)
    {
        if (performed)
        {
            isShooting = true;
        }
        else if (canceled)
        {
            isShooting = false;
        }
    }

    public void SetIsShooting(bool value)
    {
        isShooting = value;
    }

    //// Called by PlayerInput Unity Event
    //public void OnNextWeapon()
    //{
    //    currentWeapon++;
    //    currentWeapon %= weapons.Count;
    //}

    //// Called by PlayerInput Unity Event
    //public void OnPrevWeapon()
    //{
    //    currentWeapon--;
    //    currentWeapon += weapons.Count;
    //    currentWeapon %= weapons.Count;
    //}

    // Called by PlayerInput Unity Event
    //public void OnCycleWeapons(InputAction.CallbackContext context)
    //{
    //    if (context.performed)
    //    {
    //        int direction = (int)context.ReadValue<float>();
    //        currentWeapon += direction;
    //        currentWeapon += weapons.Count;
    //        currentWeapon %= weapons.Count;
    //    }
    //}

    public Weapon GetCurrentWeapon()
    {
        return weapons[currentWeapon];
    }
}
