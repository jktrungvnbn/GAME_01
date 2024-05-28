using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cursors : MonoBehaviour
{
    public GameObject cursorsObject;
    public Sprite cursorsBasic;
    public Sprite cursorsHand;
    public Image cursorsImage;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        cursorsObject.transform.position = Input.mousePosition;
        if (Input.GetMouseButton(1))
        {
            cursorsImage.sprite = cursorsHand;
        }
        else
        {
            cursorsImage.sprite = cursorsBasic;
        }
    }
}
