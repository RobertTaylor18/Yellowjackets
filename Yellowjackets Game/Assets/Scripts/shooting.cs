using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour
{
    public float bulletSpeed = 10;
   

    public float bulletSpeed2 = 10;
    
    
    public Rigidbody bullet;
    public Rigidbody bullet2;
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

    public float AttackDamageMod=1;
    public float charge;

    public float railDmg;
    public float chargePower;
    public Health health;

    public float AttackSpeed;
    public float AttackSpeedBase;
    public float AttackSpeedMod = 0;
    private float elapsedTime = 0;

    public float projectileSize;

    public Inventory inventory;
    public Fly fly;

    void Start()
    {
        projectileSize = 0.2f;
        //glow = GameObject.FindWithTag("Glow");
        //glowMat = glow.GetComponent<Renderer>().material;
        fly = GetComponent<Fly>();
        inventory = GetComponent<Inventory>();
    }

    void defaultWeapon()
    {
        if (Time.time > elapsedTime)
        {
            Rigidbody bulletClone = (Rigidbody)Instantiate(bullet, transform.position, transform.rotation);
            bulletClone.velocity = transform.forward * 100;
            bulletClone.transform.localScale = new Vector3(projectileSize, projectileSize, projectileSize);
            elapsedTime = Time.time + AttackSpeed;
        }
    }

    void bombs()
    {
        if (Time.time > elapsedTime)
        {
            Rigidbody bulletClone = (Rigidbody)Instantiate(bullet2, transform.position, transform.rotation);
            bulletClone.velocity = transform.forward * 25;
            bulletClone.transform.localScale = new Vector3(projectileSize, projectileSize, projectileSize);
            elapsedTime = Time.time + AttackSpeed;
        }
    }
    
    void missiles()
    {
        if (Time.time > elapsedTime)
        {
            Rigidbody bulletClone = (Rigidbody)Instantiate(missile, transform.position, transform.rotation);
            bulletClone.velocity = transform.forward * 25;
            bulletClone.transform.localScale = new Vector3(projectileSize, projectileSize, projectileSize);
            elapsedTime = Time.time + AttackSpeed;
        }
    }

    void shurikens()
    {
        if (Time.time > elapsedTime)
        {
            Rigidbody bulletClone = (Rigidbody)Instantiate(shuriken, transform.position, transform.rotation);
            bulletClone.velocity = transform.forward * 100;
            bulletClone.transform.localScale = new Vector3(projectileSize, projectileSize, projectileSize);
            elapsedTime = Time.time + AttackSpeed;
        }
    }
    
    void pirate()
    {
        if (charge >= 0.5f && charge < 1.5f)
        {
            Rigidbody LeftVolley = (Rigidbody)Instantiate(cannonVolley, transform.position, transform.rotation);
            LeftVolley.velocity = transform.right * -70;
            LeftVolley.transform.localScale = new Vector3(projectileSize, projectileSize, projectileSize);

            Rigidbody RightVolley = (Rigidbody)Instantiate(cannonVolley, transform.position, transform.rotation);
            RightVolley.velocity = transform.right * 70;
            RightVolley.transform.localScale = new Vector3(projectileSize, projectileSize, projectileSize);
        }
        else if (charge >= 1.5)
        {
            Rigidbody bulletClone = (Rigidbody)Instantiate(cannonBall, transform.position, transform.rotation);
            bulletClone.velocity = transform.forward * 30;
            bulletClone.transform.localScale = new Vector3(projectileSize*5, projectileSize*5, projectileSize*5);
        }
    }
    
    void railgun()
    {
        
        if (charge >= 0.5f)
        {
            
            
            Instantiate(railgunBurst, transform.position, transform.rotation);
            RaycastHit hit;
            int layerMask = 1 << 8;
            if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity, layerMask))
            {
                
                if(hit.collider.GetComponent<Health>() != null)
                {
                    health = hit.collider.GetComponent<Health>();
                    railDmg = Mathf.Round(Mathf.Abs(hit.distance*charge));
                    if (charge >= 2.5 ) 
                    {
                        railDmg = 50 + Mathf.Round(Mathf.Abs(hit.distance * charge)* AttackDamageMod);
                    }

                    health.OnDamage(railDmg);
                }

                
            }
        }
    }

    public IEnumerator spellingBee()
    {
        
        if (Time.time > elapsedTime)
        {
            for (int i = 0; i < 4; i++)
            {
                Rigidbody bulletClone = (Rigidbody)Instantiate(spellingBurst[i], transform.position, transform.rotation);
                bulletClone.velocity = transform.forward * 100;
                bulletClone.transform.localScale = new Vector3(projectileSize, projectileSize, projectileSize);

                yield return new WaitForSeconds(.1f);
            }


            elapsedTime = Time.time + AttackSpeed;
            
        }
        canFire = true;
    }

    void sword()
    {
        if (Time.time > elapsedTime)
        {
            //swordObj.GetComponent<Animator>().animation("Swordswing").wrapMode = WrapMode.Once;
            
            swordObj.GetComponent<Animator>().Play("Base Layer.Swordswing", 0, 0);

            elapsedTime = Time.time + AttackSpeed;
        }
    }


    void Update()
    {
        AttackSpeed = AttackSpeedBase / (1 + (AttackSpeedMod / 100));
        
        
        if (Input.GetButton("Fire1") && fly.tab == false)
        {
            charge += Time.deltaTime * (1/AttackSpeed);
            
            if (inventory.weapon == "default")
            {
                AttackSpeedBase = .5f;
                defaultWeapon();
            }
            else if (inventory.weapon == "bomb")
            {
                AttackSpeedBase = 2f;
                bombs();
            }
            else if (inventory.weapon == "missile")
            {
                AttackSpeedBase = 2f;
                missiles();
            }
            else if (inventory.weapon == "shuriken")
            {
                AttackSpeedBase = .4f;
                shurikens();
            }
            else if (inventory.weapon == "spelling bee" && canFire)
            {
                AttackSpeedBase = 2f;
                canFire = false;
                StartCoroutine(spellingBee());
            }
            else if (inventory.weapon == "sword")
            {
                AttackSpeedBase = .75f;
                sword();
            }
            else
            {
                AttackSpeedBase = 1f;
            }
        }

        /*if (inventory.weapon == "railgun")
        {
            glowMat.SetFloat("Power", charge*0.2f);
        }*/

        if (!Input.GetButton("Fire1") && charge != 0)
        {
            if (inventory.weapon == "pirate")
            {
                pirate();
            }
            if (inventory.weapon == "railgun")
            {
                railgun(); 
                //glowMat.SetFloat("Power", 0f);
            }

            charge = 0;
        }
        

        
    }
}