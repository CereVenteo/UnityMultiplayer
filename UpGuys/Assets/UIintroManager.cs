using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIintroManager : MonoBehaviour
{
    [SerializeField]
    public Canvas CreateJoin_c;
    [SerializeField]
    public Canvas Lobby_c;

    private List<Canvas> MyUIcanvas = new List<Canvas>();
    private void Start()
    {
        //This way we can handle some canvas.
        MyUIcanvas.Add(CreateJoin_c);
        MyUIcanvas.Add(Lobby_c);


        CreateJoin_c.gameObject.SetActive(true);
        Lobby_c.gameObject.SetActive(false);
    }

    public void ActiveCanvas(Canvas a_canvas)
    {
        foreach(Canvas canvas in MyUIcanvas)
        {
            if (a_canvas == canvas)
            {
                //If they are the same we active this one
                canvas.gameObject.SetActive(true);
            }
            else
            {
                //and then we deactivate the rest
                canvas.gameObject.SetActive(false);
            }
        }
    }
}
