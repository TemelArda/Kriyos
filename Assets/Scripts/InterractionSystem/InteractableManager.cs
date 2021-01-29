using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InteractableManager : MonoBehaviour
{
    [SerializeField] private List<Interactable> interactables;
    private GameObject player;
    private PlayerBasitState p;
    public KeyCode interractButton = KeyCode.F;
    public Text interractionText;
    public bool enableMultiThreading = false;
    public void Start()
    {
        interractionText.text = "";
        if (interactables == null)
        {
            interactables = new List<Interactable>();
        }
        player = GameObject.FindGameObjectWithTag("Player");
        p = player.GetComponent<PlayerBasitState>();
    }

    public void Update()
    {
        bool textCheck = false;
        if (p.State == PlayerState.NotInterracting)
        {
            foreach (Interactable inter in interactables)
            {
                if (inter.CheckDistance(player.transform.position))
                {
                    interractionText.text = inter.InterractionString;
                    textCheck = true;
                    if (Input.GetKeyDown(interractButton))
                    {
                        p.State = PlayerState.Interracting;
                        inter.Interact();
                    }
                    break;
                }
            }
        }

        if (!textCheck)
        {
            interractionText.text = "";
        }
    }
}
