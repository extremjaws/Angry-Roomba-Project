using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class Shotgun : MonoBehaviour
{
    private Animator animator;
    private float timer;
    public float cooldown;
    public int ammo = 12;
    public TMP_Text ammoCounter;
    public AudioSource fireSound;
    public AudioSource DryMagSound;
    public AudioSource Pump;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        timer = cooldown;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && timer >= cooldown)
        {
            fire();
        }
        else if (timer < cooldown)
        {
            timer += Time.deltaTime;
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
            fireSound.Play();
            await Task.Delay(800);
            Pump.Play();
        } else
        {
            timer = 1;
            DryMagSound.Play();
        }
    }
}
