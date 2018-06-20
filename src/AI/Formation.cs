using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Formation : MonoBehaviour
{

    public enum FormationType
    {
        Line,
        Square
    }

    public List<GameObject> aiList;

    public GameObject formationObject;

    public float offsetBetweenSoldiers = 5.0f;

    public Vector3 m_FormationDirection;
    
    public Vector3 m_FormationRightDirection;
    
    public Vector3 m_FormationLeftDirection;

    private Vector3 m_BasePoint;

    private FormationType m_FormationType;

    private GameObject m_CurrentFormationMarker;

	void Start ()
    {
		
	}

    void CreateFormation()
    {
        switch (m_FormationType)
        {
            case FormationType.Line:
                for (int i = 0; i < aiList.Count; i++)
                {
                    if (i % 2 == 0)
                    {
                        //Vector3 pos = 
                        //aiList[i].transform.position = (m_BasePoint + (offsetBetweenSoldiers * i);
                    }
                }
                break;
            case FormationType.Square:
                break;
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
	    if (Input.GetKeyDown(KeyCode.F1))
        {
            Vector3 markerPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            m_CurrentFormationMarker = Instantiate(formationObject, markerPos, transform.rotation);
            Debug.Log("Spawned");
        }
        if (Input.GetKey(KeyCode.F1))
        {
            Debug.Log("Holding");
        }
        if (Input.GetKeyUp(KeyCode.F1))
        {
            Debug.Log("Remove the formation object");
            m_FormationDirection = m_CurrentFormationMarker.transform.forward;
            m_FormationRightDirection = m_CurrentFormationMarker.transform.right;
            m_FormationLeftDirection = -m_CurrentFormationMarker.transform.right;
            m_CurrentFormationMarker.transform.Translate(m_FormationDirection);
        }
	}
}
