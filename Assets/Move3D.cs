using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move3D : MonoBehaviour
{
    private Camera mainCamera;
    private float CameraZDistance;
    public GameObject NodesR,NodesL;
    public GameObject Tavan;
    public GameObject DuvarR, DuvarL;
    public GameObject HorizontalNodes;
    private float tempY;


    void Start()
    {
        tempY = transform.position.y;
        mainCamera = Camera.main;
        CameraZDistance = mainCamera.WorldToScreenPoint(transform.position).z;
        ControlNodesR();
        ControlNodesL();
        ControlHorizontalNodes();
    }

	private void OnMouseDrag()
	{
        Vector3 ScreenPosition = new Vector3(
            Input.mousePosition.x, Input.mousePosition.y, CameraZDistance);
        Vector3 NewWorldPosition = mainCamera.ScreenToWorldPoint(ScreenPosition);
		if (transform.CompareTag("handleR"))
		{
            tempY = NewWorldPosition.y - transform.position.y;
            NodesR.transform.position = new Vector3(NodesR.transform.position.x, NodesR.transform.position.y+tempY, NodesR.transform.position.z);
            NodesL.transform.position = new Vector3(NodesL.transform.position.x, NodesL.transform.position.y-tempY, NodesL.transform.position.z);
            HorizontalNodes.transform.position = new Vector3(HorizontalNodes.transform.position.x - tempY, HorizontalNodes.transform.position.y, HorizontalNodes.transform.position.z);
        }
        else if (transform.CompareTag("handleL"))
        {
            tempY = NewWorldPosition.y - transform.position.y;
            NodesR.transform.position = new Vector3(NodesR.transform.position.x, NodesR.transform.position.y + tempY, NodesR.transform.position.z);
            NodesL.transform.position = new Vector3(NodesL.transform.position.x, NodesL.transform.position.y - tempY, NodesL.transform.position.z);
            HorizontalNodes.transform.position = new Vector3(HorizontalNodes.transform.position.x + tempY, HorizontalNodes.transform.position.y, HorizontalNodes.transform.position.z);
        }

        ControlNodesR();
        ControlNodesL();
        ControlHorizontalNodes();
	}

	private void OnMouseUp()
	{
        PlayerController.instance.Jump();
	}


	private void ControlNodesR()
	{
		for (int i = 0; i < NodesR.transform.childCount-1; i++)
		{
            if(NodesR.transform.GetChild(i).transform.position.y < Tavan.transform.position.y)
			{
                NodesR.transform.GetChild(i).transform.GetComponent<Renderer>().enabled = true;
			}
			else
			{
                NodesR.transform.GetChild(i).transform.GetComponent<Renderer>().enabled = false;
            }
		}
	}

    private void ControlNodesL()
	{
        for (int i = 0; i < NodesL.transform.childCount-1; i++)
        {
            if (NodesL.transform.GetChild(i).transform.position.y < Tavan.transform.position.y)
            {
                NodesL.transform.GetChild(i).transform.GetComponent<Renderer>().enabled = true;
            }
            else
            {
                NodesL.transform.GetChild(i).transform.GetComponent<Renderer>().enabled = false;
            }
        }
    }

    private void ControlHorizontalNodes()
	{
        for (int i = 0; i < HorizontalNodes.transform.childCount; i++)
        {
            if (HorizontalNodes.transform.GetChild(i).transform.position.x < DuvarR.transform.position.x &&
                HorizontalNodes.transform.GetChild(i).transform.position.x > DuvarL.transform.position.x)
            {
                HorizontalNodes.transform.GetChild(i).transform.GetComponent<Renderer>().enabled = true;
            }
            else
            {
                HorizontalNodes.transform.GetChild(i).transform.GetComponent<Renderer>().enabled = false;
            }
        }
    }
}
