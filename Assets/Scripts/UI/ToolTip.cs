using UnityEngine;
using UnityEngine.EventSystems;
// class for ui to show tool tip for invantory items
public class ToolTip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public string header;
    public string content;

    public void SetText(string h, string c)
    {
        header = h;
        content = c;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //Tooltip.ShowTooltip_Static(header + "\n" + content);
        Debug.Log(header + "\n" + content);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //Tooltip.HideTooltip_Static();
    }
}
