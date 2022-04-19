using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine.AI;
using UnityEngine;

public class Shotgun : MonoBehaviour
{
    public LayerMask layerMask;
    public GameObject raycastStart;
    public float range;
    public int pellots;
    public float spread;

    private Animator animator;
    private float timer;
    private bool reloading = false;
    public float cooldown;
    public int ammo = 12;
    public TMP_Text ammoCounter;
    public AudioSource fireSound;
    public AudioSource DryMagSound;
    public AudioSource Pump;
    public AudioSource reloadSound;
    public ParticleSystem muzzleFlash;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        timer = cooldown;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && timer >= cooldown && reloading == false)
        {
            fire();
        }
        else if (timer < cooldown)
        {
            timer += Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            reload();
        }
    }
    async void fire()
    {
        if (ammo > 0)
        {
            timer = 0;
            ammo--;
            ammoCounter.text = ammo.ToString() + "/12";
            animator.SetTrigger("Fire");
            muzzleFlash.Play();
            fireSound.Play();
            for (int i = 0; i < pellots; i++)
            {
                RaycastHit hit;
                float rot = Random.Range(0, 360);
                if (Physics.Raycast(raycastStart.transform.position, raycastStart.transform.TransformDirection(Vector3.forward + new Vector3(Mathf.Cos(rot) * Random.Range(-spread, spread), Mathf.Sin(rot) * Random.Range(-spread, spread), 0)), out hit, range, layerMask))
                {
                    Debug.DrawLine(raycastStart.transform.position, hit.point, Color.green, 5);
                    if (hit.collider.tag == "Respawn")
                    {
                        bulletHit(5, hit);
                    }
                }
            }
            await Task.Delay(800);
            Pump.Play();
        } else {
            timer = 1;
            DryMagSound.Play();
        }
    }
    async void reload()
    {
        if (reloading == false)
        {
            reloading = true;
            animator.SetBool("Reloading", true);
            while (ammo < 12)
            {
                await Task.Delay(50);
                reloadSound.Play();
                ammo++;
                ammoCounter.text = ammo.ToString() + "/12";
                await Task.Delay(450);
            }
            animator.SetBool("Reloading", false);
            reloading = false;
        }
    }
    async void bulletHit(int time, RaycastHit hit)
    {
        await Task.Delay(time);
        hit.collider.GetComponent<controller>().enabled = false;
        hit.collider.GetComponent<NavMeshAgent>().enabled = false;
        hit.collider.GetComponent<AudioSource>().mute = true;
        hit.collider.GetComponentInChildren<Light>().enabled = false;
        hit.collider.gameObject.tag = "Untagged";
        doorManager[] doors = FindObjectsOfType<doorManager>();
        foreach (doorManager door in doors)
        {
            door.roombaCriteria -= 1;
        }
        FindObjectOfType<ModManager>().RoombaKilledEvent();
    }
}
