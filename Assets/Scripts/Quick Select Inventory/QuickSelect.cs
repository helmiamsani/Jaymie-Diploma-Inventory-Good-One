using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickSelect : MonoBehaviour
{
    #region Variables
    [Header("Main UI")]
    public bool showSelectMenu;
    public bool toggleTogglable;
    public float scrW, scrH;

    [Header("Resources")]
    public Texture2D radialTexture;
    public Texture2D slotTexture;

    [Header("Icons")]
    public int circleScaleOffset;
    public Vector2 iconSize;
    public bool showIcons, showBoxes, showBounds;
    [Range(0.1f, 1f)]
    public float iconSizeNum;
    [Range(-360, 360)]
    public int radialRotation;
    [SerializeField]
    private float iconOffset;

    [Header("Mouse Settings")]
    public Vector2 mouse;
    public Vector2 input;
    public Vector2 circleCentre;

    [Header("Input Settings")]
    public float inputDist;
    public float inputAngle;
    public int keyIndex;
    public int MouseIndex;
    public int inputIndex;

    [Header("Sector Settings")]
    public Vector2[] slotPos;
    public Vector2[] boundPos;
    [Range(1, 8)]
    public int numOfSectors = 1;
    [Range(50, 300)]
    public float circleRadius;
    public float mouseDistance, sectorDegree, mouseAngles;
    public int sectorIndex = 0;
    public bool withinCircle;

    [Header("Misc")]
    private Rect debugWindow;
    #endregion

    #region Set Up Functions
    private Vector2 Scr(float x, float y)
    {
        Vector2 coord = new Vector2(scrW * x, scrH * y);
        return coord;
    }
    private Vector2[] BoundPosition(int slots)
    {
        Vector2[] boundPos = new Vector2[slots];
        float angle = 0 + radialRotation;
        for (int i = 0; i < boundPos.Length; i++)
        {
            boundPos[i].x = circleCentre.x + circleRadius * Mathf.Cos(angle * Mathf.Deg2Rad);
            boundPos[i].y = circleCentre.y + circleRadius * Mathf.Sin(angle * Mathf.Deg2Rad);
            angle += sectorDegree;
        }
        return boundPos;
    }
    private Vector2[] SlotPositions(int slots)
    {
        Vector2[] slotPos = new Vector2[slots];
        float angle = ((iconOffset / 2) * 2) + radialRotation;
        for (int i = 0; i < slotPos.Length; i++)
        {
            slotPos[i].x = circleCentre.x + circleRadius * Mathf.Cos(angle * Mathf.Deg2Rad);
            slotPos[i].y = circleCentre.y + circleRadius * Mathf.Sin(angle * Mathf.Deg2Rad);
            angle += sectorDegree;
        }
        return slotPos;
    }
    void SetItemSlots(int slots, Vector2[] pos)
    {

    }

    #endregion


    #region Unity Function
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnGUI()
    {
    }
    #endregion
}
