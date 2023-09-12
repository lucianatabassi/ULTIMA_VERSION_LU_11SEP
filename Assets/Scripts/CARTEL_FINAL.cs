using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CARTEL_FINAL : MonoBehaviour
{
    private PAJARO scriptPajaro;
    private MOHO_ELIMINAR scriptPez;
    private InteraccionCarpincho scriptCarpincho;

    public GameObject cartel;

    public AudioClip musicaFinal;
    public AudioSource audioSource;


    void Start()
    {
        scriptPajaro = FindObjectOfType<PAJARO>();
        scriptPez = FindObjectOfType<MOHO_ELIMINAR>();
        scriptCarpincho = FindObjectOfType<InteraccionCarpincho>();
        cartel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (scriptPajaro.pajaroCompletado && scriptPez.pezCompletado && scriptCarpincho.carpinchoCompletado)
        {
            cartel.SetActive(true);
            audioSource.PlayOneShot(musicaFinal);
        }
    }
}
