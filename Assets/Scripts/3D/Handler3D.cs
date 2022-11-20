using UnityEngine;
using UnityEngine.SceneManagement;

public class Handler3D : MonoBehaviour
{
    [SerializeField] GameObject _item1, _item2, _item3, _item4, _item5, _item6, _item7;
    [SerializeField] GameObject _arrowUp, _arrowDown, _barDescription;
    [SerializeField] GameObject _model1, _model2, _model3, _model4, _model5, _model6, _model7;

    public void ChangeItem(int no)
    {
        _item1.transform.Find("Image-Yes").gameObject.SetActive(false);
        _item2.transform.Find("Image-Yes").gameObject.SetActive(false);
        _item3.transform.Find("Image-Yes").gameObject.SetActive(false);
        _item4.transform.Find("Image-Yes").gameObject.SetActive(false);
        _item5.transform.Find("Image-Yes").gameObject.SetActive(false);
        _item6.transform.Find("Image-Yes").gameObject.SetActive(false);
        _item7.transform.Find("Image-Yes").gameObject.SetActive(false);

        _model1.SetActive(false);
        _model2.SetActive(false);
        _model3.SetActive(false);
        _model4.SetActive(false);
        _model5.SetActive(false);
        _model6.SetActive(false);
        _model7.SetActive(false);

        GameObject selectedItem = null, selectedModel = null;
        switch (no)
        {
            case 1:
                selectedItem = _item1;
                selectedModel = _model1;
                break;
            case 2:
                selectedItem = _item2;
                selectedModel = _model2;
                break;
            case 3:
                selectedItem = _item3;
                selectedModel = _model3;
                break;
            case 4:
                selectedItem = _item4;
                selectedModel = _model4;
                break;
            case 5:
                selectedItem = _item5;
                selectedModel = _model5;
                break;
            case 6:
                selectedItem = _item6;
                selectedModel = _model6;
                break;
            case 7:
                selectedItem = _item7;
                selectedModel = _model7;
                break;
        }

        selectedItem.transform.Find("Image-Yes").gameObject.SetActive(true);
        selectedModel.SetActive(true);

        _arrowUp.SetActive(false);
        _arrowDown.SetActive(true);
        _barDescription.SetActive(true);
    }

    public void ShowDescription(bool active)
    {
        _arrowUp.SetActive(!active);
        _arrowDown.SetActive(active);
        _barDescription.SetActive(active);
    }

    public void GoToARMode()
    {
        SceneManager.LoadScene("AR");
    }
}