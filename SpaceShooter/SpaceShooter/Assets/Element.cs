using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Element : MonoBehaviour
{
    [SerializeField] Sprite WhiteSprite;
    [SerializeField] Sprite RedSprite;
    [SerializeField] Sprite GreenSprite;

    // Start is called before the first frame update
    private void Update()
    {
        changeElement();
    }
    private void changeElement()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = RedSprite;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = WhiteSprite;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = GreenSprite;
        }
    }
}
