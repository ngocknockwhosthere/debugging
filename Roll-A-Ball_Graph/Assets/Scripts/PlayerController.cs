using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using static DebugVariable;

public class PlayerController : MonoBehaviour
{
    public float speed = 0;
    public TextMeshProUGUI countText;
    public TextMeshProUGUI varName;
    public TextMeshProUGUI varValue;
    public GameObject winTextObject;

    private Rigidbody rb;
    private int count;
    private float movementX;
    private float movementY;
    public GameObject myDebugVariable;
    private DebugVariable DebugVariableScript;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        varName.text = "";
        varValue.text = "";
        //varName.text = "Var: count\nType: int\nObject: Player\nScript: PlayerController.cs\nLast Line Altered: 27";
        winTextObject.SetActive(false);
        DebugVariableScript = myDebugVariable.GetComponent<DebugVariable>();
    }

    private void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;

        DebugVariableScript.printVariable(movementX);
        DebugVariableScript.printVariable(movementX);
        //DebugVariableScript.AddPoint(transform.position.x);
        //varValue.text = "Value: " + transform.position.x.ToString();
        //DebugVariable.printVariable(movementX);
        //DebugVariable.printVariable(movementY);
    }

    /*
    private void Update()
    {   
        //transform.position.y
        DebugVariableScript.AddPoint(count); //was previously in OnMove
        //if (count == 1)
        //{
            //varName.text = "Var: count\nType: int\nObject: Player\nScript: PlayerController.cs\nLast Line Altered: 80";
        //}
        varValue.text = "Value: " + count.ToString(); //was previously in OnMove
    }
    */

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString(); //Bug: should add count.ToString()

        if (count >= 9)
        {
            winTextObject.SetActive(true);
        }
        
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        rb.AddForce(movement * speed);
    }
    void  OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
        
    }


}