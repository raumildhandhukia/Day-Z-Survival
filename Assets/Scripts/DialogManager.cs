using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogManager : MonoBehaviour
{
    bool isTalking = false;
    float distance;

    public GameObject player;
    public GameObject dialogUI;

    // Start is called before the first frame update
    void Start()
    {
        dialogUI.SetActive(false);
    }

    void StartConversation()
    {
        isTalking = true;
        dialogUI.SetActive(true);
    }

    void EndDialog()
    {
        isTalking = false;
        dialogUI.SetActive(false);
        GameManager.scorePerKill += 10;
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(player.transform.position, this.transform.position);
        if (distance <= 5f)
        {
            StartConversation();
        }
        else if (isTalking)
        {
            EndDialog();
        }
    }
}
