using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wordManager : CustomBehaviour
{

    public static string currentWord;
    [SerializeField] private TextMesh txt;

    private void Start()
    {
        txt.text = currentWord;
    }

    // Start is called before the first frame update
    public override void Initialize(GameManager gameManager)
    {
        base.Initialize(gameManager);
    }

    public void upgradeText()
    {
        txt.text = currentWord;
    }
}
