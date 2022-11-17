using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class LSPlayer : MonoBehaviour
{
    public MapPoint currentPoint;
    public float moveSpeed = 10f;
    private bool levelLoading;
    public LSManager theManager;
    // Start is called before the first frame update
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position,currentPoint.transform.position,moveSpeed * Time.deltaTime);
        if(Vector3.Distance(transform.position, currentPoint.transform.position ) < 0.1f && !levelLoading)
        {
            MovePlayer();
            LoadLevel();
        }
    }
    public void LoadLevel()
    {
        if(currentPoint.isLevel && currentPoint.levelToLoad != "" && !currentPoint.isLocked)
        {
            // show level name
            LSUIController.instance.ShowInfo(currentPoint);
            // load level
            if(Input.GetButtonDown("Jump"))
            {
                levelLoading = true;
                theManager.LoadLevel();
            }
        }
    }
    public void SetNextPoint(MapPoint nextPoint)
    {
        currentPoint = nextPoint;
        LSUIController.instance.HideInfo(); 
    }
    private void MovePlayer()
    {
        if(Input.GetAxisRaw("Horizontal") > 0.5f)
        {
            if(currentPoint.right != null)
            {
                SetNextPoint(currentPoint.right);
            }
        }
        else if(Input.GetAxisRaw("Horizontal") <  -0.5f)
        {
            if(currentPoint.left != null)
            {
                SetNextPoint(currentPoint.left);
            }
        }
        else if(Input.GetAxisRaw("Vertical") >  0.5f)
        {
            if(currentPoint.up != null)
            {
                SetNextPoint(currentPoint.up);
            }
        }
        else if(Input.GetAxisRaw("Vertical") <  -0.5f)
        {
            if(currentPoint.down != null)
            {
                SetNextPoint(currentPoint.down);
            }
        }
    }
}
