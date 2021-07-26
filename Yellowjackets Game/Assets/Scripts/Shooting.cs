using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour {
    public Rigidbody bullet;
    public Rigidbody bomb;
    public Rigidbody missile;
    public Rigidbody shuriken;
    public Rigidbody cannonVolley;
    public Rigidbody cannonBall;
    public GameObject railgunBurst;
    public Rigidbody[] spellingBurst;
    public bool canFire = true;
    public GameObject swordObj;
    //public GameObject glow;
    //public Material glowMat;
    public Rigidbody cloud;
    public GameObject zap;

    public float AttackDamageMod = 1;
    public float charge;

    public float railDmg;
    public float chargePower;
    public Health health;

    public float AttackSpeedCalc;
    public float AttackSpeedBase;
    public float AttackSpeedModifier = 0;
    private float elapsedTime = 0;

    public float projectileSize = 0.2f;

    public Inventory inventory;
    public PlayerController playerController;

    // Initalise
    void Start() {
        playerController = GetComponent<PlayerController>();
        inventory = GetComponent<Inventory>();
        //glow = GameObject.FindWithTag("Glow");
        //glowMat = glow.GetComponent<Renderer>().material;
    }

    // Update
    void Update() {
        AttackSpeedCalc = AttackSpeedBase / (1 + (AttackSpeedModifier / 100));

        if (Input.GetButton("Fire1") && !playerController.isCursorFree) {
            charge += Time.deltaTime * (1 / AttackSpeedCalc);

            if (inventory.weapon == "default") {
                AttackSpeedBase = .5f;
                StandardShoot(bullet, 100);

            } else if (inventory.weapon == "bomb") {
                AttackSpeedBase = 2f;
                StandardShoot(bomb, 25);

            } else if (inventory.weapon == "missile") {
                AttackSpeedBase = 2f;
                StandardShoot(missile, 25);

            } else if (inventory.weapon == "shuriken") {
                AttackSpeedBase = .4f;
                StandardShoot(shuriken, 100);

            } else if (inventory.weapon == "spelling bee" && canFire) {
                canFire = false;
                AttackSpeedBase = 2f;
                StartCoroutine(ShootSpellingBee());

            } else if (inventory.weapon == "sword") {
                AttackSpeedBase = .75f;
                AttackSword();

            } else {
                AttackSpeedBase = 1f;

            }
        }

        // If the player has charaged a weapon and released the fire button
        if (charge > 0 && !Input.GetButton("Fire1")) {
            if (inventory.weapon == "pirate") {
                ShootPirate();
            }
            if (inventory.weapon == "railgun") {
                ShootRailgun();
                //glowMat.SetFloat("Power", 0f);
            }

            charge = 0;
        }

        /*
        if (inventory.weapon == "railgun") {
            glowMat.SetFloat("Power", charge*0.2f);
        }
        */
    }

    // Shoot methods
    private void ShootPirate() {
        if (charge >= 0.5f && charge < 1.5f) {
            Rigidbody LeftVolley = (Rigidbody)Instantiate(cannonVolley, transform.position, transform.rotation);
            LeftVolley.velocity = transform.right * -70;
            LeftVolley.transform.localScale = new Vector3(projectileSize, projectileSize, projectileSize);

            Rigidbody RightVolley = (Rigidbody)Instantiate(cannonVolley, transform.position, transform.rotation);
            RightVolley.velocity = transform.right * 70;
            RightVolley.transform.localScale = new Vector3(projectileSize, projectileSize, projectileSize);
        
        } else if (charge >= 1.5) {
            Rigidbody bulletClone = (Rigidbody)Instantiate(cannonBall, transform.position, transform.rotation);
            bulletClone.velocity = transform.forward * 30;
            bulletClone.transform.localScale = new Vector3(projectileSize * 5, projectileSize * 5, projectileSize * 5);
        
        }
    }

    private void ShootRailgun() {

        if (charge >= 0.5f) {


            Instantiate(railgunBurst, transform.position, transform.rotation);
            RaycastHit hit;
            int layerMask = 1 << 8;
            if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity, layerMask)) {

                if (hit.collider.GetComponent<Health>() != null) {
                    health = hit.collider.GetComponent<Health>();
                    railDmg = Mathf.Round(Mathf.Abs(hit.distance * charge));
                    if (charge >= 2.5) {
                        railDmg = 50 + Mathf.Round(Mathf.Abs(hit.distance * charge) * AttackDamageMod);
                    }

                    health.OnDamage(railDmg);
                }


            }
        }
    }

    private IEnumerator ShootSpellingBee() {

        if (Time.time > elapsedTime) {
            for (int i = 0; i < 4; i++) {
                Rigidbody bulletClone = (Rigidbody)Instantiate(spellingBurst[i], transform.position, transform.rotation);
                bulletClone.velocity = transform.forward * 100;
                bulletClone.transform.localScale = new Vector3(projectileSize, projectileSize, projectileSize);

                yield return new WaitForSeconds(.1f);
            }


            elapsedTime = Time.time + AttackSpeedCalc;

        }
        canFire = true;
    }

    private void AttackSword() {
        if (Time.time > elapsedTime) {
            //swordObj.GetComponent<Animator>().animation("Swordswing").wrapMode = WrapMode.Once;

            swordObj.GetComponent<Animator>().Play("Base Layer.Swordswing", 0, 0);

            elapsedTime = Time.time + AttackSpeedCalc;
        }
    }

    // Utility methods
    private void StandardShoot(Rigidbody bulletPrefab, float speed) {
        if (Time.time > elapsedTime) {
            Rigidbody bulletClone = (Rigidbody)Instantiate(bulletPrefab, transform.position, transform.rotation);
            bulletClone.velocity = transform.forward * speed;
            bulletClone.transform.localScale = new Vector3(projectileSize, projectileSize, projectileSize);
            elapsedTime = Time.time + AttackSpeedCalc;
        }
    }

}