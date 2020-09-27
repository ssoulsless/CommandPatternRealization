using UnityEngine;

public class ScaleChanger : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray origin = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit raycastHit;

            if (Physics.Raycast(origin, out raycastHit))
            {
                if (raycastHit.collider.tag == "Cube")
                {
                    ICommand scaleChange = new ScaleChangeCommand(raycastHit.collider.gameObject.GetComponent<Transform>());
                    scaleChange.Execute();
                    CommandManager.Instance.AddCommand(scaleChange);
                }
            }
        }
    }
}
