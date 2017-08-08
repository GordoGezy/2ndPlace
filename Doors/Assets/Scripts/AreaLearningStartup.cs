using System.Collections;
using System.Collections.Generic;
using Tango;
using UnityEngine;

public class AreaLearningStartup : MonoBehaviour, ITangoLifecycle
{

    public Vector3 playerStartPos;
    public Vector3 stairsStartPos;
    public Vector3 boulderStartPos;
    public Quaternion playerStartRot;
    public Quaternion stairsStartRot;
    public Quaternion boulderStartRot;

    public GameObject stairs;
    public GameObject player;
    public GameObject boulder;

    private TangoApplication m_tangoApplication;

    public void Start()
    {
        m_tangoApplication = FindObjectOfType<TangoApplication>();
        /*stairs = Resources.Load("/Prefabs/Stairs");
        player = Resources.Load("/Prefabs/Player");
        boulder = Resources.Load("/Prefabs/Boulder");*/
        if (m_tangoApplication != null)
        {
            m_tangoApplication.Register(this);
            m_tangoApplication.RequestPermissions();
        }
    }

    public void StartButton()
    {
		GameObject Stairs = Instantiate(stairs, stairsStartPos, Quaternion.Euler(0, 30, 0));
        GameObject Player = Instantiate(player, playerStartPos, playerStartRot);
        GameObject Boulder = Instantiate(boulder, boulderStartPos, boulderStartRot);
        Destroy(GameObject.Find("StartButton"));
    }

    public void OnTangoPermissions(bool permissionsGranted)
    {
        if (permissionsGranted)
        {
            AreaDescription[] list = AreaDescription.GetList();
            AreaDescription mostRecent = null;
            AreaDescription.Metadata mostRecentMetadata = null;
            if (list.Length > 0)
            {
                // Find and load the most recent Area Description
                mostRecent = list[0];
                mostRecentMetadata = mostRecent.GetMetadata();
                foreach (AreaDescription areaDescription in list)
                {
                    AreaDescription.Metadata metadata = areaDescription.GetMetadata();
                    if (metadata.m_dateTime > mostRecentMetadata.m_dateTime)
                    {
                        mostRecent = areaDescription;
                        mostRecentMetadata = metadata;
                    }
                }
                /*playerStartPos = ;
                playerStartRot = ;
                boulderStartPos = ;
                boulderStartRot = ;*/
                m_tangoApplication.Startup(mostRecent);
            }
            else
            {
                // No Area Descriptions available.
                Debug.Log("No area descriptions available.");
            }
        }
    }

    public void OnTangoServiceConnected()
    {
    }

    public void OnTangoServiceDisconnected()
    {
    }
}