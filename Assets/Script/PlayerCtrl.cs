using UnityEngine;
using System.Collections;

public class PlayerCtrl : MonoBehaviour
{
    public float MoveSpeed = 1.0f;

    private Transform _directionTransform;
    private Transform _gunBaseTransform;
	// Use this for initialization
	void Start ()
	{
        _directionTransform = transform.FindChild("Direction").transform;
        _gunBaseTransform = transform.FindChild("GunBase").transform;
    }
	
	// Update is called once per frame
	void Update () {
        //MouseCtrl();
		if (Input.touchCount == 1)
	    	TouchMoveCtrl ();
		if (Input.touchCount > 1) {
			TouchMoveCtrl ();
			TouchShootCtrl ();
		}
	}

    void MouseCtrl()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 touchPos0 = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            float angle0 = -Mathf.Rad2Deg * Mathf.Atan((touchPos0.x - transform.position.x) / (touchPos0.y - transform.position.y));
            if (touchPos0.y - transform.position.y < 0)
                angle0 += 180;
            _directionTransform.eulerAngles = new Vector3(0, 0, angle0);
            transform.Translate((touchPos0 - transform.position) * MoveSpeed * Time.deltaTime);
        }
        if (Input.GetMouseButton(1))
        {
            Vector3 touchPos1 = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            float angle1 = -Mathf.Rad2Deg * Mathf.Atan((touchPos1.x - transform.position.x) / (touchPos1.y - transform.position.y));
            if (touchPos1.y - transform.position.y < 0)
                angle1 += 180;
            _gunBaseTransform.eulerAngles = new Vector3(0, 0, angle1);
        }
    }

    void TouchMoveCtrl()
	{
		if (Input.GetTouch (0).phase == TouchPhase.Moved || Input.GetTouch (0).phase == TouchPhase.Began) {
			Vector3 touchPos = Camera.main.ScreenToWorldPoint (Input.GetTouch(0).position);

			float angle = -Mathf.Rad2Deg * Mathf.Atan ((touchPos.x - transform.position.x) / (touchPos.y - transform.position.y));
			if (touchPos.y - transform.position.y < 0)
				angle += 180;
			_directionTransform.eulerAngles = new Vector3 (0, 0, angle);
			transform.Translate ((touchPos - transform.position) * MoveSpeed * Time.deltaTime);
		}
	}

	void TouchShootCtrl()
	{
		if (Input.GetTouch (1).phase == TouchPhase.Moved || Input.GetTouch (1).phase == TouchPhase.Began) {
			Vector3 touchPos = Camera.main.ScreenToWorldPoint (Input.GetTouch(1).position);

			float angle = -Mathf.Rad2Deg * Mathf.Atan ((touchPos.x - transform.position.x) / (touchPos.y - transform.position.y));
			if (touchPos.y - transform.position.y < 0)
				angle += 180;
			_gunBaseTransform.eulerAngles = new Vector3 (0, 0, angle);
		}
    }
}
